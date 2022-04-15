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
        private Stopwatch stopwatch;
        public Networking network;
      //  private Player player;
        private World _world;
        private int _fps;
        private long playerID;
        private string playerName;

        private bool playerComfirmed;


        private readonly int XWIDTH = 500;
        private readonly int YHEIGHT = 500;
        private int SCALEFACTOR = 3;
        private int OFFSET = 250;

        public ILogger<ClientGUI> _logger;

        public ClientGUI(ILogger<ClientGUI> logger)
        {
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
        }

        private void Draw_Players(object? sender, PaintEventArgs e)
        {


            if (!playerComfirmed)
                return;
            foreach (var player in _world.players.Values)
            {
                ScaleWorld(player, out float playerX, out float playerY, out float playerRadius);
                SolidBrush brush2 = new(Color.FromArgb((int)player.ARGBColor));

                if (playerX > XWIDTH || playerX < 0.0) continue;
                if (playerY > YHEIGHT || playerY < 0.0) continue;

                e.Graphics.FillEllipse(brush2, new Rectangle((int)playerX, (int)playerY, (int)playerRadius, (int)playerRadius));
            }
        }

        private void Draw_Food(object? sender, PaintEventArgs e)
        {
            if (!playerComfirmed)
                return;
            foreach (var food in _world.food)
            {
                ScaleWorld(food, out float foodX, out float foodY, out float foodRadius);
                if (foodX > XWIDTH || foodX < 0.0) continue;
                if (foodY > YHEIGHT || foodY < 0.0) continue;
                SolidBrush brush2 = new(Color.FromArgb((int)food.ARGBColor));

                e.Graphics.FillEllipse(brush2, new Rectangle((int)foodX, (int)foodY, (int)foodRadius, (int)foodRadius));
            }
        }

        /// <summary>
        /// Helper method to draw the world 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Draw_World(object? sender, PaintEventArgs e)
        {
            if (!playerComfirmed)
                return;
            count++;
            Pen worldBrush = new(new SolidBrush(Color.Black));
            SolidBrush brush = new(Color.Gray);
            e.Graphics.DrawRectangle(worldBrush, _world.Rectangle);
            e.Graphics.FillRectangle(brush, _world.Rectangle);
            showFPS();
        }

        /// <summary>
        /// Helper method to display the fps of the world
        /// </summary>
        private void showFPS()
        {
            _fps = (int)(count / stopwatch.Elapsed.TotalSeconds);
            Invoke(() => { fps_txt.Text = _fps.ToString(); });
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
            });
        }


        public void onDisconnect(Networking network)
        {

        }


        public void onMessage(Networking network, string message)
        {

            string[] messages = message.Split("\n");
            Command(messages);

            if (!_world.players.ContainsKey(playerID))
                return;
            float x = _world.players[playerID].X;
            float y = _world.players[playerID].Y;
            network.Send(String.Format(Protocols.CMD_Move, x, y));
            Debug.Write("X: " + x);
            Debug.Write("Y: " + y);
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
                    List<Food> foodList = JsonSerializer.Deserialize<List<Food>>(s.Substring(Protocols.CMD_Food.Length)); //TODO: How will we add food to world object?
                    foreach (AgarioModels.Food food in foodList)
                    {
                        _world.food.Add(food);
                    }
                }
                else if (s.StartsWith(Protocols.CMD_Eaten_Food))
                {
                    // return s.Substring(Protocols.CMD_Eaten_Food.Length);
                }
                else if (s.StartsWith(Protocols.CMD_HeartBeat))
                {
                    //  return s.Substring(Protocols.CMD_HeartBeat.Length);
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
                    playerComfirmed = true;
                }
                else if (s.StartsWith(Protocols.CMD_Move_Recognizer))
                {
                    // return s.Substring(Protocols.CMD_Move_Recognizer.Length);
                }
                else if (s.StartsWith(Protocols.CMD_Update_Players))
                {
                    List<Player> playerList = JsonSerializer.Deserialize<List<Player>>(s.Substring(Protocols.CMD_Update_Players.Length)); //TODO: How will we add food to world object?
                    foreach (AgarioModels.Player player in playerList)
                    {
                        _world.players.TryAdd(player.ID, player);
                    }
                }
                else if (s.StartsWith(Protocols.CMD_Player_Object))
                {
                    playerID = long.Parse(s.Substring(Protocols.CMD_Player_Object.Length));
                    //player = new Player(playerID, new Vector2(0, 0), 250, 250, 300, 500, playerName);
                }
                if (s.StartsWith(Protocols.CMD_Dead_Players))
                {
                    //  return s.Substring(Protocols.CMD_Dead_Players.Length);
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
                network = new Networking(_logger, onConnect, onDisconnect, onMessage, '\n');
                network.Connect(server_box.Text.ToString(), 11000);
                network.ClientAwaitMessagesAsync();
            }
        }

        private void ScaleWorld(GameObject obj, out float scaleX, out float scaleY, out float scaleRadius)
        {
            Player currPlayer = _world.players[playerID];
            scaleX = currPlayer.X - obj.X;
            scaleY = currPlayer.Y - obj.Y;

            scaleX = scaleX / _world.Width * XWIDTH;
            scaleY = scaleY / _world.Height * YHEIGHT;
            float scaleMass = obj.Mass * 500 / _world.Width;
            scaleRadius = (float)Math.Sqrt(scaleMass / Math.PI);
            scaleRadius *= SCALEFACTOR;

            scaleX *= SCALEFACTOR;
            scaleY *= SCALEFACTOR;

            scaleX += OFFSET;
            scaleY += OFFSET;
        }

        private void scaleMouse(out float scaleX, out float scaleY)
        {
            scaleX = 0;
            scaleY = 0;


            scaleX -= OFFSET;
            scaleY -= OFFSET;

            scaleX /= SCALEFACTOR;
            scaleY /= SCALEFACTOR;

            scaleX = scaleX * _world.Width / XWIDTH;
            scaleY = scaleY * _world.Height / YHEIGHT;

        }

        private void ClientGUI_MouseHover(object sender, EventArgs e)
        {
           // int x = e.X;
        }

        private void ClientGUI_MouseMove(object sender, MouseEventArgs e)
        {
            if (playerID == -1)
                return;
            Random random = new Random();
            //network.Send(String.Format(Protocols.CMD_Move, random.NextInt64(5000), random.NextInt64(5000)));
        }
    }
}