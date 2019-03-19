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
    public partial class Renderer : Form
    {
        Shape[] shapes;
        Shape[] shapesProjected;
        Rectangle screenBounds = new Rectangle(0, 0, 1920, 1080);

        const int TIMER_DELAY = 16;

        // holder for which pixel (x_origin, y_origin) is at the center of the screen, to allow for perspective projection
        int x_origin, y_origin;

        // define WASD key controls -- could always change this later
        Keys forwardKey = Keys.W;
        Keys backwardKey = Keys.S;
        Keys strafeLeftKey = Keys.A;
        Keys strafeRightKey = Keys.D;
        Keys jumpKey = Keys.Space;
        Keys exitKey = Keys.Escape;

        // flags to manage keystate -- had to be abstracted as holding key causes Windows to spam the KeyDown event
        bool isForwardKeyActive = false;
        bool isBackwardKeyActive = false;
        bool isStrafeLeftKeyActive = false;
        bool isStrafeRightKeyActive = false;
        bool isJumpKeyActive = false;

        // flag to manage whether currently jumping (this only applies to the 'rising' stage)
        // falling handles as part of main tmrLoop process
        bool isJumpingUp = false;

        // acceleration constants for movement and for gravity
        const float base_acceleration_horizontal = 1.0f;
        const float base_acceleration_vertical = 9.81f;

        // holders for effective acceleration to avoid recalculating constantly
        float actual_acceleration_horizontal;
        float actual_acceleration_vertical;

        // variables to keep track of movement velocity
        // NB. this velocity affects movement of *objects* - which is inverse to perceived movement of user
        float velocity_x = 0.0f;
        float velocity_y = 0.0f;
        float velocity_z = 0.0f;

        public Renderer(Shape[] shapes)
        {
            this.shapes = shapes;
            this.shapesProjected = new Shape[this.shapes.Length];
            for (int i = 0; i < this.shapes.Length; i++)
            {
                shapesProjected[i] = shapes[i].Project();
            }
            InitializeComponent();
        }

        private void Renderer_Load(object sender, EventArgs e)
        {
            actual_acceleration_horizontal = base_acceleration_horizontal / TIMER_DELAY;
            actual_acceleration_vertical = base_acceleration_vertical / TIMER_DELAY;
            screenBounds = Screen.FromControl(this).Bounds;
            x_origin = screenBounds.Width / 2;
            y_origin = screenBounds.Height / 2;
            Location = new Point(screenBounds.X, screenBounds.Y);
            Size = new Size(screenBounds.Width, screenBounds.Height);

            BackgroundWorker ticker = new BackgroundWorker();
            ticker.DoWork += new DoWorkEventHandler(ticker_doWork);
            ticker.RunWorkerAsync();
        }

        private void ticker_doWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                // deceleration
                if (!(isForwardKeyActive || isBackwardKeyActive) && (velocity_z != 0.0f))
                {
                    if (velocity_z < 0.0f) velocity_z += actual_acceleration_horizontal;
                    else velocity_z -= actual_acceleration_horizontal;
                }
                if (!(isStrafeLeftKeyActive || isStrafeRightKeyActive) && (velocity_x != 0.0f))
                {
                    if (velocity_x < 0.0f) velocity_x += actual_acceleration_horizontal;
                    else velocity_x -= actual_acceleration_horizontal;
                }

                // acceleration
                if (isForwardKeyActive) velocity_z -= actual_acceleration_horizontal;
                if (isBackwardKeyActive) velocity_z += actual_acceleration_horizontal;
                if (isStrafeLeftKeyActive) velocity_x += actual_acceleration_horizontal;
                if (isStrafeRightKeyActive) velocity_x -= actual_acceleration_horizontal;

                foreach (var shape in shapes)
                {
                    shape.Rotate(0.13f, null, 1.0f);
                    shape.Translate(velocity_x, velocity_y, velocity_z);
                }

                for (int i = 0; i < this.shapes.Length; i++)
                {
                    shapesProjected[i] = shapes[i].Project();
                }

                glRenderer.Invalidate();

                System.Threading.Thread.Sleep(TIMER_DELAY);
            }
        }

        private void Renderer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == exitKey) Close();

            if (e.KeyCode == forwardKey) isForwardKeyActive = true;
            if (e.KeyCode == backwardKey) isBackwardKeyActive = true;
            if (e.KeyCode == strafeLeftKey) isStrafeLeftKeyActive = true;
            if (e.KeyCode == strafeRightKey) isStrafeRightKeyActive = true;
            if (e.KeyCode == jumpKey) isJumpKeyActive = true;
            e.Handled = true;
        }

        private void Renderer_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == forwardKey) isForwardKeyActive = false;
            if (e.KeyCode == backwardKey) isBackwardKeyActive = false;
            if (e.KeyCode == strafeLeftKey) isStrafeLeftKeyActive = false;
            if (e.KeyCode == strafeRightKey) isStrafeRightKeyActive = false;
            if (e.KeyCode == jumpKey) isJumpKeyActive = false;
            e.Handled = true;
        }

        private void glRenderer_ContextCreated(object sender, GlControlEventArgs e)
        {
            // set Orthogonal projection to match pixel dimensions -- treat OpenGL as primitive drawing API
            Gl.MatrixMode(MatrixMode.Projection);
            Gl.LoadIdentity();
            Gl.Ortho(0.0, (float)screenBounds.Width, 0.0, screenBounds.Height, 0.0, 1.0);

            // switch to standard drawing mode
            Gl.MatrixMode(MatrixMode.Modelview);
            Gl.LoadIdentity();

            // enable anti-aliasing
            Gl.Enable(EnableCap.LineSmooth);
            Gl.LineWidth(1.5f);
            Gl.Enable(EnableCap.Blend);
            Gl.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);
            Gl.DepthMask(false);
            Gl.Hint(HintTarget.LineSmoothHint, HintMode.Nicest);
        }

        private void glRenderer_Render(object sender, GlControlEventArgs e)
        {
            Gl.Viewport(0, 0, screenBounds.Width, screenBounds.Height);
            Gl.Clear(ClearBufferMask.ColorBufferBit);

            foreach (var projection in shapesProjected)
            {
                // keep track of points we've visited during the traversal to avoid double-drawing lines
                List<int> visitedPoints = new List<int>();
                // breadth-first graph traversal (to draw each connection sequentially) 
                for (int point = 0; point < projection.NumberOfVertices; point++)
                {
                    visitedPoints.Add(point);
                    foreach (var iPoint in projection.VertexGraph.GetConnectedVertices(point))
                    {
                        if (visitedPoints.Contains(iPoint)) continue;
                        // calculate starting and ending points as cartesian coordinates from the relative positioning
                        // as these coordinates are pixels, round to nearest int.
                        int x_start = x_origin + (int)Math.Round(projection.Vertices.Elements[0, point], 0);
                        int y_start = y_origin - (int)Math.Round(projection.Vertices.Elements[1, point], 0);
                        float z_start = projection.Vertices.Elements[2, point];
                        int x_end = x_origin + (int)Math.Round(projection.Vertices.Elements[0, iPoint], 0);
                        int y_end = y_origin - (int)Math.Round(projection.Vertices.Elements[1, iPoint], 0);
                        float z_end = projection.Vertices.Elements[2, iPoint];

                        if ((x_start >= 0 - x_origin || x_end >= 0 - y_origin) && (y_start >= 0 - y_origin || y_end >= 0 - y_origin) && (z_start >= 0.0f && z_end >= 0.0f))
                        {
                            Gl.Begin(PrimitiveType.Lines);
                            // OpenGL.Net does not like RGB in int overload?
                            Gl.Color3(0.0f, 0.6f, 1.0f);
                            Gl.Vertex2(x_start, y_start);
                            Gl.Vertex2(x_end, y_end);
                            Gl.End();
                        }
                    }
                }
            }
        }
    }
}
