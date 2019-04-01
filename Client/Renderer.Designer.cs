namespace Client
{
    partial class Renderer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.glRenderer = new OpenGL.GlControl();
            this.SuspendLayout();
            // 
            // glRenderer
            // 
            this.glRenderer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.glRenderer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.glRenderer.ColorBits = ((uint)(24u));
            this.glRenderer.DepthBits = ((uint)(0u));
            this.glRenderer.Location = new System.Drawing.Point(0, 0);
            this.glRenderer.MultisampleBits = ((uint)(0u));
            this.glRenderer.Name = "glRenderer";
            this.glRenderer.Size = new System.Drawing.Size(800, 450);
            this.glRenderer.StencilBits = ((uint)(0u));
            this.glRenderer.TabIndex = 1;
            this.glRenderer.ContextCreated += new System.EventHandler<OpenGL.GlControlEventArgs>(this.glRenderer_ContextCreated);
            this.glRenderer.Render += new System.EventHandler<OpenGL.GlControlEventArgs>(this.glRenderer_Render);
            this.glRenderer.Load += new System.EventHandler(this.glRenderer_Load);
            // 
            // Renderer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.glRenderer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "Renderer";
            this.Text = "Renderer";
            this.Load += new System.EventHandler(this.Renderer_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Renderer_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Renderer_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion
        private OpenGL.GlControl glRenderer;
    }
}