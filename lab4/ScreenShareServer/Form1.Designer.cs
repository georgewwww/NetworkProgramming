namespace ScreenShareServer
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
			this.txtPort = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnListen = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// txtPort
			// 
			this.txtPort.BackColor = System.Drawing.SystemColors.Desktop;
			this.txtPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtPort.Font = new System.Drawing.Font("Consolas", 13.2F);
			this.txtPort.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.txtPort.Location = new System.Drawing.Point(163, 73);
			this.txtPort.Name = "txtPort";
			this.txtPort.Size = new System.Drawing.Size(230, 33);
			this.txtPort.TabIndex = 0;
			this.txtPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Consolas", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.ForestGreen;
			this.label1.Location = new System.Drawing.Point(71, 73);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(77, 28);
			this.label1.TabIndex = 1;
			this.label1.Text = "Port:";
			// 
			// btnListen
			// 
			this.btnListen.FlatAppearance.BorderSize = 2;
			this.btnListen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnListen.Font = new System.Drawing.Font("Calibri", 13.8F);
			this.btnListen.ForeColor = System.Drawing.Color.DarkOrange;
			this.btnListen.Location = new System.Drawing.Point(76, 124);
			this.btnListen.Name = "btnListen";
			this.btnListen.Size = new System.Drawing.Size(317, 50);
			this.btnListen.TabIndex = 2;
			this.btnListen.Text = "Listen";
			this.btnListen.UseVisualStyleBackColor = true;
			this.btnListen.Click += new System.EventHandler(this.btnListen_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Desktop;
			this.ClientSize = new System.Drawing.Size(464, 246);
			this.Controls.Add(this.btnListen);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtPort);
			this.ForeColor = System.Drawing.SystemColors.ControlText;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.Text = "Server";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtPort;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnListen;
	}
}

