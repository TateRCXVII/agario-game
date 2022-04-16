/// <summary> 
/// Author:    Tate Reynolds/Thatcher Geary
/// Partner:   each other
/// Date:      4/16/2022 
/// Course:    CS 3500, University of Utah, School of Computing 
/// Copyright: CS 3500 and Thatcher Geary - This work may not be copied for use in Academic Coursework. 
/// 
/// We, Thatcher Geary and Tate Reynolds, certify that I wrote this code from scratch and did not copy it in part or whole from  
/// another source.  All references used in the completion of the assignment are cited in my README file. 
/// 
/// File Contents 
/// The ClientGUI code
/// </summary>

using AgarioModels;
using Communications;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Numerics;
using System.Text.Json;

/// <summary>
/// Namespace for ClientGUI this namespace has the clientGUI class and Client class contained in it.
/// </summary>
namespace ClientGUI
{


    /// <summary>
    /// The ClientGUI is the GUI for the client that lets a user connect to a server and play agar.io game. 
    /// The ClientGUI is responsible for sending the information for where to move and when to connect, and split.
    /// It does not store information of the players and food it recieves it from the server and then paints that information 
    /// on the 800x800 screen.
    /// The user can move the ball with the mouse and split with the space.
    /// </summary>
    public partial class ClientGUI : Form
    {
        private int count;
        private bool start;
        private Stopwatch stopwatch;
        private Networking network;
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

        /// <summary>
        /// The constructor for the ClientGUI
        /// </summary>
        /// <param name="logger">
        /// The logger that we will use to log information about the game
        /// </param>
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

