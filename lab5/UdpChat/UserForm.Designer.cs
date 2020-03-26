namespace Client
{
	partial class UserForm
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
			this.txtMessage = new System.Windows.Forms.TextBox();
			this.btnSend = new System.Windows.Forms.Button();
			this.txtChatBox = new System.Windows.Forms.RichTextBox();
			this.lstChatters = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// txtMessage
			// 
			this.txtMessage.Location = new System.Drawing.Point(9, 260);
			this.txtMessage.Margin = new System.Windows.Forms.Padding(2);
			this.txtMessage.Name = "txtMessage";
			this.txtMessage.Size = new System.Drawing.Size(403, 20);
			this.txtMessage.TabIndex = 1;
			this.txtMessage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMessage_KeyPress);
			// 
			// btnSend
			// 
			this.btnSend.Location = new System.Drawing.Point(415, 258);
			this.btnSend.Margin = new System.Windows.Forms.Padding(2);
			this.btnSend.Name = "btnSend";
			this.btnSend.Size = new System.Drawing.Size(107, 23);
			this.btnSend.TabIndex = 2;
			this.btnSend.Text = "Send";
			this.btnSend.UseVisualStyleBackColor = true;
			this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
			// 
			// txtChatBox
			// 
			this.txtChatBox.Location = new System.Drawing.Point(9, 8);
			this.txtChatBox.Margin = new System.Windows.Forms.Padding(2);
			this.txtChatBox.Name = "txtChatBox";
			this.txtChatBox.ReadOnly = true;
			this.txtChatBox.Size = new System.Drawing.Size(403, 238);
			this.txtChatBox.TabIndex = 3;
			this.txtChatBox.Text = "";
			// 
			// lstChatters
			// 
			this.lstChatters.FormattingEnabled = true;
			this.lstChatters.Location = new System.Drawing.Point(416, 8);
			this.lstChatters.Margin = new System.Windows.Forms.Padding(2);
			this.lstChatters.Name = "lstChatters";
			this.lstChatters.Size = new System.Drawing.Size(106, 238);
			this.lstChatters.TabIndex = 4;
			// 
			// UserForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.ClientSize = new System.Drawing.Size(533, 292);
			this.Controls.Add(this.lstChatters);
			this.Controls.Add(this.txtChatBox);
			this.Controls.Add(this.btnSend);
			this.Controls.Add(this.txtMessage);
			this.Margin = new System.Windows.Forms.Padding(2);
			this.MaximizeBox = false;
			this.Name = "UserForm";
			this.Text = "Client";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UserForm_FormClosing);
			this.Load += new System.EventHandler(this.Client_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.TextBox txtMessage;
		private System.Windows.Forms.Button btnSend;
		private System.Windows.Forms.RichTextBox txtChatBox;
		private System.Windows.Forms.ListBox lstChatters;
	}
}

