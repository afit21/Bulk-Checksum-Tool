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
    public partial class Results : Form
    {
        Dictionary<int, string[]> Dict = new Dictionary<int, string[]>();
        public Results(Dictionary<int, string[]> dict)
        {
            InitializeComponent();
            Dict = dict;
            foreach (KeyValuePair<int, string[]> pair in dict)
            {
                dataGridView1.Rows.Add(pair.Value[0], pair.Value[1]);
            }
        }

        private void Results_Load(object sender, EventArgs e)
        {

        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Filter = "Csv (*.csv)|*.csv";
                dialog.FilterIndex = 2;
                dialog.RestoreDirectory = true;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    System.IO.StreamWriter file = new System.IO.StreamWriter(dialog.FileName.ToString());
                    foreach (KeyValuePair<int, string[]> pair in Dict)
                    {
                        file.WriteLine(pair.Value[0] + "," + pair.Value[1]);
                    }
                    file.Close();
                    
                }
            }
        }
    }
}
