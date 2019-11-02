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
