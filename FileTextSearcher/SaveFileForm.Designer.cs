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
            this.mergeBtn = new System.Windows.Forms.Button();
            this.instructionLabel = new System.Windows.Forms.Label();
            this.selectAllFilesBtn = new System.Windows.Forms.Button();
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
            this.dataGridViewForFiles.AllowUserToAddRows = false;
            this.dataGridViewForFiles.AllowUserToDeleteRows = false;
            this.dataGridViewForFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewForFiles.Location = new System.Drawing.Point(12, 25);
            this.dataGridViewForFiles.Name = "dataGridViewForFiles";
            this.dataGridViewForFiles.RowTemplate.Height = 20;
            this.dataGridViewForFiles.Size = new System.Drawing.Size(776, 384);
            this.dataGridViewForFiles.TabIndex = 2;
            this.dataGridViewForFiles.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewForFiles_CellClick);
            this.dataGridViewForFiles.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewForFiles_CellContentClick);
            this.dataGridViewForFiles.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewForFiles_CellValueChanged);
            // 
            // mergeBtn
            // 
            this.mergeBtn.Location = new System.Drawing.Point(528, 415);
            this.mergeBtn.Name = "mergeBtn";
            this.mergeBtn.Size = new System.Drawing.Size(75, 23);
            this.mergeBtn.TabIndex = 4;
            this.mergeBtn.Text = "Merge Files";
            this.mergeBtn.UseVisualStyleBackColor = true;
            this.mergeBtn.Click += new System.EventHandler(this.MergeBtn_Click);
            this.mergeBtn.Enabled = false;
            // 
            // instructionLabel
            // 
            this.instructionLabel.AutoSize = true;
            this.instructionLabel.Location = new System.Drawing.Point(12, 9);
            this.instructionLabel.Name = "instructionLabel";
            this.instructionLabel.Size = new System.Drawing.Size(574, 13);
            this.instructionLabel.TabIndex = 3;
            this.instructionLabel.Text = "Click the checkbox for each file you want to save, double click on name of file t" +
    "o edit name or path to select a new path ";
            // 
            // selectAllFilesBtn
            // 
            this.selectAllFilesBtn.Location = new System.Drawing.Point(609, 415);
            this.selectAllFilesBtn.Name = "selectAllFilesBtn";
            this.selectAllFilesBtn.Size = new System.Drawing.Size(98, 23);
            this.selectAllFilesBtn.TabIndex = 4;
            this.selectAllFilesBtn.Text = "Select all files";
            this.selectAllFilesBtn.UseVisualStyleBackColor = true;
            this.selectAllFilesBtn.Click += new System.EventHandler(this.SelectAllFiles_click);
            // 
            // SaveFileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mergeBtn);
            this.Controls.Add(this.selectAllFilesBtn);
            this.Controls.Add(this.instructionLabel);
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
        private System.Windows.Forms.Button mergeBtn;
        private System.Windows.Forms.Label instructionLabel;
        private System.Windows.Forms.Button selectAllFilesBtn;
    }
}