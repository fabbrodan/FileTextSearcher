using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileTextSearcher
{
    public partial class Form1 : Form
    {
        private static List<ReadFile> readFiles = new List<ReadFile>();
        private static List<IList<string>> SortedWords = new List<IList<string>>();
        private static List<FileToSave> listOfFilesToSave = new List<FileToSave>();
        public Form1()
        {
            InitializeComponent();
            SelectFilesToSaveButton.Enabled = false;
        }


        //This method opens a FileDialog where you can browse and open one or multiple files.
        private void btnAddFiles_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Text files |*.txt"; // Only allows for .txt files to be opened.
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                int counter = 0;
                foreach (var item in openFileDialog.FileNames)
                {
                    try
                    {
                        string text = File.ReadAllText(item);
                        ReadFile readFile = new ReadFile(openFileDialog.FileNames[counter], text);
                        DataSorter<string> sorter = new DataSorter<string>(readFile.Words);
                        sorter.QuickSortAscending();
                        SortedWords.Add(sorter.Get());
                        readFiles.Add(readFile);
                        SelectFilesToSaveButton.Enabled = true;
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    counter++;
                }
                DisplaySortResult();
            }
        }

        /// <summary>
        /// Takes the sorted file text results and displays in a DataGridView
        /// </summary>
        private void DisplaySortResult()
        {
            //clears the data grid view every time DisplaySortResult() is called to prevent
            //it from adding every column again in addition to the already existing ones (duplicate columns) 
            dataGridView1.Columns.Clear();
            int maxNumberOfWords = 0;
            foreach (var file in readFiles)
            {
                dataGridView1.Columns.Add(new DataGridViewColumn
                {
                    HeaderText = Path.GetFileNameWithoutExtension(file.FileName),
                    CellTemplate = new DataGridViewTextBoxCell()
                });

                if (file.NumberOfWords > maxNumberOfWords)
                {
                    maxNumberOfWords = file.NumberOfWords;
                }
            }

            for (int i = 0; i < maxNumberOfWords; i++)
            {
                dataGridView1.Rows.Add(new DataGridViewRow());
            }

            for (int i = 0; i <= SortedWords.Count - 1; i++)
            {
                for (int j = 0; j < maxNumberOfWords; j++)
                {
                    try
                    {
                        dataGridView1.Rows[j].Cells[i].Value = SortedWords[i][j];
                        dataGridView1.Rows[j].Cells[i].ReadOnly = true;
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        dataGridView1.Rows[j].Cells[i].Value = "";
                        dataGridView1.Rows[j].Cells[i].ReadOnly = true;
                    }
                }
            }
        }
        private void saveFileButton_Click(object sender, EventArgs e)
        {
            FileWriter fw = new FileWriter();

            // Verify that there are files loaded
            if (readFiles.Count > 0)
            {
                // Iterate over the files loaded and save content
                foreach (ReadFile file in readFiles)
                {
                    saveFileDialog.Filter = "Text Files|*.txt";
                    //select file rather than index 0 in readFiles
                    saveFileDialog.FileName = Path.GetFileNameWithoutExtension(file.FileName);
                    saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string fullPath = saveFileDialog.FileName;
                        string fileName = Path.GetFileNameWithoutExtension(fullPath);
                        string fullDirectoryPath = Path.GetDirectoryName(fullPath);
                        //select a file rather than just index 0 in SortedWords
                        fw.SaveFile(fullDirectoryPath, fileName, file.Words);
                    }
                }
            }
            else
            {
                MessageBox.Show("No files have been loaded");
            }
        }
        /// <summary>
        /// This button calls on cleardata to clear all previous data.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearData_Click(object sender, EventArgs e)
        {
            ClearData();
        }
        /// <summary>
        /// This method clears all data from previous loaded textfiles. Also clears the datagridviews displayed data.
        /// </summary>
        private void ClearData()
        {
            readFiles.Clear();
            SortedWords.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
        }

        /// <summary>
        /// Clears the list of files to save (to prevent duplicates) and creates
        /// and adds every file to the list again and sends it to the save file form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectFilesToSaveButton_Click(object sender, EventArgs e)
        {
            //Empty list before creating new form
            listOfFilesToSave.Clear();
            for (int i = 0; i < SortedWords.Count; i++)
            {
                listOfFilesToSave.Add(new FileToSave(Path.GetDirectoryName(readFiles[i].FileName), Path.GetFileNameWithoutExtension(readFiles[i].FileName), SortedWords[i]));
            }
            SaveFileForm saveFileForm = new SaveFileForm(listOfFilesToSave);
            saveFileForm.Show();
        }
    }
}
