namespace NNTPReader
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
			this.btnGo = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.txtNNTPServer = new System.Windows.Forms.TextBox();
			this.txtLog = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.btnGetNews = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.btnNext = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.txtHead = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtBody = new System.Windows.Forms.TextBox();
			this.lstNewsgroups = new System.Windows.Forms.ListBox();
			this.lstHeads = new System.Windows.Forms.ListBox();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.Ò‡ÒToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ÒÎ˚ÎÒToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.‡ÈÛÈ‡ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ÈÛÈToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.‡‡ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.‡ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.Ò˚ÒToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.articleControl = new NNTPReader.articleControl();
			this.contextMenuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnGo
			// 
			this.btnGo.Location = new System.Drawing.Point(356, 13);
			this.btnGo.Name = "btnGo";
			this.btnGo.Size = new System.Drawing.Size(75, 23);
			this.btnGo.TabIndex = 0;
			this.btnGo.Text = "Go";
			this.btnGo.UseVisualStyleBackColor = true;
			this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 18);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(74, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "NNTP Server:";
			// 
			// txtNNTPServer
			// 
			this.txtNNTPServer.Location = new System.Drawing.Point(89, 15);
			this.txtNNTPServer.Name = "txtNNTPServer";
			this.txtNNTPServer.Size = new System.Drawing.Size(261, 20);
			this.txtNNTPServer.TabIndex = 2;
			this.txtNNTPServer.Text = "news2.neva.ru";
			// 
			// txtLog
			// 
			this.txtLog.Location = new System.Drawing.Point(939, 482);
			this.txtLog.Multiline = true;
			this.txtLog.Name = "txtLog";
			this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtLog.Size = new System.Drawing.Size(405, 329);
			this.txtLog.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(936, 466);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(28, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Log:";
			// 
			// btnGetNews
			// 
			this.btnGetNews.Location = new System.Drawing.Point(167, 82);
			this.btnGetNews.Name = "btnGetNews";
			this.btnGetNews.Size = new System.Drawing.Size(75, 23);
			this.btnGetNews.TabIndex = 5;
			this.btnGetNews.Text = "Get News";
			this.btnGetNews.UseVisualStyleBackColor = true;
			this.btnGetNews.Click += new System.EventHandler(this.btnGetNews_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 87);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 13);
			this.label3.TabIndex = 7;
			this.label3.Text = "Newgroups:";
			// 
			// btnNext
			// 
			this.btnNext.Location = new System.Drawing.Point(486, 482);
			this.btnNext.Name = "btnNext";
			this.btnNext.Size = new System.Drawing.Size(133, 23);
			this.btnNext.TabIndex = 8;
			this.btnNext.Text = "Next Article";
			this.btnNext.UseVisualStyleBackColor = true;
			this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(9, 495);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(36, 13);
			this.label4.TabIndex = 9;
			this.label4.Text = "Head:";
			// 
			// txtHead
			// 
			this.txtHead.Location = new System.Drawing.Point(12, 511);
			this.txtHead.Multiline = true;
			this.txtHead.Name = "txtHead";
			this.txtHead.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtHead.Size = new System.Drawing.Size(607, 96);
			this.txtHead.TabIndex = 10;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(9, 610);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(34, 13);
			this.label5.TabIndex = 11;
			this.label5.Text = "Body:";
			// 
			// txtBody
			// 
			this.txtBody.Location = new System.Drawing.Point(12, 626);
			this.txtBody.Multiline = true;
			this.txtBody.Name = "txtBody";
			this.txtBody.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtBody.Size = new System.Drawing.Size(607, 185);
			this.txtBody.TabIndex = 12;
			// 
			// lstNewsgroups
			// 
			this.lstNewsgroups.FormattingEnabled = true;
			this.lstNewsgroups.Location = new System.Drawing.Point(12, 103);
			this.lstNewsgroups.Name = "lstNewsgroups";
			this.lstNewsgroups.Size = new System.Drawing.Size(230, 342);
			this.lstNewsgroups.TabIndex = 13;
			this.lstNewsgroups.SelectedIndexChanged += new System.EventHandler(this.lstNewsgroups_SelectedIndexChanged);
			// 
			// lstHeads
			// 
			this.lstHeads.FormattingEnabled = true;
			this.lstHeads.Location = new System.Drawing.Point(625, 482);
			this.lstHeads.Name = "lstHeads";
			this.lstHeads.Size = new System.Drawing.Size(308, 329);
			this.lstHeads.TabIndex = 14;
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Ò‡ÒToolStripMenuItem,
            this.ÒÎ˚ÎÒToolStripMenuItem,
            this.‡ÈÛÈ‡ToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(110, 70);
			// 
			// Ò‡ÒToolStripMenuItem
			// 
			this.Ò‡ÒToolStripMenuItem.Name = "Ò‡ÒToolStripMenuItem";
			this.Ò‡ÒToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
			this.Ò‡ÒToolStripMenuItem.Text = "Ò‡Ò";
			// 
			// ÒÎ˚ÎÒToolStripMenuItem
			// 
			this.ÒÎ˚ÎÒToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Ò˚ÒToolStripMenuItem});
			this.ÒÎ˚ÎÒToolStripMenuItem.Name = "ÒÎ˚ÎÒToolStripMenuItem";
			this.ÒÎ˚ÎÒToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
			this.ÒÎ˚ÎÒToolStripMenuItem.Text = "ÒÎ˚ÎÒ";
			// 
			// ‡ÈÛÈ‡ToolStripMenuItem
			// 
			this.‡ÈÛÈ‡ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ÈÛÈToolStripMenuItem,
            this.‡‡ToolStripMenuItem});
			this.‡ÈÛÈ‡ToolStripMenuItem.Name = "‡ÈÛÈ‡ToolStripMenuItem";
			this.‡ÈÛÈ‡ToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
			this.‡ÈÛÈ‡ToolStripMenuItem.Text = "‡ÈÛÈ‡";
			// 
			// ÈÛÈToolStripMenuItem
			// 
			this.ÈÛÈToolStripMenuItem.Name = "ÈÛÈToolStripMenuItem";
			this.ÈÛÈToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
			this.ÈÛÈToolStripMenuItem.Text = "ÈÛÈ";
			// 
			// ‡‡ToolStripMenuItem
			// 
			this.‡‡ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.‡ToolStripMenuItem});
			this.‡‡ToolStripMenuItem.Name = "‡‡ToolStripMenuItem";
			this.‡‡ToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
			this.‡‡ToolStripMenuItem.Text = "‡‡";
			// 
			// ‡ToolStripMenuItem
			// 
			this.‡ToolStripMenuItem.Name = "‡ToolStripMenuItem";
			this.‡ToolStripMenuItem.Size = new System.Drawing.Size(80, 22);
			this.‡ToolStripMenuItem.Text = "‡";
			// 
			// Ò˚ÒToolStripMenuItem
			// 
			this.Ò˚ÒToolStripMenuItem.Name = "Ò˚ÒToolStripMenuItem";
			this.Ò˚ÒToolStripMenuItem.Size = new System.Drawing.Size(95, 22);
			this.Ò˚ÒToolStripMenuItem.Text = "Ò˚Ò";
			// 
			// articleControl
			// 
			this.articleControl.AutoSize = true;
			this.articleControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.articleControl.Location = new System.Drawing.Point(427, 53);
			this.articleControl.Name = "articleControl";
			this.articleControl.Size = new System.Drawing.Size(653, 410);
			this.articleControl.TabIndex = 16;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1359, 823);
			this.Controls.Add(this.articleControl);
			this.Controls.Add(this.lstHeads);
			this.Controls.Add(this.lstNewsgroups);
			this.Controls.Add(this.txtBody);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.txtHead);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.btnNext);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.btnGetNews);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtLog);
			this.Controls.Add(this.txtNNTPServer);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnGo);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.Text = "NNTP Reader";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.contextMenuStrip1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNNTPServer;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGetNews;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtHead;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBody;
		private System.Windows.Forms.ListBox lstNewsgroups;
		private System.Windows.Forms.ListBox lstHeads;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem Ò‡ÒToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ÒÎ˚ÎÒToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem Ò˚ÒToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ‡ÈÛÈ‡ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ÈÛÈToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ‡‡ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ‡ToolStripMenuItem;
		private articleControl articleControl;
	}
}

