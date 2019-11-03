using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zork.Builder.Forms.Popups
{
    public partial class AddRoom : Form
    {
        public string RoomName
        {
            get => RoomNameTextbox.Text;
            set => RoomNameTextbox.Text = value;
        }

        public string RoomDescription
        {
            get => RoomDescriptionTextbox.Text;
            set => RoomDescriptionTextbox.Text = value;
        }
        public AddRoom()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void AddRoom_Load(object sender, EventArgs e)
        {

        }

        private void RoomNameTextbox_TextChanged(object sender, EventArgs e)
        {
            okButton.Enabled = (!string.IsNullOrEmpty(RoomName) && !string.IsNullOrEmpty(RoomDescription));
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            
        }

        private void RoomDescriptionTextbox_TextChanged(object sender, EventArgs e)
        {
            okButton.Enabled = (!string.IsNullOrEmpty(RoomName) && !string.IsNullOrEmpty(RoomDescription));
        }
    }
}
