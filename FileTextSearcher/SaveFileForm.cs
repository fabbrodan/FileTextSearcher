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
            AddColumnsToDataGridView();
            DisplayFilesToSave();
        }

        /// <summary>
        /// Adds the columns to the DataGridView
        /// </summary>
        private void AddColumnsToDataGridView()
        {
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
        }

        /// <summary>
        /// Displays all available files in the data grid
        /// </summary>
        private void DisplayFilesToSave()
        {
            int rowCount = dataGridViewForFiles.Rows.Count;
            if (rowCount > 0)
            {
                for (int i = rowCount - 1; i >= 0; i--)
                {
                    dataGridViewForFiles.Rows.RemoveAt(i);
                }
            }
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
        private void DataGridViewForFiles_CellClick(object sender, DataGridViewCellEventArgs e)
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
        /// Does something whenever a user interacts with a checkbox in the Save Column
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridViewForFiles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex == 0)
            {   //Changes the value to the current values opposite, eg false -> true 
                ((DataGridViewCheckBoxCell)dataGridViewForFiles.Rows[e.RowIndex].Cells[0]).Value = !(bool)dataGridViewForFiles.Rows[e.RowIndex].Cells[0].Value;
                //Makes sure that mergBtn is only enabled if the user selected 2 or more files
                if (GetNumberOfSelectedFiles() > 1)
                {
                    mergeBtn.Enabled = true;
                }
                else
                {
                    mergeBtn.Enabled = false;
                }
                
                //Changes the select all files button value depending on how many files are selected
                if (GetNumberOfSelectedFiles() == listOfFilesToSave.Count())
                {
                    selectedAll = true;
                    selectAllFilesBtn.Text = "Unselect all files";
                }
                else
                {
                    selectedAll = false;
                    selectAllFilesBtn.Text = "Select all files";
                }
            }
        }
        /// <summary>
        /// Allows the user to change the file name when double clicking on a vlue in the file name column
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridViewForFiles_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //only file name column and not in header row
            if (e.RowIndex > -1 && e.ColumnIndex == 1)
            {
                if (dataGridViewForFiles.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null && dataGridViewForFiles.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Length > 0)
                {
                    string newCellValue = dataGridViewForFiles.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    if (newCellValue.IndexOfAny("/\\?\":|*<>".ToCharArray()) == -1)
                    {
                        listOfFilesToSave[e.RowIndex].name = newCellValue;
                        RefreshFileNameColumn();
                    }
                    else
                    {
                        dataGridViewForFiles.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = listOfFilesToSave[e.RowIndex].name;
                        MessageBox.Show("File name cannot contain the following characters: /\\?\":|*<>");
                    }
                }
                else
                {
                    dataGridViewForFiles.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = listOfFilesToSave[e.RowIndex].name;
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
        /// calculates the number of selected files
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

        /// <summary>
        /// Internal method for merging selected files and display the results
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MergeBtn_Click(object sender, EventArgs e)
        {
            // Internal list of FileToSaves
            List<FileToSave> filesToSave = new List<FileToSave>();
            string defaultPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string defaultName = "";

            if (GetNumberOfSelectedFiles() > 0)
            {
                // Iterate over all selected rows and add them as FileToSave to internal list
                foreach (DataGridViewRow selectedRow in dataGridViewForFiles.Rows)
                {
                    filesToSave.Add(new FileToSave(
                        (string)selectedRow.Cells[1].Value,
                        (string)selectedRow.Cells[2].Value,
                        listOfFilesToSave.Find(f => f.name == (string)selectedRow.Cells[1].Value).listOfWords
                        ));
                    if (defaultName == "")
                    {
                        defaultName += selectedRow.Cells[1].Value;
                    }
                    else
                    {
                        defaultName += "+" + selectedRow.Cells[1].Value;
                    }
                }
            }

            // Pass internal list to merger
            Merger merger = new Merger(filesToSave);
            var sortedMergedList = merger.Merge();
            // Sort the merged list
            DataSorter<string> sorter = new DataSorter<string>(sortedMergedList);
            sorter.QuickSortAscending();
            // Generate new FileToSave with the merged and sorted content
            FileToSave mergedFile = new FileToSave(defaultPath, defaultName, sortedMergedList);
            // Add new FileToSave obj to class list of files to save
            listOfFilesToSave.Add(mergedFile);

            // Display all new files
            DisplayFilesToSave();
        }
        ///<summary>
        /// Selects or unselects all files
        /// </summary>
        private bool selectedAll = false;
        private void SelectAllFiles_click(object sender, EventArgs e)
        {
            if (!selectedAll)
            {
                for (int i = 0; i < dataGridViewForFiles.Rows.Count; i++)
                {
                    ((DataGridViewCheckBoxCell)dataGridViewForFiles.Rows[i].Cells[0]).Value = true;
                }
                selectedAll = true;
                selectAllFilesBtn.Text = "Unselect all files";
            }
            else
            {
                for (int i = 0; i < dataGridViewForFiles.Rows.Count; i++)
                {
                    ((DataGridViewCheckBoxCell)dataGridViewForFiles.Rows[i].Cells[0]).Value = false;
                }
                selectedAll = false;
                selectAllFilesBtn.Text = "Select all files";
            }

        }
    }
}
