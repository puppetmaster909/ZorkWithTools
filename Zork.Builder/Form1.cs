using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;

namespace Zork.Builder
{
    public partial class Form1 : Form
    {
        private ZorkBuilderFile ZorkBuilderFile;

        /*public ZorkBuilderFile ZorkBuilderFile
        {
            get => mZorkBuilderFile;
            set
            {

            }
        }*/

        public Form1()
        {
            InitializeComponent();
            
        }

        // Exit from File dropdown
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Print from File dropdown
        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
         if (PrintDialog.ShowDialog() == DialogResult.OK)
            {

            }   
        }

        // Open file from File dropdown
        private void OpenFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                string jsonText = File.ReadAllText(OpenFileDialog.FileName);
                ZorkBuilderFile = JsonConvert.DeserializeObject<ZorkBuilderFile>(jsonText);
                ZorkBuilderFile.FileName = OpenFileDialog.FileName;
            }
        }

        private void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        // Save from File dropdown
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        { 
                //string jsonText = 
                //SaveFileDialog.FileName = ZorkBuilderFile.FileName;
        }

        // SaveAs from File dropdown
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                //string jsonText =
                SaveFileDialog.FileName = ZorkBuilderFile.FileName;
            }
        }
    }
}
