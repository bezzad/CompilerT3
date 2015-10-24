namespace Compiler_T3
{
    partial class About
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            this.picSite = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.picEmail = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picSite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEmail)).BeginInit();
            this.SuspendLayout();
            // 
            // picSite
            // 
            this.picSite.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picSite.Image = global::Compiler_T3.Properties.Resources.www;
            this.picSite.Location = new System.Drawing.Point(32, 181);
            this.picSite.Name = "picSite";
            this.picSite.Size = new System.Drawing.Size(184, 184);
            this.picSite.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picSite.TabIndex = 0;
            this.picSite.TabStop = false;
            this.toolTip1.SetToolTip(this.picSite, "Go to site creator program\r\nwww.Azerbaycan.ir\r\nwww.Unixe.co.cc");
            this.picSite.Click += new System.EventHandler(this.picSite_Click);
            // 
            // picEmail
            // 
            this.picEmail.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picEmail.Image = ((System.Drawing.Image)(resources.GetObject("picEmail.Image")));
            this.picEmail.Location = new System.Drawing.Point(273, 196);
            this.picEmail.Name = "picEmail";
            this.picEmail.Size = new System.Drawing.Size(162, 150);
            this.picEmail.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picEmail.TabIndex = 1;
            this.picEmail.TabStop = false;
            this.toolTip1.SetToolTip(this.picEmail, "Send Email to creator Email:\r\nBehzadkh@Hotmail.com");
            this.picEmail.Click += new System.EventHandler(this.picEmail_Click);
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BackgroundImage = global::Compiler_T3.Properties.Resources.CompilerT3;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(462, 384);
            this.Controls.Add(this.picEmail);
            this.Controls.Add(this.picSite);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "About";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About";
            this.toolTip1.SetToolTip(this, "Click to Exit About Windows");
            this.TopMost = true;
            this.Click += new System.EventHandler(this.About_Click);
            ((System.ComponentModel.ISupportInitialize)(this.picSite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEmail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picSite;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PictureBox picEmail;
    }
}