using Communications;
using System.Diagnostics;

namespace ClientGUI
{
    public partial class ClientGUI : Form
    {
        private int count;
        private double fps;
        private Stopwatch stopwatch;
        private Networking network;

        public ClientGUI()
        {

            this.Paint += Draw_Scene;

            var timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000 / 30;  // 1000 milliseconds in a second divided by 30 frames per second
            timer.Tick += (a, b) => this.Invalidate();

            timer.Start();
            stopwatch = Stopwatch.StartNew();
            InitializeComponent();
        }

        private void Draw_Scene(object sender, PaintEventArgs e)
        {
            count++;
        }
    }
}