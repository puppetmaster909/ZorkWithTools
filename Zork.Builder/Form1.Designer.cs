namespace Zork.Builder
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.controlNodeEditor1 = new SampleCommon.ControlNodeEditor();
            this.SuspendLayout();
            // 
            // controlNodeEditor1
            // 
            this.controlNodeEditor1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.controlNodeEditor1.BackgroundImage = global::Zork.Builder.Properties.Resources.node_background;
            this.controlNodeEditor1.Location = new System.Drawing.Point(1, 2);
            this.controlNodeEditor1.Name = "controlNodeEditor1";
            this.controlNodeEditor1.Size = new System.Drawing.Size(796, 445);
            this.controlNodeEditor1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.controlNodeEditor1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private SampleCommon.ControlNodeEditor controlNodeEditor1;
    }
}

