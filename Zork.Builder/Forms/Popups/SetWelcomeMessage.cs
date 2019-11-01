using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zork.Builder
{
    public partial class SetWelcomeMessageForm : Form
    {
        public string WelcomeMessage 
        {
        get => WelcomeMessageTextBox.Text; 
        set => WelcomeMessageTextBox.Text = value; 
        }

        public SetWelcomeMessageForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void MessageTextBox_TextChanged(object sender, EventArgs e)
        {
            okButton.Enabled = !string.IsNullOrEmpty(WelcomeMessage);
        }
    }
}
