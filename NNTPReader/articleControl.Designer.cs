namespace NNTPReader
{
	partial class articleControl
	{
		/// <summary> 
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором компонентов

		/// <summary> 
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.btnMenu = new System.Windows.Forms.Button();
			this.cmsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.lblHead = new System.Windows.Forms.Label();
			this.lblTime = new System.Windows.Forms.Label();
			this.txtBody = new System.Windows.Forms.TextBox();
			this.scArticle = new System.Windows.Forms.SplitContainer();
			this.cmsMenu.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.scArticle)).BeginInit();
			this.scArticle.Panel1.SuspendLayout();
			this.scArticle.Panel2.SuspendLayout();
			this.scArticle.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnMenu
			// 
			this.btnMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnMenu.Location = new System.Drawing.Point(465, 3);
			this.btnMenu.Name = "btnMenu";
			this.btnMenu.Size = new System.Drawing.Size(23, 23);
			this.btnMenu.TabIndex = 0;
			this.btnMenu.Text = "☺";
			this.btnMenu.UseVisualStyleBackColor = true;
			this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
			// 
			// cmsMenu
			// 
			this.cmsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportToolStripMenuItem,
            this.saveToolStripMenuItem});
			this.cmsMenu.Name = "cmsMenu";
			this.cmsMenu.Size = new System.Drawing.Size(108, 48);
			// 
			// exportToolStripMenuItem
			// 
			this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
			this.exportToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
			this.exportToolStripMenuItem.Text = "Export";
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
			this.saveToolStripMenuItem.Text = "Save";
			// 
			// lblHead
			// 
			this.lblHead.AutoSize = true;
			this.lblHead.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lblHead.Location = new System.Drawing.Point(3, 3);
			this.lblHead.Name = "lblHead";
			this.lblHead.Size = new System.Drawing.Size(125, 24);
			this.lblHead.TabIndex = 2;
			this.lblHead.Text = "Article Head";
			// 
			// lblTime
			// 
			this.lblTime.AutoSize = true;
			this.lblTime.Location = new System.Drawing.Point(4, 32);
			this.lblTime.Name = "lblTime";
			this.lblTime.Size = new System.Drawing.Size(58, 13);
			this.lblTime.TabIndex = 3;
			this.lblTime.Text = "Article time";
			// 
			// txtBody
			// 
			this.txtBody.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.txtBody.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtBody.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtBody.Location = new System.Drawing.Point(0, 0);
			this.txtBody.Margin = new System.Windows.Forms.Padding(10);
			this.txtBody.Multiline = true;
			this.txtBody.Name = "txtBody";
			this.txtBody.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtBody.Size = new System.Drawing.Size(491, 336);
			this.txtBody.TabIndex = 4;
			this.txtBody.Text = "1\r\n2\r\n3\r\n4\r\n5\r\n6\r\n7\r\n8\r\n9\r\n0\r\n1\r\n2\r\n3\r\n4\r\n5\r\n6\r\n7\r\n8\r\n9\r\n0\r\n1\r\n2\r\n3\r\n4\r\n5\r\n6\r\n7\r\n" +
    "8\r\n9\r\n0";
			// 
			// scArticle
			// 
			this.scArticle.Dock = System.Windows.Forms.DockStyle.Fill;
			this.scArticle.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.scArticle.Location = new System.Drawing.Point(0, 0);
			this.scArticle.Name = "scArticle";
			this.scArticle.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// scArticle.Panel1
			// 
			this.scArticle.Panel1.Controls.Add(this.lblHead);
			this.scArticle.Panel1.Controls.Add(this.lblTime);
			// 
			// scArticle.Panel2
			// 
			this.scArticle.Panel2.Controls.Add(this.txtBody);
			this.scArticle.Size = new System.Drawing.Size(491, 390);
			this.scArticle.TabIndex = 5;
			// 
			// articleControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Controls.Add(this.btnMenu);
			this.Controls.Add(this.scArticle);
			this.Name = "articleControl";
			this.Size = new System.Drawing.Size(491, 390);
			this.cmsMenu.ResumeLayout(false);
			this.scArticle.Panel1.ResumeLayout(false);
			this.scArticle.Panel1.PerformLayout();
			this.scArticle.Panel2.ResumeLayout(false);
			this.scArticle.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.scArticle)).EndInit();
			this.scArticle.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnMenu;
		private System.Windows.Forms.ContextMenuStrip cmsMenu;
		private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
		private System.Windows.Forms.Label lblHead;
		private System.Windows.Forms.Label lblTime;
		private System.Windows.Forms.TextBox txtBody;
		private System.Windows.Forms.SplitContainer scArticle;
	}
}
