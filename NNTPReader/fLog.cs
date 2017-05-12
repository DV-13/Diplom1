using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NNTPReader
{
	public partial class fLog : Form
	{
		public fLog()
		{
			InitializeComponent();
		}

		private void fLog_FormClosing(object sender, FormClosingEventArgs e)
		{
			// Prevent the user from closing this window, minimize instead.
			if (e.CloseReason == CloseReason.UserClosing)
			{
				//this.WindowState = FormWindowState.Minimized;
				Hide();
				e.Cancel = true;
			}
		}
	}
}
