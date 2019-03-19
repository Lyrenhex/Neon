namespace Client
{
    partial class Form1
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
            this.btnRenderer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnRenderer
            // 
            this.btnRenderer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRenderer.Location = new System.Drawing.Point(13, 35);
            this.btnRenderer.Name = "btnRenderer";
            this.btnRenderer.Size = new System.Drawing.Size(309, 23);
            this.btnRenderer.TabIndex = 3;
            this.btnRenderer.Text = "Launch renderer (dev)";
            this.btnRenderer.UseVisualStyleBackColor = true;
            this.btnRenderer.Click += new System.EventHandler(this.btnRenderer_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(317, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Placeholder until a shapes creation UI is ready to be implemented.";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 70);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRenderer);
            this.Name = "Form1";
            this.Text = "Stage 3: OpenGL rendering & translation";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnRenderer;
        private System.Windows.Forms.Label label1;
    }
}

