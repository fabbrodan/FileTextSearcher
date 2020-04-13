using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileTextSearcher
{
    public partial class SaveFileForm : Form
    {
        private static List<FileToSave> listOfFilesToSave = new List<FileToSave>();
        public SaveFileForm()
        {
            InitializeComponent();
        }

        public SaveFileForm(List<FileToSave> listOfFiles)
        {
            InitializeComponent();
            listOfFilesToSave = listOfFiles;
            //Column for checkbox
            DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
            checkColumn.HeaderText = "Save";
            checkColumn.Width = 50;
            dataGridViewForFiles.Columns.Add(checkColumn);

            //Column for fileName
            DataGridViewColumn nameColumn = new DataGridViewColumn();
            nameColumn.HeaderText = "File name";
            nameColumn.CellTemplate = new DataGridViewTextBoxCell();
            nameColumn.Width = 250;
            dataGridViewForFiles.Columns.Add(nameColumn);

            //Column for filePath
            DataGridViewColumn pathColumn = new DataGridViewColumn();
            pathColumn.CellTemplate = new DataGridViewTextBoxCell();
            pathColumn.HeaderText = "File path";
            pathColumn.ReadOnly = true;
            pathColumn.Width = 400;
            dataGridViewForFiles.Columns.Add(pathColumn);
            //disables row height resize by setting it to a default value
            
            DisplayFilesToSave();
        }

        /// <summary>
        /// Displays all available files in the data grid
        /// </summary>
        private void DisplayFilesToSave()
        {
            //Adds rows from all available files
            if (listOfFilesToSave.Count > 0)
            {
                foreach (var file in listOfFilesToSave)
                {
                    dataGridViewForFiles.Rows.Add(false, file.name, file.path);
                }
            }
        }

        /// <summary>
        /// Refreshes the File Path column
        /// </summary>
        private void RefreshFilePathColumn()
        {
            for (int i = 0; i < listOfFilesToSave.Count; i++)
            {
                dataGridViewForFiles[2, i].Value = listOfFilesToSave[i].path;
            }
        }
        /// <summary>
        /// Refreshes the file name column
        /// </summary>
        private void RefreshFileNameColumn()
        {
            for (int i = 0; i < listOfFilesToSave.Count; i++)
            {
                dataGridViewForFiles[1, i].Value = listOfFilesToSave[i].name;
            }
        }


        /// <summary>
        /// Allows the user to change save path when double clicking on a value in the file path column
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewForFiles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //only file path column and not in header row
            if (e.RowIndex > -1 && e.ColumnIndex == 2)
            {
                folderBrowserDialog1.SelectedPath = dataGridViewForFiles.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    listOfFilesToSave[e.RowIndex].path = folderBrowserDialog1.SelectedPath.ToString();
                    RefreshFilePathColumn();
                }
            }
        }
        /// <summary>
        /// Allows the user to change the file name when double clicking on a vlue in the file name column
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewForFiles_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //only file name column and not in header row
            if (e.RowIndex > -1 && e.ColumnIndex == 1)
            {
                if (dataGridViewForFiles.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null && dataGridViewForFiles.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Length > 0)
                {
                    listOfFilesToSave[e.RowIndex].name = dataGridViewForFiles.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    RefreshFileNameColumn();
                }
                else
                {
                    MessageBox.Show("File name must be at least one character long");
                }
            }
        }

        /// <summary>
        /// Saves every selected file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveSelectedFilesButton_Click(object sender, EventArgs e)
        {
            FileWriter fw = new FileWriter();
            if (GetNumberOfSelectedFiles() > 0)
            {
                for (int i = 0; i < dataGridViewForFiles.Rows.Count; i++)
                {
                    if ((bool)dataGridViewForFiles.Rows[i].Cells[0].Value == true)
                    {
                        fw.SaveFile(dataGridViewForFiles.Rows[i].Cells[2].Value.ToString(), dataGridViewForFiles.Rows[i].Cells[1].Value.ToString(), listOfFilesToSave[i].listOfWords);
                    }
                }
                MessageBox.Show("Saved " + GetNumberOfSelectedFiles() + " file(s)");
                Dispose();
            }
            else
            {
                MessageBox.Show("Select at least one file to save");
            }
        }
        /// <summary>
        /// calculates the number of seleted files
        /// </summary>
        /// <returns></returns>
        private int GetNumberOfSelectedFiles()
        {
            int numberOfSelected = 0;

            foreach (DataGridViewRow row in dataGridViewForFiles.Rows)
            {
                if ((bool)row.Cells[0].Value == true)
                {
                    numberOfSelected++;
                }
            }
            return numberOfSelected;
        }

    }
}