        /// <summary>
        /// Draws all the players that are alive and in the range of the 800 by 800 screen
        /// </summary>
        /// <param name="sender">
        /// sender object
        /// </param>
        /// <param name="e">
        /// e lets the client paint various objects.
        /// </param>
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
                    //when we rejoin the ScaleToScreen can be called before the player is in the players Dictionary this catches that exception
                }
            }
        }

        /// <summary>
        /// Draws all the Food that are alive and in the range of the 800 by 800 screen
        /// </summary>
        /// <param name="sender">
        /// sender object
        /// </param>
        /// <param name="e">
        /// e lets the client paint various objects.
        /// </param>
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
                    //when we rejoin the ScaleToScreen can be called before the player is in the players Dictionary this catches that exception
                }

            }

        }

        /// <summary>
        /// Helper method to draw the world 
        /// </summary>
        /// <param name="sender">
        /// sender object
        /// </param>
        /// <param name="e">
        /// e lets the client paint various objects.
        /// </param>
        private void Draw_World(object? sender, PaintEventArgs e)
        {
            lock (lock1)
            {
                if (!playerComfirmed || playerID == -1)
                    return;
                count++;
                Pen worldBrush = new(new SolidBrush(Color.Black));
                SolidBrush brush = new(Color.White);
                try
                {
                    e.Graphics.DrawRectangle(worldBrush, _world.Rectangle);
                    e.Graphics.FillRectangle(brush, _world.Rectangle);
                    showFPS();
                    showGameStats();
                }
                catch (Exception ex)
                {
                    _logger.LogDebug("graphics error");
                }

            }
        }

        /// <summary>
        /// Helper method to display the fps of the world
        /// </summary>
        private void showFPS()
        {
            _fps = (int)(count / stopwatch.Elapsed.TotalSeconds);
            Invoke((Action)(() => { fps_txt.Text = this._fps.ToString(); }));
        }

        /// <summary>
        /// This is a helper method to show the game stats on the GUI
        /// We show HPS, number of alive players, number of alive food, player mass, player position, mouse position.
        /// </summary>
        private void showGameStats()
        {
            int hps = (int)(heartCount / stopwatch.Elapsed.TotalSeconds);
            Invoke(() =>
            {
                HPS_value.Text = hps.ToString();
                Players_value.Text = _world.playerCount.ToString();
                Food_value.Text = _world.foodCount.ToString();
                Mass_value.Text = playerMass.ToString();
                Position_value.Text = playerPosition.ToString();
                MouseP_value.Text = mousePosition.ToString();
            });
        }

        /// <summary>
        /// method for onConnect delegate. 
        /// This method is called when the network is connected to the server
        /// It will send to the network permission to join the game
        /// </summary>
        /// <param name="network">
        /// network object representing the connection between the client and the server
        /// </param>
        public void onConnect(Networking network)
        {
            _logger.LogDebug("Network connection successful");
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


        /// <summary>
        /// method for onDisconnect delegate. 
        /// This method is called when the network is disconnected to the server
        /// it will prepare the GUI to reconnect with a server
        /// </summary>
        /// <param name="network">
        /// networking object representing the connection between the client and the server
        /// </param>
        public void onDisconnect(Networking network)
        {
            _logger.LogDebug("discconected from network");
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


        /// <summary>
        /// method for onMessage delegate. 
        /// This method is called when the network calls the onMessage
        /// it will receive a message by a protocol and this is how we get the all the information from the server.
        /// This will use a helper method Command to actually input the data given by the message
        /// </summary>
        /// <param name="network">
        /// networking object representing the connection between the client and the server
        /// </param>
        /// <param name="message">
        /// message that is inputted from the network that contains the information for the client
        /// </param>
        public void onMessage(Networking network, string message)
        {
            try
            {
                Command(message);
            }
            catch (Exception e)
            {
                Exception_label.Text = "JSON ERROR";
            }

        }

        /// <summary>
        /// Helper method to process the protocol commands and output the rest of the command
        /// And to store the information given from the server
        /// </summary>
        /// <param name="command">input command</param>
        void Command(string command)
        {
            if (command.StartsWith(Protocols.CMD_Food))
            {
                playerComfirmed = true;
                List<Food> foodList = JsonSerializer.Deserialize<List<Food>>(command.Substring(Protocols.CMD_Food.Length));

                foreach (AgarioModels.Food food in foodList)
                {
                    food.X = Reverse(food.X);
                    food.Y = Reverse(food.Y);
                    _world.food.Add(food);
                }

            }
            else if (command.StartsWith(Protocols.CMD_Eaten_Food))
            {
                List<long> deadFoods = JsonSerializer.Deserialize<List<long>>(command.Substring(Protocols.CMD_Eaten_Food.Length));
                foreach (long deadFood in deadFoods)
                {
                    _world.deadFood.Add(deadFood);
                }
                _world.foodCount = _world.food.Count - _world.deadFood.Count;
            }
            else if (command.StartsWith(Protocols.CMD_HeartBeat))
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
            else if (command.StartsWith(Protocols.CMD_Update_Players))
            {
                List<Player> playerList = JsonSerializer.Deserialize<List<Player>>(command.Substring(Protocols.CMD_Update_Players.Length));
                
                foreach (AgarioModels.Player player in playerList)
                {
                    player.X = Reverse(player.X);
                    player.Y = Reverse(player.Y);
                    if (!_world.players.TryAdd(player.ID, player))
                    {
                        _world.players.TryUpdate(player.ID, player, _world.players[player.ID]);
                    }
                    if (player.ID == playerID)
                        playerComfirmed = true;
                }
            }
            else if (command.StartsWith(Protocols.CMD_Player_Object))
            {
                playerID = long.Parse(command.Substring(Protocols.CMD_Player_Object.Length));
                _logger.LogDebug($"PlayerID: {playerID} has connected");

            }
            if (command.StartsWith(Protocols.CMD_Dead_Players))
            {
                List<long> deadPlayers = JsonSerializer.Deserialize<List<long>>(command.Substring(Protocols.CMD_Dead_Players.Length));
                foreach (long deadPlayer in deadPlayers)
                {
                    if (deadPlayer == playerID)
                        PlayerDead();
                    _world.deadPlayers.Add(deadPlayer);
                }
                _world.playerCount = _world.players.Count - _world.deadPlayers.Count;
            }
        }



        /// <summary>
        /// This method Scales the objecets around the player so the gui can show whats happening in the game via screen
        /// </summary>
        /// <param name="obj">
        /// The object that we are calculating coordinates for
        /// </param>
        /// <param name="scaleX">
        /// this will be the "output" for the scaled object of x
        /// </param>
        /// <param name="scaleY">
        /// this will be the "output" for the scaled object of y
        /// </param>
        /// <param name="scaleRadius">
        /// this will be the "output" for the scaled object of the radius
        /// </param>
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

        /// <summary>
        /// The method scales the mouse from GUI screen to the actualy coordinates of the game(server) 
        /// </summary>
        /// <param name="scaleX">
        /// this will be the "output" for the scaled object of x scaled to the server
        /// </param>
        /// <param name="scaleY">
        /// this will be the "output" for the scaled object of y scaled to the server
        /// </param>
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

        /// <summary>
        /// sets the instance variable of mouseX and mouseY to the mouse coordinates in the screen 
        /// </summary>
        /// <param name="sender">
        /// object sender
        /// </param>
        /// <param name="e">
        /// contains mouse info
        /// </param>
        private void ClientGUI_MouseMove(object sender, MouseEventArgs e)
        {
            mouseX = e.X;
            mouseY = e.Y;
        }

        
        /// <summary>
        /// This method is for when the client wants to split the player by pressing space
        /// It will attempt to split by the split command
        /// </summary>
        /// <param name="sender">
        /// object sender
        /// </param>
        /// <param name="e">
        /// contains the pressed key info
        /// </param>
        private void ClientGUI_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space)
            {
                if (!playerComfirmed || playerID == -1)
                    return;
                float currMouseX = mouseX;
                float currMouseY = mouseY;
                ScaleMouse(out currMouseX, out currMouseY);

                string send = String.Format(Protocols.CMD_Split, (int)currMouseX, (int)currMouseY);
                network.Send(send);
            }
        }

        /// <summary>
        /// helper method for when the player dies it will change the GUI to prep
        /// for the client to rejoin the game
        /// </summary>
        private void PlayerDead()
        {
            _logger.LogDebug("player died");
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

        /// <summary>
        /// This method is a helper method to convert the coordinates of the mouse so the 
        /// player cant move over a certain speed
        /// </summary>
        /// <param name="value">
        /// the value of the coordinate
        /// </param>
        /// <returns>
        /// returns the converted coordinates
        /// </returns>
        private float ConvertOverFlow(float value)
        {
            if (value > SCREENWIDTH)
                return SCREENWIDTH;
            if (value < 0)
                return 0;
            else return value;

        }

        /// <summary>
        /// The GUI was somehow representing the "reverse" of the clientPlayer GUI.
        /// This method converts the coordinates of an object and puts it into a correct place.
        /// This method is very important and used for All OBJECTS(Players, food)
        /// </summary>
        /// <param name="input">
        /// input coordinate
        /// </param>
        /// <returns>
        /// return "reversed" correct coordinate
        /// </returns>
        private float Reverse(float input)
        {
            return input + (2500 - input) * 2;
        }


        /// <summary>
        /// this method is for when the client presses the enter key to attempt to connect to the desired server
        /// </summary>
        /// <param name="sender">
        /// object sender
        /// </param>
        /// <param name="e">
        /// contaions info of key press
        /// </param>
        private void server_box_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (player_name_box.Text == String.Empty || server_box.Text == String.Empty)
                {
                    return;
                }
                AttemptPlay();
            }
        }

        /// <summary>
        /// this method is for when the client presses the enter key to attempt to connect to the desired server
        /// </summary>
        /// <param name="sender">
        /// object sender
        /// </param>
        /// <param name="e">
        /// contaions info of key press
        /// </param>
        private void player_name_box_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (player_name_box.Text == String.Empty || server_box.Text == String.Empty)
                {
                    return;
                }
                playerName = player_name_box.Text.ToString();
                AttemptPlay();

            }
        }

        /// <summary>
        /// Helper method to either connect to a server or rejoin the game of the same server
        /// </summary>
        private void AttemptPlay()
        {
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
                catch (Exception ex)
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

}