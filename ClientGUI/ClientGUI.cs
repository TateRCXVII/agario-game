using AgarioModels;
using Communications;
using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Numerics;
using System.Text.Json;

namespace ClientGUI
{
    public partial class ClientGUI : Form
    {
        private int count;
        private bool start;
        private Stopwatch stopwatch;
        public Networking network;
      //  private Player player;
        private World _world;
        private int _fps;
        private int heartCount;
        private int playerMass;
        private Vector2 playerPosition;
        private Vector2 mousePosition;

        private long playerID;
        private string playerName;

        private bool playerComfirmed;

        private float mouseX;
        private float mouseY;

        private readonly int SCREENWIDTH = 800;
        private readonly int SCREENHEIGHT = 800;
        private int SCALEFACTOR = 3;
        private int OFFSET = 400;


        public ILogger<ClientGUI> _logger;

        private object lock1;

        public ClientGUI(ILogger<ClientGUI> logger)
        {
            mouseX = 0;
            mouseY = 0;

            start = true;
            playerID = -1;
            this.Paint += Draw_World;
            this.Paint += Draw_Food;
            this.Paint += Draw_Players;

            var timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000 / 30;  // 1000 milliseconds in a second divided by 30 frames per second
            timer.Tick += (a, b) => this.Invalidate();

            timer.Start();
            stopwatch = Stopwatch.StartNew();
            InitializeComponent();

            _logger = logger;
            _world = new World(_logger);
            playerComfirmed = false;

            lock1 = new object();
            playerPosition = new Vector2(0, 0);
            mousePosition = new Vector2(0, 0);
            Disconnected_label.Visible = false;
            Dead_label.Visible = false;
            Exception_label.Visible = false;
        }

        private void Draw_Players(object? sender, PaintEventArgs e)
        {
            lock (lock1)
            {
                if (!playerComfirmed || playerID == -1)
                    return;
                try
                {
                    foreach (var player in _world.players.Values)
                    {

                        ScaleToScreen(player, out float playerX, out float playerY, out float playerRadius);
                        SolidBrush brush = new(Color.FromArgb((int)player.ARGBColor));

                        if (playerX > SCREENWIDTH || playerX < 0.0) continue;
                        if (playerY > SCREENHEIGHT || playerY < 0.0) continue;

                        if (!_world.deadPlayers.Contains(player.ID))
                        {
                            int x = (int)(playerX - playerRadius * 1.1);
                            int y = (int)(playerY - playerRadius * 1.1);
                            e.Graphics.FillEllipse(brush, x, y, (int)playerRadius * 2, (int)playerRadius * 2);
                            e.Graphics.DrawString(player.Name, new Font("Bold", 20, FontStyle.Regular), new SolidBrush(Color.Black), x, playerY - playerRadius);
                        }
                    }
                }
                catch (Exception ex)
                {
                    
                }
                
            }
           
        }

        private void Draw_Food(object? sender, PaintEventArgs e)
        {
            lock (lock1)
            {
                try
                {
                    if (!playerComfirmed || playerID == -1)
                        return;
                    foreach (var food in _world.food)
                    {

                        ScaleToScreen(food, out float foodX, out float foodY, out float foodRadius);
                        if (foodX > SCREENWIDTH || foodX < 0.0) continue;
                        if (foodY > SCREENHEIGHT || foodY < 0.0) continue;
                        SolidBrush brush2 = new(Color.FromArgb((int)food.ARGBColor));
                        int x = (int)(foodX - foodRadius * 1.1);
                        int y = (int)(foodY - foodRadius * 1.1);
                        if (!_world.deadFood.Contains(food.ID))
                            e.Graphics.FillEllipse(brush2, new Rectangle((int)x, (int)y, (int)foodRadius * 2, (int)foodRadius * 2));
                    }
                }
                catch (Exception ex)
                {
                    
                }
                
            }
           
        }

        /// <summary>
        /// Helper method to draw the world 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Draw_World(object? sender, PaintEventArgs e)
        {
            lock (lock1) {
                if (!playerComfirmed || playerID == -1)
                    return;
                count++;
                Pen worldBrush = new(new SolidBrush(Color.Black));
                SolidBrush brush = new(Color.White);
                e.Graphics.DrawRectangle(worldBrush, _world.Rectangle);
                e.Graphics.FillRectangle(brush, _world.Rectangle);
                showFPS();
                showGameStats();
            } 
        }

        /// <summary>
        /// Helper method to display the fps of the world
        /// </summary>
        private void showFPS()
        {
            _fps = (int)(count / stopwatch.Elapsed.TotalSeconds);
            Invoke(() => { fps_txt.Text = _fps.ToString(); });
        }

