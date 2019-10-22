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

        // Open file from File dropdown
        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string jsonText = File.ReadAllText(openFileDialog1.FileName);
                ZorkBuilderFile = JsonConvert.DeserializeObject<ZorkBuilderFile>(jsonText);
                ZorkBuilderFile.FileName = openFileDialog1.FileName;
            }
        }

        // Exit from File dropdown
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Print from File dropdown
        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
    }
}
