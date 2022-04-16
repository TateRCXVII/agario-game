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
/// This was an excercise for the class 
/// </summary>
using System.Diagnostics;
using System.Numerics;
using System.Windows.Forms;

namespace TowardAgarioStepOne
{
    public partial class CirclesForm : Form
    {
        public Vector2 center;
        public Vector2 direction;
        private int count;
        private int start;
        private int end;
        private double fps;
        private Stopwatch stopwatch;

        public CirclesForm()
        {
            direction.X = -1;
            direction.Y = 1;
            this.Paint += Draw_Scene;

            var timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000 / 30;  // 1000 milliseconds in a second divided by 30 frames per second
            timer.Tick += (a, b) => this.Invalidate();

            timer.Start();
            stopwatch = Stopwatch.StartNew();

            InitializeComponent();

        }

        private void Draw_Scene(object? sender, PaintEventArgs e)
        {
            count++;
            move_circle();
            showFPS();

            SolidBrush brush = new(Color.Blue);
            SolidBrush brush2 = new(Color.Firebrick);
            Pen pen = new(new SolidBrush(Color.Black));

            e.Graphics.DrawRectangle(pen, 10, 10, 510, 510);
          //  e.Graphics.FillRectangle(brush, 10, 10, 510, 510);
            e.Graphics.FillEllipse(brush2, new Rectangle((int)center.X, (int)center.Y, 30, 30));
        }

        private void move_circle()
        {
            if (center.X < 0)
            {
                direction.X = new Random().NextInt64() % 5 + 3;
            }

            if (center.X > 499)
                direction.X = -3;

            center += direction;
            Invoke(() =>
            {
                label1.Text = $"{center.X}, {center.Y}";
            });
        }
        private void showFPS()
        {
            fps = count / stopwatch.Elapsed.TotalSeconds;
            Invoke(() => { label2.Text = fps.ToString(); });

        }

    }
}