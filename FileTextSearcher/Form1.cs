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
        public Form1()
        {
            InitializeComponent();
        }


        //This method opens a FileDialog where you can browse and open one or multiple files.
        private void btnAddFiles_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Text files |*.txt"; // Only allows for .txt files to be opened.
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

            for (int i = 0; i <= SortedWords.Count -1; i++)
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
            List<string> tempList = CreateNewList();

            saveFileDialog.Filter = "txt files (*.txt)|*.txt";
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fullPath = saveFileDialog.FileName;
                string fileName = Path.GetFileNameWithoutExtension(fullPath);
                string fullDirectoryPath = Path.GetDirectoryName(fullPath);
                fw.SaveFile(fullDirectoryPath, fileName, tempList);
            }
        }

        public List<string> CreateNewList()
        {
            List<string> listToReturn = new List<string>();
            Random rnd = new Random();
            int numberOfWords = rnd.Next(1, 1000);
            Random rndWord = new Random();
            while (numberOfWords > 0)
            {
                int lengthOfTempWord = 20;
                string tempStringToAddToList = "";
                for (var i = 0; i < lengthOfTempWord; i++)
                {
                    tempStringToAddToList += ((char)(rndWord.Next(1, 26) + 64)).ToString();
                }
                listToReturn.Add(tempStringToAddToList);
                numberOfWords--;
            }
            return listToReturn;
        }
    }
}
