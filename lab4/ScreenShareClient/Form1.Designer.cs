namespace ScreenShareClient
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
			this.components = new System.ComponentModel.Container();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtIp = new System.Windows.Forms.TextBox();
			this.txtPort = new System.Windows.Forms.TextBox();
			this.btnConnect = new System.Windows.Forms.Button();
			this.btnShare = new System.Windows.Forms.Button();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Consolas", 13.8F);
			this.label1.ForeColor = System.Drawing.Color.ForestGreen;
			this.label1.Location = new System.Drawing.Point(71, 41);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(51, 28);
			this.label1.TabIndex = 0;
			this.label1.Text = "IP:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Consolas", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.ForestGreen;
			this.label2.Location = new System.Drawing.Point(71, 135);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(77, 28);
			this.label2.TabIndex = 0;
			this.label2.Text = "Port:";
			// 
			// txtIp
			// 
			this.txtIp.BackColor = System.Drawing.SystemColors.Desktop;
			this.txtIp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtIp.Font = new System.Drawing.Font("Consolas", 12.2F);
			this.txtIp.ForeColor = System.Drawing.Color.DarkOrange;
			this.txtIp.Location = new System.Drawing.Point(76, 77);
			this.txtIp.Name = "txtIp";
			this.txtIp.Size = new System.Drawing.Size(275, 31);
			this.txtIp.TabIndex = 1;
			// 
			// txtPort
			// 
			this.txtPort.BackColor = System.Drawing.SystemColors.Desktop;
			this.txtPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtPort.Font = new System.Drawing.Font("Consolas", 12.2F);
			this.txtPort.ForeColor = System.Drawing.Color.DarkOrange;
			this.txtPort.Location = new System.Drawing.Point(76, 171);
			this.txtPort.Name = "txtPort";
			this.txtPort.Size = new System.Drawing.Size(275, 31);
			this.txtPort.TabIndex = 2;
			// 
			// btnConnect
			// 
			this.btnConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnConnect.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnConnect.ForeColor = System.Drawing.Color.DarkOrange;
			this.btnConnect.Location = new System.Drawing.Point(76, 249);
			this.btnConnect.Name = "btnConnect";
			this.btnConnect.Size = new System.Drawing.Size(107, 65);
			this.btnConnect.TabIndex = 3;
			this.btnConnect.Text = "Connect";
			this.btnConnect.UseVisualStyleBackColor = false;
			this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
			// 
			// btnShare
			// 
			this.btnShare.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnShare.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnShare.ForeColor = System.Drawing.Color.DarkOrange;
			this.btnShare.Location = new System.Drawing.Point(208, 249);
			this.btnShare.Name = "btnShare";
			this.btnShare.Size = new System.Drawing.Size(143, 65);
			this.btnShare.TabIndex = 4;
			this.btnShare.Text = "Share My Screen";
			this.btnShare.UseVisualStyleBackColor = false;
			this.btnShare.Click += new System.EventHandler(this.btnShare_Click);
			// 
			// timer1
			// 
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Desktop;
			this.ClientSize = new System.Drawing.Size(421, 372);
			this.Controls.Add(this.btnShare);
			this.Controls.Add(this.btnConnect);
			this.Controls.Add(this.txtPort);
			this.Controls.Add(this.txtIp);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Client";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtIp;
		private System.Windows.Forms.TextBox txtPort;
		private System.Windows.Forms.Button btnConnect;
		private System.Windows.Forms.Button btnShare;
		private System.Windows.Forms.Timer timer1;
	}
}

