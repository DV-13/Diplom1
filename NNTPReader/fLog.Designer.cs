﻿namespace NNTPReader
{
	partial class fLog
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
			this.txtLog = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// txtLog
			// 
			this.txtLog.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtLog.Location = new System.Drawing.Point(0, 0);
			this.txtLog.Multiline = true;
			this.txtLog.Name = "txtLog";
			this.txtLog.ReadOnly = true;
			this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtLog.Size = new System.Drawing.Size(584, 461);
			this.txtLog.TabIndex = 4;
			// 
			// fLog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(584, 461);
			this.Controls.Add(this.txtLog);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Name = "fLog";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Log";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fLog_FormClosing);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		public System.Windows.Forms.TextBox txtLog;
	}
}