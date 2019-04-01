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
        List<Shape> shapes = new List<Shape>();

        public Form1()
        {
            Shape.AspectRatio = (float)Screen.FromControl(this).Bounds.Width / Screen.FromControl(this).Bounds.Height;
            Shape.xMult = Screen.FromControl(this).Bounds.Width / 2;
            Shape.yMult = Screen.FromControl(this).Bounds.Height / 2;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void btnRenderer_Click(object sender, EventArgs e)
        {
            using (var form = new Renderer(shapes.ToArray<Shape>())) form.ShowDialog();
        }

        private void btnFileObj_Click(object sender, EventArgs e)
        {
            ofdObjectFile.ShowDialog();
        }

        private void ofdObjectFile_FileOk(object sender, CancelEventArgs e)
        {
            Activate();
            string[] files = ofdObjectFile.FileNames;

            foreach (string file in files)
            {
                Shape newShape = new Shape(file);
                shapes.Add(newShape);
                var index = dgvObjectData.Rows.Add();
                dgvObjectData.Rows[index].Cells["colPath"].Value = newShape.Name;
                dgvObjectData.Rows[index].Cells["colVertices"].Value = newShape.NumberOfVertices;
            }
        }

        private void btnCustomObj_Click(object sender, EventArgs e)
        {
            using (var form = new frmCreateObject()) form.ShowDialog();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            var items = dgvObjectData.SelectedRows;
            if (items.Count != 0)
            {
                for (int i = items.Count - 1; i >= 0; i--)
                {
                    shapes.Remove(shapes.Find(x => x.Name == (string)items[i].Cells["colPath"].Value));
                    dgvObjectData.Rows.Remove(items[i]);
                }
            }
        }
    }
}
