using AgarioModels;
using Communications;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace ClientGUI
{
    public partial class ClientGUI : Form
    {
        private int count;
        private double fps;
        private Stopwatch stopwatch;
        private Networking network;
        private World _world;

        public ILogger<ClientGUI> _logger;

        public ClientGUI(ILogger<ClientGUI> logger)
        {

            this.Paint += Draw_World;
            this.Paint += Draw_Food;
            this.Paint += Draw_Players;

            /*var timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000 / 30;  // 1000 milliseconds in a second divided by 30 frames per second
            timer.Tick += (a, b) => this.Invalidate();

            timer.Start();
            stopwatch = Stopwatch.StartNew();*/
            InitializeComponent();

            _logger = logger;

            _world = new World(_logger);
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
        }
    }
}