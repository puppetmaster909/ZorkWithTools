﻿using System;
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
using Zork.Builder.Controls;
using Zork.Common;

namespace Zork.Builder
{
    public partial class MainForm : Form
    {
        //public GameViewModel ViewModel { get; set; }
        private GameViewModel mViewModel;
        private bool isGameLoaded;
        public string WelcomeMessage;
        public string WorldName;

        private Dictionary<Directions, NeighborsControl> mNeighborControlMap;

        private GameViewModel ViewModel
        {
            get => mViewModel;
            set
            {
                if (mViewModel != value)
                {
                    mViewModel = value;
                    gameViewModelBindingSource.DataSource = mViewModel;
                    IsGameLoaded = mViewModel.Game != null;
                }
            }
        }

        private bool IsGameLoaded 
        { 
            get => isGameLoaded;
            set
            {
                isGameLoaded = value;
                AddRoomButton.Enabled = isGameLoaded;
                DeleteButton.Enabled = isGameLoaded;
                NameTextBox.Enabled = isGameLoaded;
                LookTextBox.Enabled = isGameLoaded;
                //NorthNeighbor.Enabled = isGameLoaded;
                //SouthNeighbor.Enabled = isGameLoaded;
                //EastNeighbor.Enabled = isGameLoaded;
                //WestNeighbor.Enabled = isGameLoaded;
                welcomeMessageToolStripMenuItem1.Enabled = isGameLoaded;
                worldNameToolStripMenuItem1.Enabled = isGameLoaded;
                printToolStripMenuItem.Enabled = isGameLoaded;
                deleteToolStripMenuItem2.Enabled = isGameLoaded;
                saveAsToolStripMenuItem.Enabled = isGameLoaded;
                saveToolStripMenuItem.Enabled = isGameLoaded;
            }
        }

        public MainForm()
        {
            InitializeComponent();
            ViewModel = new GameViewModel();
            IsGameLoaded = false;

            mNeighborControlMap = new Dictionary<Directions, NeighborsControl>
                {
                    {Directions.North, northNeighborControl},
                    {Directions.South, southNeighborControl},
                    {Directions.East, eastNeighborControl},
                    {Directions.West, westNeighborControl}
                };
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
                ViewModel.FileName = OpenFileDialog.FileName;
                ViewModel.Game = Common.Game.Load(ViewModel.FileName);
                roomsBindingSource.DataSource = ViewModel.Rooms;

                Room selectedRoom = RoomListBox.SelectedItem as Room;
                foreach (NeighborsControl control in mNeighborControlMap.Values)
                {
                    control.NeighborRoom = selectedRoom;
                }

                IsGameLoaded = true;
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
            if (string.IsNullOrEmpty(ViewModel.FileName))
            {
                throw new InvalidProgramException("Filename Expected");
            }

            JsonSerializer serializer = new JsonSerializer
            {
                Formatting = Formatting.Indented
            };
            using (StreamWriter streamWriter = new StreamWriter(ViewModel.FileName))
            using (JsonWriter jsonWriter = new JsonTextWriter(streamWriter))
            {
                serializer.Serialize(jsonWriter, ViewModel.Game);
            }
        }

        // SaveAs from File dropdown
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog.FileName = ViewModel.FileName;
            if (SaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                JsonSerializer serializer = new JsonSerializer
                {
                    Formatting = Formatting.Indented
                };
                using (StreamWriter streamWriter = new StreamWriter(SaveFileDialog.FileName))
                using (JsonWriter jsonWriter = new JsonTextWriter(streamWriter))
                {
                    serializer.Serialize(jsonWriter, ViewModel.Game);
                }
            }
        }

        private void RoomListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DeleteButton.Enabled = RoomListBox.SelectedItem != null;

            Room selectedRoom = RoomListBox.SelectedItem as Room;
            foreach (NeighborsControl control in mNeighborControlMap.Values)
            {
                control.NeighborRoom = selectedRoom;
            }
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

        private void LookTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            int selectedIndex = RoomListBox.SelectedIndex;
            ViewModel.Rooms.RemoveAt(selectedIndex);
            RoomListBox.SelectedItem = ViewModel.Rooms.FirstOrDefault();
        }

        private void AddRoomButton_Click(object sender, EventArgs e)
        {
            using (Zork.Builder.Forms.Popups.AddRoom createNewRoom = new Zork.Builder.Forms.Popups.AddRoom())
            {
                if (createNewRoom.ShowDialog() == DialogResult.OK)
                {
                    ViewModel.Rooms.Add(new Common.Room(createNewRoom.RoomName, createNewRoom.RoomDescription, new Dictionary<Common.Directions, string>()));
                }
            }

            
        }

        private void newFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewModel = new GameViewModel();
            roomsBindingSource.DataSource = ViewModel.Rooms;
        }

        /*private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }*/

        private void welcomeMessageToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (SetWelcomeMessageForm setWelcomeMessage = new SetWelcomeMessageForm())
            {
                if (setWelcomeMessage.ShowDialog() == DialogResult.OK)
                {
                    ViewModel.Game.World.WelcomeMessage = setWelcomeMessage.WelcomeMessage;
                }
            }
        }

        private void worldNameToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (Forms.Popups.SetWorldName setWorldName = new Forms.Popups.SetWorldName())
            {
                if (setWorldName.ShowDialog() == DialogResult.OK)
                {
                    ViewModel.Game.World.WorldName = setWorldName.WorldName;
                }
            }
        }

        private void deleteToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            DeleteButton_Click(sender, e);
        }
    }
}
