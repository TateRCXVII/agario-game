using AgarioModels;
using Communications;
using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Text.Json;

namespace ClientGUI
{
    public partial class ClientGUI : Form
    {
        private int count;
        private Stopwatch stopwatch;
        readonly Networking network;
        private World _world;
        private int _fps;

        public ILogger<ClientGUI> _logger;

        public ClientGUI(ILogger<ClientGUI> logger)
        {

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
            network = new Networking(_logger, onConnect, onDisconnect, onMessage, '\n');
        }

        private void Draw_Players(object? sender, PaintEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void Draw_Food(object? sender, PaintEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void Draw_World(object? sender, PaintEventArgs e)
        {
            count++;
            Brush worldBrush = new SolidBrush(Color.FromArgb(100, 0, 0, 0));
            e.Graphics.FillRectangle(worldBrush, _world.Rectangle);
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


        static void onConnect(Networking network)
        {

        }


        static void onDisconnect(Networking network)
        {

        }


        static void onMessage(Networking network, string message)
        {
            string[] he = message.Split("\n");

            string stuff = Command(he);
            /*food = JsonSerializer.Deserialize<ConcurrentBag<Food>>(stuff); //TODO: How will we add food to world object?
            foreach (AgarioModels.Food food in foodList)
            {
                Console.WriteLine(food);
            }*/
        }

        /// <summary>
        /// Helper method to process the protocol commands and output the rest of the command
        /// </summary>
        /// <param name="command">input command</param>
        /// <returns>the parsed input command</returns>
        static string Command(string[] command)
        {
            foreach (string s in command)
            {
                if (s.StartsWith(Protocols.CMD_Food))
                {
                    return s.Substring(Protocols.CMD_Food.Length);
                }
                if (s.StartsWith(Protocols.CMD_Eaten_Food))
                {
                    return s.Substring(Protocols.CMD_Eaten_Food.Length);
                }
                if (s.StartsWith(Protocols.CMD_HeartBeat))
                {
                    return s.Substring(Protocols.CMD_HeartBeat.Length);
                }
                if (s.StartsWith(Protocols.CMD_Move))
                {
                    return s.Substring(Protocols.CMD_Move.Length);
                }
                if (s.StartsWith(Protocols.CMD_Split))
                {
                    return s.Substring(Protocols.CMD_Split.Length);
                }
                if (s.StartsWith(Protocols.CMD_Split_Recognizer))
                {
                    return s.Substring(Protocols.CMD_Split_Recognizer.Length);
                }
                if (s.StartsWith(Protocols.CMD_Start_Game))
                {
                    return s.Substring(Protocols.CMD_Start_Game.Length);
                }
                if (s.StartsWith(Protocols.CMD_Start_Recognizer))
                {
                    return s.Substring(Protocols.CMD_Start_Recognizer.Length);
                }
                if (s.StartsWith(Protocols.CMD_Move_Recognizer))
                {
                    return s.Substring(Protocols.CMD_Move_Recognizer.Length);
                }
                if (s.StartsWith(Protocols.CMD_Update_Players))
                {
                    return s.Substring(Protocols.CMD_Update_Players.Length);
                }
                if (s.StartsWith(Protocols.CMD_Player_Object))
                {
                    return s.Substring(Protocols.CMD_Player_Object.Length);
                }
                if (s.StartsWith(Protocols.CMD_Dead_Players))
                {
                    return s.Substring(Protocols.CMD_Dead_Players.Length);
                }
            }
            return "";
        }
    }
}