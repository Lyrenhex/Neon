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
            this.dgvObjectData = new System.Windows.Forms.DataGridView();
            this.colPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVertices = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpNewObject = new System.Windows.Forms.GroupBox();
            this.btnFileObj = new System.Windows.Forms.Button();
            this.btnCustomObj = new System.Windows.Forms.Button();
            this.ofdObjectFile = new System.Windows.Forms.OpenFileDialog();
            this.btnRemove = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvObjectData)).BeginInit();
            this.grpNewObject.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRenderer
            // 
            this.btnRenderer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRenderer.Location = new System.Drawing.Point(13, 305);
            this.btnRenderer.Name = "btnRenderer";
            this.btnRenderer.Size = new System.Drawing.Size(512, 23);
            this.btnRenderer.TabIndex = 3;
            this.btnRenderer.Text = "Render objects in 3D Space";
            this.btnRenderer.UseVisualStyleBackColor = true;
            this.btnRenderer.Click += new System.EventHandler(this.btnRenderer_Click);
            // 
            // dgvObjectData
            // 
            this.dgvObjectData.AllowUserToAddRows = false;
            this.dgvObjectData.AllowUserToDeleteRows = false;
            this.dgvObjectData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvObjectData.BackgroundColor = System.Drawing.Color.White;
            this.dgvObjectData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvObjectData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvObjectData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPath,
            this.colVertices});
            this.dgvObjectData.GridColor = System.Drawing.Color.Black;
            this.dgvObjectData.Location = new System.Drawing.Point(160, 12);
            this.dgvObjectData.Name = "dgvObjectData";
            this.dgvObjectData.ReadOnly = true;
            this.dgvObjectData.RowHeadersVisible = false;
            this.dgvObjectData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvObjectData.Size = new System.Drawing.Size(365, 277);
            this.dgvObjectData.TabIndex = 4;
            // 
            // colPath
            // 
            this.colPath.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colPath.HeaderText = "File Path";
            this.colPath.Name = "colPath";
            this.colPath.ReadOnly = true;
            // 
            // colVertices
            // 
            this.colVertices.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colVertices.HeaderText = "Number of Vertices";
            this.colVertices.Name = "colVertices";
            this.colVertices.ReadOnly = true;
            // 
            // grpNewObject
            // 
            this.grpNewObject.Controls.Add(this.btnFileObj);
            this.grpNewObject.Controls.Add(this.btnCustomObj);
            this.grpNewObject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grpNewObject.Location = new System.Drawing.Point(13, 13);
            this.grpNewObject.Name = "grpNewObject";
            this.grpNewObject.Size = new System.Drawing.Size(141, 78);
            this.grpNewObject.TabIndex = 6;
            this.grpNewObject.TabStop = false;
            this.grpNewObject.Text = "Add new object";
            // 
            // btnFileObj
            // 
            this.btnFileObj.Location = new System.Drawing.Point(6, 15);
            this.btnFileObj.Name = "btnFileObj";
            this.btnFileObj.Size = new System.Drawing.Size(128, 25);
            this.btnFileObj.TabIndex = 3;
            this.btnFileObj.Text = "Add objects from file";
            this.btnFileObj.UseVisualStyleBackColor = true;
            this.btnFileObj.Click += new System.EventHandler(this.btnFileObj_Click);
            // 
            // btnCustomObj
            // 
            this.btnCustomObj.Location = new System.Drawing.Point(7, 46);
            this.btnCustomObj.Name = "btnCustomObj";
            this.btnCustomObj.Size = new System.Drawing.Size(128, 25);
            this.btnCustomObj.TabIndex = 2;
            this.btnCustomObj.Text = "Add new custom object";
            this.btnCustomObj.UseVisualStyleBackColor = true;
            this.btnCustomObj.Click += new System.EventHandler(this.btnCustomObj_Click);
            // 
            // ofdObjectFile
            // 
            this.ofdObjectFile.DefaultExt = "obj";
            this.ofdObjectFile.FileName = "teapot.obj";
            this.ofdObjectFile.Filter = "Object files|*.obj";
            this.ofdObjectFile.Multiselect = true;
            this.ofdObjectFile.Title = "Open object file";
            this.ofdObjectFile.FileOk += new System.ComponentModel.CancelEventHandler(this.ofdObjectFile_FileOk);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(13, 97);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(141, 23);
            this.btnRemove.TabIndex = 7;
            this.btnRemove.Text = "Remove selected objects";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(537, 340);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.grpNewObject);
            this.Controls.Add(this.dgvObjectData);
            this.Controls.Add(this.btnRenderer);
            this.Name = "Form1";
            this.Text = "Stage 3: OpenGL rendering & translation";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvObjectData)).EndInit();
            this.grpNewObject.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnRenderer;
        private System.Windows.Forms.DataGridView dgvObjectData;
        private System.Windows.Forms.GroupBox grpNewObject;
        private System.Windows.Forms.Button btnCustomObj;
        private System.Windows.Forms.Button btnFileObj;
        private System.Windows.Forms.OpenFileDialog ofdObjectFile;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPath;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVertices;
    }
}

