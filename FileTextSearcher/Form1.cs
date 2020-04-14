using SearchClassLibrary;
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
        private static bool asc = true;
        public Form1()
        {
            InitializeComponent();

        }


        //This method opens a FileDialog where you can browse and open one or multiple files.
        private void BtnAddFiles_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Text files |*.txt"; // Only allows for .txt files to be opened.
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            openFileDialog.FileName = string.Empty;
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
                        btnSelectFilesToSave.Enabled = true;
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    counter++;
                }
                searchInputField.Enabled = true;
                btnClearData.Enabled = true;
                btnAscDesc.Enabled = true;

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


        /// <summary>
        /// This button calls on cleardata to clear all previous data.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnClearData_Click(object sender, EventArgs e)
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
            btnClearData.Enabled = false;
            searchInputField.Enabled = false;
            searchInputField.Text = string.Empty;
            resultSearch.Text = string.Empty;
            btnSelectFilesToSave.Enabled = false;
            btnAscDesc.Enabled = false;
        }

        /// <summary>
        /// Clears the list of files to save (to prevent duplicates) and creates
        /// and adds every file to the list again and sends it to the save file form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSelectFilesToSave_Click(object sender, EventArgs e)
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

        //Variable for searched word
        private string word;
        //Textbox for entering a word
        private void SearchInputField_TextChanged(object sender, EventArgs e)
        {
            btn_Search.Enabled = true;
            word = searchInputField.Text;
        }

        //Searches the files for the given word when button is clicked
        //Displays filename and result in a textbox
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            //When the search button is clicked, textbox will be cleared and new serach result displayed
            resultSearch.Text = string.Empty;
            string resultString = string.Empty;

            SearchClass search = new SearchClass();

            if (searchInputField.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please enter a valid input");
                searchInputField.Text = string.Empty;
                searchInputField.Focus();
                btn_Search.Enabled = false;
            }

            else if (word.Length > 0)
            {
                // List to sort for results
                List<SearchResult> resultList = new List<SearchResult>();

                //Loop file/files to get filename and count of matches for the searched word
                for (int i = 0; i < SortedWords.Count; i++)
                {
                    var wordCount = search.MatchOnSearchedWord(SortedWords[i], word);
                    var fileName = Path.GetFileNameWithoutExtension(readFiles[i].FileName);

                    resultList.Add(new SearchResult(fileName, wordCount));
                }

                // Sort results using the standard CompareTo praxis
                resultList.Sort();

                // Iterate over the sorted results and write out
                foreach (var result in resultList)
                {
                    resultString += "\nThe searched word '" + word + "' was found " + result.MatchCount + " times in File: " + result.FileName + " \r";
                }
            }
            resultSearch.Text = resultString;
            //Cleares search textbox after each search
            searchInputField.Text = string.Empty;
            btn_Search.Enabled = false;
        }
        /// <summary>
        /// This button swaps the sorted list from ascending to descending
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAscDesc_Click(object sender, EventArgs e)
        {
            SortedWords.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            if (asc)
            {
                foreach (var item in readFiles)
                {
                    DataSorter<string> sorter = new DataSorter<string>(item.Words);
                    sorter.QuickSortDescending();
                    SortedWords.Add(sorter.Get());
                }
                asc = false;
            }
            else
            {
                foreach (var item in readFiles)
                {
                    DataSorter<string> sorter = new DataSorter<string>(item.Words);
                    sorter.QuickSortAscending();
                    SortedWords.Add(sorter.Get());
                }
                asc = true;
            }
            DisplaySortResult();
        }

        private void searchInputField_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnSearch_Click(this, new EventArgs());
            }
        }
    }

    /// <summary>
    /// Object to handle search results.
    /// </summary>
    /// <remarks>
    /// Needs to implement IComparable for the purpose of sorting lists
    /// </remarks>
    internal class SearchResult : IComparable
    {
        public string FileName { get; set; }
        public int MatchCount { get; set; }

        public SearchResult(string Filename, int MatchCount)
        {
            this.FileName = Filename;
            this.MatchCount = MatchCount;
        }

        public int CompareTo(object obj)
        {
            if (obj is SearchResult r)
            {
                if (r.MatchCount > this.MatchCount)
                {
                    return 1;
                }
                else if (r.MatchCount < this.MatchCount)
                {
                    return -1;
                }
                return 0;
            }

            return -99;
        }
    }
}
