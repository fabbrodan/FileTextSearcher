namespace FileTextSearcher
{
    partial class SaveFileForm
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
            this.saveFilesButton = new System.Windows.Forms.Button();
            this.dataGridViewForFiles = new System.Windows.Forms.DataGridView();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewForFiles)).BeginInit();
            this.SuspendLayout();
            // 
            // saveFilesButton
            // 
            this.saveFilesButton.Location = new System.Drawing.Point(713, 415);
            this.saveFilesButton.Name = "saveFilesButton";
            this.saveFilesButton.Size = new System.Drawing.Size(75, 23);
            this.saveFilesButton.TabIndex = 1;
            this.saveFilesButton.Text = "Save file(s)";
            this.saveFilesButton.UseVisualStyleBackColor = true;
            this.saveFilesButton.Click += new System.EventHandler(this.SaveSelectedFilesButton_Click);
            // 
            // dataGridViewForFiles
            // 
            this.dataGridViewForFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewForFiles.Location = new System.Drawing.Point(12, 25);
            this.dataGridViewForFiles.Name = "dataGridViewForFiles";
            this.dataGridViewForFiles.Size = new System.Drawing.Size(776, 384);
            this.dataGridViewForFiles.TabIndex = 2;
            this.dataGridViewForFiles.RowTemplate.Height = 20;
            this.dataGridViewForFiles.AllowUserToAddRows = false;
            this.dataGridViewForFiles.AllowUserToDeleteRows = false;
            this.dataGridViewForFiles.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewForFiles_CellContentClick);
            this.dataGridViewForFiles.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewForFiles_CellValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Click the checkbox for each file you want to save, double click on name of file to edit name or path to selct a new path ";
            // 
            // SaveFileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewForFiles);
            this.Controls.Add(this.saveFilesButton);
            this.Name = "SaveFileForm";
            this.Text = "Select files to save";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewForFiles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button saveFilesButton;
        private System.Windows.Forms.DataGridView dataGridViewForFiles;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label1;
    }
}