using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenGL;

namespace Client
{
    struct Vertex
    {
        float x, y, z;

        public Vertex(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public override string ToString()
        {
            return $"({x}, {y}, {z})";
        }
    }

    public partial class frmCreateObject : Form
    {
        private int mouseLocX1, mouseLocY1, mouseLocX2, mouseLocY2;

        private void glPreview_Render(object sender, GlControlEventArgs e)
        {

        }

        private void frmCreateObject_ResizeEnd(object sender, EventArgs e)
        {
            GlSetup();
        }

        private void glPreview_ContextCreated(object sender, GlControlEventArgs e)
        {
            GlSetup();
        }

        private void btnAddVertex_Click(object sender, EventArgs e)
        {
            lstVertices.Items.Add(new Vertex((float)numX.Value, (float)numY.Value, (float)numZ.Value));
        }

        private void GlSetup()
        {
            // set Orthogonal projection to match pixel dimensions -- treat OpenGL as primitive drawing API
            Gl.MatrixMode(MatrixMode.Projection);
            Gl.LoadIdentity();
            Gl.Ortho(0.0, glPreview.Bounds.Width, 0.0, glPreview.Bounds.Height, 0.0, 1.0);

            // switch to standard drawing mode
            Gl.MatrixMode(MatrixMode.Modelview);
            Gl.LoadIdentity();
        }

        public frmCreateObject()
        {
            InitializeComponent();
        }

        private void frmCreateObject_Load(object sender, EventArgs e)
        {

        }
    }
}
