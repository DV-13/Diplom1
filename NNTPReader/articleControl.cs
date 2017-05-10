using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NNTPReader
{
	public partial class articleControl : UserControl
	{
		public articleControl()
		{
			InitializeComponent();
			Height = (50);
		}

		private void btnMenu_Click(object sender, EventArgs e)
		{
			cmsMenu.Show(btnMenu, new Point(0, btnMenu.Height));
		}
	}
}
