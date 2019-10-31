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
                    zorkBuilderFileBindingSource.DataSource = mCurrentFile;
                }
                //roomsBindingSource.DataSource = mCurrentFile.Game.World.Rooms;
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

                int i = 0;

                // Programatic section
                /*foreach (Common.Room room in CurrentFile.Game.World.Rooms)
                {
                    RoomListBox.Items.Add(room.Name);
                }*/
                
                //RoomListBox.SelectedIndex = 0;
                //NameTextBox.Text = RoomListBox.SelectedItem.ToString();
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
            // Programatic section
            /*string currentSelected = RoomListBox.SelectedItem.ToString();
            NameTextBox.Text = CurrentFile.Game.World.RoomsByName[currentSelected].Name;
            LookTextBox.Text = CurrentFile.Game.World.RoomsByName[currentSelected].Description;
            */
        }

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            /*string currentSelected = RoomListBox.SelectedItem.ToString();
            CurrentFile.Game.World.RoomsByName[currentSelected].Name = NameTextBox.Text;

            // Refresh section
            RoomListBox.Items.Clear();
            foreach (Common.Room room in CurrentFile.Game.World.Rooms)
            {
                RoomListBox.Items.Add(room.Name);
            }*/
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void WorldBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
