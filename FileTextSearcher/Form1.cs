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
        public Form1()
        {
            InitializeComponent();
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
