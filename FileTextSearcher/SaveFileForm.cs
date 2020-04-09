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
        private static List<SaveFile> listOfFilesToSave = new List<SaveFile>();
        public SaveFileForm()
        {
            InitializeComponent();
        }

        public SaveFileForm(List<SaveFile> listOfFiles)
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
            dataGridViewForFiles.RowTemplate.Height = 20;
            DisplayFilesToSave();
        }

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
            //prevents user from adding rows by themselves
            dataGridViewForFiles.AllowUserToAddRows = false;
        }

        private void RefreshFilePathColumn()
        {
            for (int i = 0; i < listOfFilesToSave.Count; i++)
            {
                dataGridViewForFiles[2, i].Value = listOfFilesToSave[i].path;
            }
        }
        private void RefreshFileNameColumn()
        {
            for (int i = 0; i < listOfFilesToSave.Count; i++)
            {
                dataGridViewForFiles[1, i].Value = listOfFilesToSave[i].name;
            }
        }

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

        private void dataGridViewForFiles_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex == 1)
            {
                listOfFilesToSave[e.RowIndex].name = dataGridViewForFiles.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                RefreshFileNameColumn();
            }
        }

        private void SaveSelectedFilesButton_Click(object sender, EventArgs e)
        {
            FileWriter fw = new FileWriter();
            for (int i = 0; i < dataGridViewForFiles.Rows.Count; i++)
            {
                if ((bool)dataGridViewForFiles.Rows[i].Cells[0].Value == true)
                {
                    fw.SaveFile(dataGridViewForFiles.Rows[i].Cells[2].Value.ToString(), dataGridViewForFiles.Rows[i].Cells[1].Value.ToString(), listOfFilesToSave[i].listOfWords);
                }
            }
            Close();
        }
    }
}
