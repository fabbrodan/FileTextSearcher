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
                        readFiles.Add(readFile);
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    counter++;
                }
            }
        }
    }
}
