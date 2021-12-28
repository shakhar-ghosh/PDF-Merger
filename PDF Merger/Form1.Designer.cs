namespace PDF_Merger
{
    partial class MainForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.AddFiles = new System.Windows.Forms.Button();
            this.MakePDF = new System.Windows.Forms.Button();
            this.SelectedItemsList = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(107, 169);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select files to start the process";
            // 
            // AddFiles
            // 
            this.AddFiles.Location = new System.Drawing.Point(140, 198);
            this.AddFiles.Name = "AddFiles";
            this.AddFiles.Size = new System.Drawing.Size(75, 23);
            this.AddFiles.TabIndex = 1;
            this.AddFiles.Text = "Add File(s)";
            this.AddFiles.UseVisualStyleBackColor = true;
            this.AddFiles.Click += new System.EventHandler(this.AddFiles_Click);
            // 
            // MakePDF
            // 
            this.MakePDF.Location = new System.Drawing.Point(140, 243);
            this.MakePDF.Name = "MakePDF";
            this.MakePDF.Size = new System.Drawing.Size(75, 23);
            this.MakePDF.TabIndex = 2;
            this.MakePDF.Text = "Make PDF";
            this.MakePDF.UseVisualStyleBackColor = true;
            this.MakePDF.Click += new System.EventHandler(this.MakePDF_Click);
            // 
            // SelectedItemsList
            // 
            this.SelectedItemsList.AllowDrop = true;
            this.SelectedItemsList.FormattingEnabled = true;
            this.SelectedItemsList.Location = new System.Drawing.Point(316, 42);
            this.SelectedItemsList.Name = "SelectedItemsList";
            this.SelectedItemsList.Size = new System.Drawing.Size(489, 604);
            this.SelectedItemsList.TabIndex = 3;
            this.SelectedItemsList.DragDrop += new System.Windows.Forms.DragEventHandler(this.SelectedItemsList_DragDrop);
            this.SelectedItemsList.DragOver += new System.Windows.Forms.DragEventHandler(this.SelectedItemsList_DragOver);
            this.SelectedItemsList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SelectedItemsList_MouseDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(492, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Drag and Drop to reorder items";
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 663);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SelectedItemsList);
            this.Controls.Add(this.MakePDF);
            this.Controls.Add(this.AddFiles);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "PDF Merger";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button AddFiles;
        private System.Windows.Forms.Button MakePDF;
        private System.Windows.Forms.CheckedListBox SelectedItemsList;
        private System.Windows.Forms.Label label2;
    }
}

