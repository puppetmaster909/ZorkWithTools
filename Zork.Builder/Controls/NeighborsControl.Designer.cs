namespace Zork.Builder.Controls
{
    partial class NeighborsControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.NorthNeighbor = new System.Windows.Forms.ComboBox();
            this.neighborDirectionTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // NorthNeighbor
            // 
            this.NorthNeighbor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NorthNeighbor.FormattingEnabled = true;
            this.NorthNeighbor.Location = new System.Drawing.Point(3, 29);
            this.NorthNeighbor.Name = "NorthNeighbor";
            this.NorthNeighbor.Size = new System.Drawing.Size(111, 21);
            this.NorthNeighbor.TabIndex = 12;
            this.NorthNeighbor.SelectedIndexChanged += new System.EventHandler(this.NorthNeighbor_SelectedIndexChanged);
            // 
            // neighborDirectionTextBox
            // 
            this.neighborDirectionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.neighborDirectionTextBox.Location = new System.Drawing.Point(4, 4);
            this.neighborDirectionTextBox.Name = "neighborDirectionTextBox";
            this.neighborDirectionTextBox.ReadOnly = true;
            this.neighborDirectionTextBox.Size = new System.Drawing.Size(110, 20);
            this.neighborDirectionTextBox.TabIndex = 13;
            this.neighborDirectionTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // NeighborsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.neighborDirectionTextBox);
            this.Controls.Add(this.NorthNeighbor);
            this.Name = "NeighborsControl";
            this.Size = new System.Drawing.Size(118, 53);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox NorthNeighbor;
        private System.Windows.Forms.TextBox neighborDirectionTextBox;
    }
}
