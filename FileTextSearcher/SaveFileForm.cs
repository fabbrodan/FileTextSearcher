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
            DisplayFilesToSave();
        }

        private void DisplayFilesToSave()
        {
            //Column for checkbox
            DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
            checkColumn.HeaderText = "Save";
            checkColumn.Width = 50;
            dataGridView1.Columns.Add(checkColumn);

            //Column for fileName
            DataGridViewColumn nameColumn = new DataGridViewColumn();
            nameColumn.HeaderText = "File name";
            nameColumn.CellTemplate = new DataGridViewTextBoxCell();
            nameColumn.Width = 250;
            dataGridView1.Columns.Add(nameColumn);

            //Column for filePath
            DataGridViewColumn pathColumn = new DataGridViewColumn();
            pathColumn.CellTemplate = new DataGridViewTextBoxCell();
            pathColumn.HeaderText = "File path";
            pathColumn.ReadOnly = true;
            pathColumn.Width = 400;
            dataGridView1.Columns.Add(pathColumn);

            //Adds rows from all available files
            if (listOfFilesToSave.Count > 0) {
                foreach (var file in listOfFilesToSave) {
                    dataGridView1.Rows.Add(false, file.name, file.path);
                }
            }
            //prevents user from adding rows by themselves
            dataGridView1.AllowUserToAddRows = false;
        }
    }
}
