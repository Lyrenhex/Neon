namespace Client
{
    partial class frmCreateObject
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
            this.glPreview = new OpenGL.GlControl();
            this.btnSave = new System.Windows.Forms.Button();
            this.filSave = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAddVertex = new System.Windows.Forms.Button();
            this.numZ = new System.Windows.Forms.NumericUpDown();
            this.numY = new System.Windows.Forms.NumericUpDown();
            this.numX = new System.Windows.Forms.NumericUpDown();
            this.lstVertices = new System.Windows.Forms.ListBox();
            this.btnJoinVertices = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numX)).BeginInit();
            this.SuspendLayout();
            // 
            // glPreview
            // 
            this.glPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.glPreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.glPreview.ColorBits = ((uint)(24u));
            this.glPreview.DepthBits = ((uint)(0u));
            this.glPreview.Location = new System.Drawing.Point(12, 12);
            this.glPreview.MultisampleBits = ((uint)(0u));
            this.glPreview.Name = "glPreview";
            this.glPreview.Size = new System.Drawing.Size(546, 350);
            this.glPreview.StencilBits = ((uint)(0u));
            this.glPreview.TabIndex = 0;
            this.glPreview.ContextCreated += new System.EventHandler<OpenGL.GlControlEventArgs>(this.glPreview_ContextCreated);
            this.glPreview.Render += new System.EventHandler<OpenGL.GlControlEventArgs>(this.glPreview_Render);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(564, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(224, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save object";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnAddVertex);
            this.groupBox1.Controls.Add(this.numZ);
            this.groupBox1.Controls.Add(this.numY);
            this.groupBox1.Controls.Add(this.numX);
            this.groupBox1.Location = new System.Drawing.Point(564, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(224, 73);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add vertex";
            // 
            // btnAddVertex
            // 
            this.btnAddVertex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddVertex.Location = new System.Drawing.Point(5, 44);
            this.btnAddVertex.Name = "btnAddVertex";
            this.btnAddVertex.Size = new System.Drawing.Size(213, 23);
            this.btnAddVertex.TabIndex = 3;
            this.btnAddVertex.Text = "Add vertex";
            this.btnAddVertex.UseVisualStyleBackColor = true;
            this.btnAddVertex.Click += new System.EventHandler(this.btnAddVertex_Click);
            // 
            // numZ
            // 
            this.numZ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numZ.DecimalPlaces = 4;
            this.numZ.Location = new System.Drawing.Point(151, 18);
            this.numZ.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.numZ.Name = "numZ";
            this.numZ.Size = new System.Drawing.Size(67, 20);
            this.numZ.TabIndex = 2;
            // 
            // numY
            // 
            this.numY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numY.DecimalPlaces = 4;
            this.numY.Location = new System.Drawing.Point(78, 18);
            this.numY.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.numY.Name = "numY";
            this.numY.Size = new System.Drawing.Size(67, 20);
            this.numY.TabIndex = 1;
            // 
            // numX
            // 
            this.numX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numX.DecimalPlaces = 4;
            this.numX.Location = new System.Drawing.Point(5, 18);
            this.numX.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.numX.Name = "numX";
            this.numX.Size = new System.Drawing.Size(67, 20);
            this.numX.TabIndex = 0;
            // 
            // lstVertices
            // 
            this.lstVertices.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstVertices.FormattingEnabled = true;
            this.lstVertices.Location = new System.Drawing.Point(564, 120);
            this.lstVertices.Name = "lstVertices";
            this.lstVertices.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstVertices.Size = new System.Drawing.Size(224, 186);
            this.lstVertices.TabIndex = 3;
            // 
            // btnJoinVertices
            // 
            this.btnJoinVertices.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnJoinVertices.Location = new System.Drawing.Point(564, 339);
            this.btnJoinVertices.Name = "btnJoinVertices";
            this.btnJoinVertices.Size = new System.Drawing.Size(224, 23);
            this.btnJoinVertices.TabIndex = 4;
            this.btnJoinVertices.Text = "Join selected vertices";
            this.btnJoinVertices.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(564, 312);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(224, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Delete selected vertices";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // frmCreateObject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 374);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnJoinVertices);
            this.Controls.Add(this.lstVertices);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.glPreview);
            this.Name = "frmCreateObject";
            this.Text = "Create custom object";
            this.Load += new System.EventHandler(this.frmCreateObject_Load);
            this.ResizeEnd += new System.EventHandler(this.frmCreateObject_ResizeEnd);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numX)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private OpenGL.GlControl glPreview;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.SaveFileDialog filSave;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAddVertex;
        private System.Windows.Forms.NumericUpDown numZ;
        private System.Windows.Forms.NumericUpDown numY;
        private System.Windows.Forms.NumericUpDown numX;
        private System.Windows.Forms.ListBox lstVertices;
        private System.Windows.Forms.Button btnJoinVertices;
        private System.Windows.Forms.Button button1;
    }
}