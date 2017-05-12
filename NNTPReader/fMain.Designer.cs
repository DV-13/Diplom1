namespace NNTPReader
{
    partial class fMain
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
			this.btnGo = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.txtNNTPServer = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.btnNext = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.txtHead = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtBody = new System.Windows.Forms.TextBox();
			this.btnLast = new System.Windows.Forms.Button();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveArticleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.debugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.showLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.treeNewsgroups = new System.Windows.Forms.TreeView();
			this.lblGroupInfo = new System.Windows.Forms.Label();
			this.lblMessInfo = new System.Windows.Forms.Label();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnGo
			// 
			this.btnGo.Location = new System.Drawing.Point(182, 24);
			this.btnGo.Name = "btnGo";
			this.btnGo.Size = new System.Drawing.Size(75, 23);
			this.btnGo.TabIndex = 2;
			this.btnGo.Text = "Go";
			this.btnGo.UseVisualStyleBackColor = true;
			this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 29);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(74, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "NNTP Server:";
			// 
			// txtNNTPServer
			// 
			this.txtNNTPServer.Location = new System.Drawing.Point(15, 53);
			this.txtNNTPServer.Name = "txtNNTPServer";
			this.txtNNTPServer.Size = new System.Drawing.Size(242, 20);
			this.txtNNTPServer.TabIndex = 1;
			this.txtNNTPServer.Text = "news.gweep.ca";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 79);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 13);
			this.label3.TabIndex = 7;
			this.label3.Text = "Newgroups:";
			// 
			// btnNext
			// 
			this.btnNext.Location = new System.Drawing.Point(344, 51);
			this.btnNext.Name = "btnNext";
			this.btnNext.Size = new System.Drawing.Size(64, 23);
			this.btnNext.TabIndex = 4;
			this.btnNext.Text = "Next";
			this.btnNext.UseVisualStyleBackColor = true;
			this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(273, 79);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(36, 13);
			this.label4.TabIndex = 9;
			this.label4.Text = "Head:";
			// 
			// txtHead
			// 
			this.txtHead.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.txtHead.Location = new System.Drawing.Point(274, 95);
			this.txtHead.Multiline = true;
			this.txtHead.Name = "txtHead";
			this.txtHead.ReadOnly = true;
			this.txtHead.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtHead.Size = new System.Drawing.Size(810, 170);
			this.txtHead.TabIndex = 5;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(273, 268);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(34, 13);
			this.label5.TabIndex = 11;
			this.label5.Text = "Body:";
			// 
			// txtBody
			// 
			this.txtBody.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.txtBody.Location = new System.Drawing.Point(274, 284);
			this.txtBody.Multiline = true;
			this.txtBody.Name = "txtBody";
			this.txtBody.ReadOnly = true;
			this.txtBody.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtBody.Size = new System.Drawing.Size(810, 409);
			this.txtBody.TabIndex = 6;
			// 
			// btnLast
			// 
			this.btnLast.Location = new System.Drawing.Point(274, 51);
			this.btnLast.Name = "btnLast";
			this.btnLast.Size = new System.Drawing.Size(64, 23);
			this.btnLast.TabIndex = 5;
			this.btnLast.Text = "Last";
			this.btnLast.UseVisualStyleBackColor = true;
			this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.debugToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(1096, 24);
			this.menuStrip1.TabIndex = 7;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveArticleToolStripMenuItem,
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// saveArticleToolStripMenuItem
			// 
			this.saveArticleToolStripMenuItem.Name = "saveArticleToolStripMenuItem";
			this.saveArticleToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.saveArticleToolStripMenuItem.Text = "Save Article";
			this.saveArticleToolStripMenuItem.Click += new System.EventHandler(this.saveArticleToolStripMenuItem_Click);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// debugToolStripMenuItem
			// 
			this.debugToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showLogToolStripMenuItem});
			this.debugToolStripMenuItem.Name = "debugToolStripMenuItem";
			this.debugToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
			this.debugToolStripMenuItem.Text = "Debug";
			// 
			// showLogToolStripMenuItem
			// 
			this.showLogToolStripMenuItem.Name = "showLogToolStripMenuItem";
			this.showLogToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
			this.showLogToolStripMenuItem.Text = "Show Log";
			this.showLogToolStripMenuItem.Click += new System.EventHandler(this.showLogToolStripMenuItem_Click);
			// 
			// treeNewsgroups
			// 
			this.treeNewsgroups.Location = new System.Drawing.Point(12, 95);
			this.treeNewsgroups.Name = "treeNewsgroups";
			this.treeNewsgroups.Size = new System.Drawing.Size(245, 598);
			this.treeNewsgroups.TabIndex = 3;
			this.treeNewsgroups.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeNewsgroups_AfterSelect);
			// 
			// lblGroupInfo
			// 
			this.lblGroupInfo.AutoSize = true;
			this.lblGroupInfo.Location = new System.Drawing.Point(122, 79);
			this.lblGroupInfo.Name = "lblGroupInfo";
			this.lblGroupInfo.Size = new System.Drawing.Size(138, 13);
			this.lblGroupInfo.TabIndex = 21;
			this.lblGroupInfo.Text = "To start select a newsgroup";
			// 
			// lblMessInfo
			// 
			this.lblMessInfo.AutoSize = true;
			this.lblMessInfo.Location = new System.Drawing.Point(414, 56);
			this.lblMessInfo.Name = "lblMessInfo";
			this.lblMessInfo.Size = new System.Drawing.Size(13, 13);
			this.lblMessInfo.TabIndex = 22;
			this.lblMessInfo.Text = "  ";
			this.lblMessInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// saveFileDialog1
			// 
			this.saveFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
			this.saveFileDialog1.Title = "Save Article";
			// 
			// fMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1096, 705);
			this.Controls.Add(this.lblMessInfo);
			this.Controls.Add(this.lblGroupInfo);
			this.Controls.Add(this.treeNewsgroups);
			this.Controls.Add(this.btnLast);
			this.Controls.Add(this.txtBody);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.txtHead);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.btnNext);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtNNTPServer);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnGo);
			this.Controls.Add(this.menuStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MainMenuStrip = this.menuStrip1;
			this.MaximizeBox = false;
			this.Name = "fMain";
			this.Text = "NNTP Reader";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNNTPServer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtHead;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBody;
		private System.Windows.Forms.Button btnLast;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem debugToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem showLogToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveArticleToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.TreeView treeNewsgroups;
		private System.Windows.Forms.Label lblGroupInfo;
		private System.Windows.Forms.Label lblMessInfo;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
	}
}

