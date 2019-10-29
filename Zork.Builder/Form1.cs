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
        private ZorkBuilderFile mCurrentFile;

        public ZorkBuilderFile CurrentFile
        {
            get => mCurrentFile;
            set
            {
                if (mCurrentFile != value)
                {
                    mCurrentFile = value;
                    //zorkBuilderBindingSource.DataSource = mZorkBuilderFile;
                }
            }
        }

        public Form1()
        {
            InitializeComponent();
            CurrentFile = new ZorkBuilderFile();
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
                CurrentFile.FileName = OpenFileDialog.FileName;
                CurrentFile.Game = Common.Game.Load(CurrentFile.FileName);
                foreach (Common.Room room in CurrentFile.Game.World.Rooms)
                {
                    CurrentFile.Rooms.Add(room);
                    RoomListBox.Items.Add(room.Name);
                }
                int i = 0;
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
                SaveFileDialog.FileName = CurrentFile.FileName;
            }
        }

        private void RoomListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            NameTextBox.Text = RoomListBox.SelectedItem.ToString();
        }
    }
}