        private void showGameStats()
        {
            int hps = (int)(heartCount / stopwatch.Elapsed.TotalSeconds);
                Invoke(() => { 
                HPS_value.Text = hps.ToString(); 
                Players_value.Text = _world.playerCount.ToString();
                Food_value.Text = _world.foodCount.ToString();
                Mass_value.Text = playerMass.ToString();
                Position_value.Text = playerPosition.ToString();
                MouseP_value.Text = mousePosition.ToString();
            });
        }

        public void onConnect(Networking network)
        {
            network.Send(String.Format(Protocols.CMD_Start_Game, playerName));
            Invoke(() =>
            {
                player_name_box.Visible = false;
                player_name_label.Visible = false;
                server_box.Visible = false;
                server_label.Visible = false;
                player_name_box.Enabled = false;
                player_name_label.Enabled = false;
                server_box.Enabled = false;
                server_label.Enabled = false;
            });
        }


        public void onDisconnect(Networking network)
        {
            Invoke(() =>
            {
                player_name_box.Visible = true;
                player_name_label.Visible = true;
                server_box.Visible = true;
                server_label.Visible = true;
                player_name_box.Enabled = true;
                player_name_label.Enabled = true;
                server_box.Enabled = true;
                server_label.Enabled = true;
                start = true;
                playerID = -1;
                playerComfirmed = false;
                _world.players.Clear();
                _world.deadPlayers.Clear();
                _world.food.Clear();
                _world.deadFood.Clear();
                Disconnected_label.Visible = true;
            });
        }


        public void onMessage(Networking network, string message)
        {
            string[] messages = message.Split("\n");
            try
            {
                Command(messages);
            }
            catch(Exception e){
                Exception_label.Text = "JSON ERROR";
            }
            
        }

        /// <summary>
        /// Helper method to process the protocol commands and output the rest of the command
        /// </summary>
        /// <param name="command">input command</param>
        /// <returns>the parsed input command</returns>
        void Command(string[] command)
        {
            foreach (string s in command)
            {
                if (s.StartsWith(Protocols.CMD_Food))
                {
                    playerComfirmed = true;
                    List<Food> foodList = JsonSerializer.Deserialize<List<Food>>(s.Substring(Protocols.CMD_Food.Length));
                   
                    foreach (AgarioModels.Food food in foodList)
                    {
                        food.X = Reverse(food.X);
                        food.Y = Reverse(food.Y);
                        _world.food.Add(food);
                    }
                    
                }
                else if (s.StartsWith(Protocols.CMD_Eaten_Food))
                {
                    List<long> deadFoods = JsonSerializer.Deserialize<List<long>>(s.Substring(Protocols.CMD_Eaten_Food.Length));
                    foreach (long deadFood in deadFoods)
                    {
                        _world.deadFood.Add(deadFood);
                    }
                    _world.foodCount = _world.food.Count - _world.deadFood.Count;
                }
                else if (s.StartsWith(Protocols.CMD_HeartBeat))
                {
                    if (!playerComfirmed || playerID == -1)
                        return;

                    float currMouseX = mouseX;
                    float currMouseY = mouseY;  
                    ScaleMouse(out currMouseX, out currMouseY);

                    string send = String.Format(Protocols.CMD_Move, (int)currMouseX, (int)currMouseY);
                    network.Send(send);

                    heartCount++;
                }
                else if (s.StartsWith(Protocols.CMD_Move))
                {
                    // return s.Substring(Protocols.CMD_Move.Length);
                }
                else if (s.StartsWith(Protocols.CMD_Split))
                {
                    // return s.Substring(Protocols.CMD_Split.Length);
                }
                else if (s.StartsWith(Protocols.CMD_Split_Recognizer))
                {
                    // return s.Substring(Protocols.CMD_Split_Recognizer.Length);
                }
                else if (s.StartsWith(Protocols.CMD_Start_Game))
                {
                    //return s.Substring(Protocols.CMD_Start_Game.Length);
                }
                else if (s.StartsWith(Protocols.CMD_Start_Recognizer))
                {
                }
                else if (s.StartsWith(Protocols.CMD_Move_Recognizer))
                {

                }
                else if (s.StartsWith(Protocols.CMD_Update_Players))
                {
                    List<Player> playerList = JsonSerializer.Deserialize<List<Player>>(s.Substring(Protocols.CMD_Update_Players.Length));
                    _world.playerCount = playerList.Count;
                    foreach (AgarioModels.Player player in playerList)
                    {
                        player.X = Reverse(player.X);
                        player.Y = Reverse(player.Y);
                        if (!_world.players.TryAdd(player.ID, player))
                        {
                            _world.players.TryUpdate(player.ID, player,_world.players[player.ID]);
                        }
                        if(player.ID == playerID)
                            playerComfirmed = true;
                    }
                }
                else if (s.StartsWith(Protocols.CMD_Player_Object))
                {
                    playerID = long.Parse(s.Substring(Protocols.CMD_Player_Object.Length));
                    _logger.LogDebug($"PlayerID: {playerID} has connected");
                    
                }
                if (s.StartsWith(Protocols.CMD_Dead_Players))
                {
                    List<long> deadPlayers = JsonSerializer.Deserialize<List<long>>(s.Substring(Protocols.CMD_Dead_Players.Length));
                    foreach(long deadPlayer in deadPlayers)
                    {
                        if (deadPlayer == playerID)
                            PlayerDead();
                        _world.deadPlayers.Add(deadPlayer);
                    } 
                   // _world.deadPlayers = JsonSerializer.Deserialize<ConcurrentBag<long>>(s.Substring(Protocols.CMD_Dead_Players.Length));
                }
            }
            //return "";
        }

