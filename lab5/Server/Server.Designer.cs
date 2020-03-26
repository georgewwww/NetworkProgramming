namespace Server
{
    partial class Server
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
			this.txtUsers = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// txtUsers
			// 
			this.txtUsers.BackColor = System.Drawing.SystemColors.Info;
			this.txtUsers.Location = new System.Drawing.Point(8, 8);
			this.txtUsers.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.txtUsers.Multiline = true;
			this.txtUsers.Name = "txtUsers";
			this.txtUsers.ReadOnly = true;
			this.txtUsers.Size = new System.Drawing.Size(245, 201);
			this.txtUsers.TabIndex = 0;
			// 
			// Server
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.ClientSize = new System.Drawing.Size(260, 215);
			this.Controls.Add(this.txtUsers);
			this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.MaximizeBox = false;
			this.Name = "Server";
			this.Text = "Server";
			this.Load += new System.EventHandler(this.Server_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUsers;
    }
}

