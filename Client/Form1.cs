using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Form1 : Form
    {
        List<Shape> shapes;

        public Form1()
        {
            shapes = new List<Shape>();
            Shape.AspectRatio = (float)Screen.FromControl(this).Bounds.Width / Screen.FromControl(this).Bounds.Height;
            Shape.xMult = Screen.FromControl(this).Bounds.Width / 2;
            Shape.yMult = Screen.FromControl(this).Bounds.Height / 2;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var utahTeapot = new Shape("teapot-low.obj");
            utahTeapot.Rotate(180, 180, null);

            shapes.Add(utahTeapot);
        }

        private void btnRenderer_Click(object sender, EventArgs e)
        {
            new Renderer(shapes.ToArray<Shape>()).Show();
        }
    }
}
