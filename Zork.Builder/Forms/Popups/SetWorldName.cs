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
    public partial class SetWorldName : Form
    {
        public string WorldName
        {
            get => WorldNameTextBox.Text;
            set => WorldNameTextBox.Text = value;
        }
        public SetWorldName()
        {
            InitializeComponent();
        }

        private void SetWorldName_Load(object sender, EventArgs e)
        {

        }

        private void WorldNameTextBox_TextChanged(object sender, EventArgs e)
        {
            okButton.Enabled = !string.IsNullOrEmpty(WorldName);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {

        }
    }
}
