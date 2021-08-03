using LargeHashClassTest;
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

namespace WinToolKit
{
    public partial class CheckSumWindow : Form
    {
        bool alreadyFocused;
        public CheckSumWindow()
        {
            InitializeComponent();
            //Sets default values for UI items
            comboBox1.SelectedIndex = 0;
            progressBar1.Visible = false;
        }

        private void textBox1_MouseUp(object sender, MouseEventArgs e)
        {
            //Selects all text in file path text box
            if (!alreadyFocused && this.textBox1.SelectionLength == 0)
            {
                alreadyFocused = true;
                textBox1.SelectAll();
            }
        }

        private void textBox1_MouseLeave(object sender, EventArgs e)
        {
            alreadyFocused = false;
        }

        private void CheckSumWindow_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Sets UI elements for loading
            progressBar1.Visible = true;
            Cursor = Cursors.WaitCursor;

            int option = comboBox1.SelectedIndex;
            string Path = textBox1.Text;
            string[] Paths = new string[1];
            var dict = new Dictionary<int, string[]>();

            //Includes or excludes subfolders depending on checkbox. Only does single file if not a directory path
            bool subfoldersEnabled = checkBoxSubfolders.Checked;
            try
            {
                //Get if directory
                var ext = System.IO.Path.GetExtension(Path);
                if (ext == String.Empty)
                {
                    //If path entered is a directory - Scans for all file
                    if (subfoldersEnabled)
                        //Scans inside subdirectories
                        Paths = Directory.GetFiles(Path, "*.*", SearchOption.AllDirectories);
                    else
                        //Ignores subdirectories
                        Paths = Directory.GetFiles(Path);
                } else
                //If the path given is a file path, it returns parses an array with only 1 file path
                {
                    Paths = new string[1] {Path};
                }
            } catch (Exception c)
            {
                //Displays error message and hides loading cursor and bar
                MessageBox.Show(c.Message);
                Cursor = Cursors.Arrow;
                progressBar1.Visible = false;
                return;
            }
            //Generates all the Checksum Values and stores it in dictionary
            dict = MultithreadingChecksumCommands.DirectorysToChecksumStringArray(Paths, option);

            //Initialises Grid window with Checksum results
            var results = new Results(dict);
            results.Show();

            //Removes Loading UI
            Cursor = Cursors.Arrow; 
            progressBar1.Visible = false;
        }
    }
}
