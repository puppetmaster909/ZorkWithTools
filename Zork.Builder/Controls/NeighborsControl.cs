using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zork.Common;

namespace Zork.Builder.Controls
{
    public partial class NeighborsControl : UserControl
    {
        private static readonly Room NoRoom = new Room() { Name = "None", Description = "None"};

        public Room NeighborRoom 
        {
            get => (Room)neighborSelectComboBox.SelectedItem;
            set => neighborSelectComboBox.SelectedItem = value;
        }

        private World mWorld;
        public World World
        {
            get => mWorld;
            set
            {
                if (mWorld != value)
                {
                    mWorld = value;
                    if (mWorld != null)
                    {
                        var rooms = new BindingList<Room>(World.Rooms);
                        rooms.Insert(0, NoRoom);
                        neighborSelectComboBox.DataSource = rooms;

                        /*if (mWorld.Rooms.TryGetValue(NeighborDirections, out Room NeighborRoom))
                        {

                        }*/

                        NeighborRoom = NoRoom;
                    }
                    else
                    {
                        neighborSelectComboBox.DataSource = null;
                    }
                }
            }
        }

        public Directions NeighborDirections
        {
            get => mNeighborDirections;
            set
            {
                mNeighborDirections = value;
                neighborDirectionTextBox.Text = mNeighborDirections.ToString();
            }
        }
        public NeighborsControl()
        {
            InitializeComponent();
        }

        private Directions mNeighborDirections;

        #region Oops

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void NorthNeighbor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        #endregion
    }
}