        /// <summary>
        /// To record player anme and server name
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void player_name_box_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (player_name_box.Text == String.Empty || server_box.Text == String.Empty)
                {
                    return;
                }
                playerName = player_name_box.Text.ToString();
                if (start)
                {
                    try
                    {
                        network = new Networking(_logger, onConnect, onDisconnect, onMessage, '\n');
                        network.Connect(server_box.Text.ToString(), 11000);
                        network.ClientAwaitMessagesAsync();
                        start = false;
                        Disconnected_label.Visible = false;
                        Exception_label.Visible = false;
                    }
                    catch(Exception ex)
                    {
                        Exception_label.Text = "FAILED TO CONNECT TO SERVER";
                        Exception_label.Visible = true;
                    }
                    
                }
                else
                {
                    network.Send(String.Format(Protocols.CMD_Start_Game, playerName));
                    
                    player_name_box.Visible = false;
                    player_name_label.Visible = false;
                    player_name_box.Enabled = false;
                    player_name_label.Enabled = false;
                }
                Dead_label.Visible = false;
            }
        }

        private void ScaleToScreen(GameObject obj, out float scaleX, out float scaleY, out float scaleRadius)
        {

                Player currPlayer = _world.players[playerID];
                playerMass = (int)currPlayer.Mass;
               
                playerPosition.X = Reverse(currPlayer.X);
                playerPosition.Y = Reverse(currPlayer.Y);
                scaleX = currPlayer.X - obj.X;
            scaleY = currPlayer.Y - obj.Y;
           
            

            scaleX = scaleX / _world.Width * SCREENWIDTH;
            scaleY = scaleY / _world.Height * SCREENHEIGHT;

            float scaleMass = obj.Mass * SCREENWIDTH / _world.Width;
            scaleRadius = (float)Math.Sqrt(scaleMass / Math.PI);
            scaleRadius *= SCALEFACTOR;

            scaleX *= SCALEFACTOR;
            scaleY *= SCALEFACTOR;

            scaleX += OFFSET;
            scaleY += OFFSET;
        }

        private void ScaleMouse(out float scaleX, out float scaleY)
        {
            scaleX = mouseX;
            scaleY = mouseY;

            scaleX = ConvertOverFlow(scaleX);
            scaleY = ConvertOverFlow(scaleY);

            scaleX -= OFFSET;
            scaleY -= OFFSET;

            scaleX /= SCALEFACTOR;
            scaleY /= SCALEFACTOR;

            scaleX = scaleX * _world.Width / SCREENWIDTH;
            scaleY = scaleY * _world.Height / SCREENHEIGHT;

            Player me = _world.players[playerID];

            scaleX += Reverse(me.X);
            scaleY += Reverse(me.Y); 

            mousePosition.X = scaleX;
            mousePosition.Y = scaleY;
        }

        private void ClientGUI_MouseMove(object sender, MouseEventArgs e)
        {
            mouseX = e.X;
            mouseY = e.Y;
        }
        private void ClientGUI_KeyDown(object sender, KeyEventArgs e)
        {
            if (!playerComfirmed || playerID == -1)
                return;
            float currMouseX = mouseX;
            float currMouseY = mouseY;
            ScaleMouse(out currMouseX, out currMouseY);

            string send = String.Format(Protocols.CMD_Split, (int)currMouseX, (int)currMouseY);
            network.Send(send);
        }

        private void PlayerDead() {
            playerComfirmed = false;
            playerID = -1;
            Invoke(() =>
            {
                player_name_box.Visible = true;
                player_name_label.Visible = true;
                player_name_box.Enabled = true;
                player_name_label.Enabled = true;
                Dead_label.Visible = true;
            });
        }

        private float ConvertOverFlow(float value)
        {
            if (value > SCREENWIDTH)
                return SCREENWIDTH;
            if (value < 0)
                return 0;
            else return value;

        }

        private float Reverse(float input)
        {
            return input + (2500 - input) * 2;
        }

        private void ClientGUI_FormClosing(object sender, FormClosingEventArgs e)
        {
           // network.Disconnect();
        }
    }

}