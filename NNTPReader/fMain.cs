using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Linq;
using System.IO;

namespace NNTPReader
{
	public partial class fMain : Form
	{
		// Used for receiving info
		byte[] downBuffer = new byte[2048];
		// Used for sending commands
		byte[] byteSendInfo = new byte[2048];
		// Used for connecting a socket to the NNTP server
		TcpClient tcpClient;
		// Used for sending and receiving information
		NetworkStream strRemote;
		// Stores various responses
		string Response;
		// Number of bytes in the buffer
		int bytesSize;
		// Stores the ID of the first message in a newsgroup
		int firstID;
		// Stores the ID of the current message in a newsgroup
		int currID;
		// Stores the ID of the last message in a newsgroup
		int lastID;
		// Stores chunks of the articles from the buffer
		string NewChunk;
		// Log form
		fLog fLog = new fLog();
		// Number of messages
		int messNum;
		// Current message
		int messCurr;



		public fMain()
		{
			InitializeComponent();
			Connect();
			fLog.Show(this);
		}

		private void btnGo_Click(object sender, EventArgs e)
		{
			SuspendLayout();
			Connect();
			ResumeLayout();
		}

		private void btnNext_Click(object sender, EventArgs e)
		{
			if (NextArticle())
			{
				txtHead.Text = GetHead();
				txtBody.Text = GetBody();
			}
			lblMessInfo.Text = "Message " + messCurr + " out of " + messNum;
		}

		private void btnLast_Click(object sender, EventArgs e)
		{
			if (LastArticle())
			{
				txtHead.Text = GetHead();
				txtBody.Text = GetBody();
			}
			lblMessInfo.Text = "Message " + messCurr + " out of " + messNum;
		}

		private void showLogToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (fLog.Visible == false)
				fLog.Show(this);
			else
				fLog.Activate();
		}

		private void lstNewsgroups_SelectedIndexChanged(object sender, EventArgs e)
		{
			GetNews();
			txtHead.Text = GetHead();
			txtBody.Text = GetBody();
		}

		private void treeNewsgroups_AfterSelect(object sender, TreeViewEventArgs e)
		{
			//fLog.txtLog.AppendText(treeNewsgroups.SelectedNode.FullPath + "\r\n");
			if (GetNews())
			{
				txtHead.Text = GetHead();
				txtBody.Text = GetBody();
				lblMessInfo.Text = "Message " + messCurr + " out of " + messNum;
			}
			else
				lblMessInfo.Text = "No messages";
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Close();
		}

		public static byte[] StringToByteArr(string str)
		{
			ASCIIEncoding encoding = new ASCIIEncoding();
			return encoding.GetBytes(str);
		}

		/// <summary>
		/// Connect to the server
		/// </summary>
		private void Connect()
		{
			// Open the socket to the server
			try
			{
				tcpClient = new TcpClient(txtNNTPServer.Text, 119);
			}
			catch (Exception ex)
			{
				fLog.txtLog.AppendText("Failed to connect to server\r\n" + ex + "\r\n");
				return;
			}
			txtBody.Clear();
			txtHead.Clear();
			strRemote = tcpClient.GetStream();
			// Read the bytes
			bytesSize = strRemote.Read(downBuffer, 0, 2048);
			// Retrieve the response
			Response = Encoding.ASCII.GetString(downBuffer, 0, bytesSize);
			// Just as in HTTP, if code 200 is not returned, something's not right
			if (Response.Substring(0, 3) != "200")
			{
				MessageBox.Show("The server returned an unexpected response.", "Connection failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
				fLog.txtLog.AppendText("Failed to connect to server\r\n");
			}
			// Show the response
			fLog.txtLog.AppendText(Response + "\n");

			// Make the request to list all newsgroups
			byteSendInfo = StringToByteArr("LIST\r\n");
			strRemote.Write(byteSendInfo, 0, byteSendInfo.Length);
			Response = "";

			// Loop to retrieve a list of newsgroups
			while ((bytesSize = strRemote.Read(downBuffer, 0, downBuffer.Length)) > 0)
			{
				// Get the chunk of string
				NewChunk = Encoding.ASCII.GetString(downBuffer, 0, bytesSize);
				Response += NewChunk;
				// If the string ends in a "\r\n.\r\n" then the list is over
				if (NewChunk.Length >= 5 && NewChunk.Substring(NewChunk.Length - 5, 5) == "\r\n.\r\n")
				{
					// Remove the "\r\n.\r\n" from the end of the string
					Response = Response.Substring(0, Response.Length - 3);
					break;
				}
			}
			treeNewsgroups.Nodes.Clear();
			// List of newsgroups
			var lNewsgroups = new List<string> { };
			// Split lines into an array
			string[] ListLines = Response.Split('\n');
			// Loop line by line
			foreach (String ListLine in ListLines)
			{
				// If the response starts with 215, it's the line that indicates the status
				if (ListLine.Length > 3 && ListLine.Substring(0, 3) == "215")
				{
					// Add the status response line to the log window
					fLog.txtLog.AppendText(ListLine + "\r\n");
				}
				else
				{
					// Add the newsgroup to the combobox
					string[] Newsgroup = ListLine.Split(' ');
					if (Newsgroup[0] != "")
						lNewsgroups.Add(Newsgroup[0]);
				}
			}
			AddNodes(lNewsgroups);
		}

		/// <summary>
		/// Get list of news
		/// </summary>
		private bool GetNews()
		{
			messCurr = 1;
			bool ret = false;
			// Request a certain newsgroup
			byteSendInfo = StringToByteArr("GROUP " + treeNewsgroups.SelectedNode.FullPath + "\r\n");
			strRemote.Write(byteSendInfo, 0, byteSendInfo.Length);
			Response = "";
			bytesSize = strRemote.Read(downBuffer, 0, 2048);
			//Response = System.Text.Encoding.ASCII.GetString(downBuffer, 0, bytesSize);
			// Split the information about the newsgroup by blank spaces
			string[] Group = Encoding.ASCII.GetString(downBuffer, 0, bytesSize).Split(' ');
			// Show information about the newsgroup in the txtLog TextBox
			if (Group.Length > 0 && Group[0] == "411")
			{
				Response = "411 No such newsgroup\r\n";
				lblGroupInfo.Text = "No such newsgroup";
			}
			else if (Group.Length > 0)
			{
				Response += Group[0] + " " + Group[1] + " messages in the group (" + Group[2] + "..." + Group[3] + ")\r\n";
				messNum = int.Parse(Group[1]);
				// The ID of the first and current article in this newsgroup
				firstID = currID = Convert.ToInt32(Group[2]);
				// The ID of the last article in this newsgroup
				lastID = Convert.ToInt32(Group[3]);
				if (int.Parse(Group[1]) == 0)
				{
					lblGroupInfo.Text = "This newsgroup is empty";
				}
				else
				{
					lblGroupInfo.Text = Group[1] + " messages in the group";
					ret = true;
				}
			}
			else
			{
				Response += "004 Unexpected answer form server\r\n";
				lblGroupInfo.Text = "Unexpected answer from server";
			}
			fLog.txtLog.AppendText(Response);
			Response = "";
			return ret;
		}

		/// <summary>
		/// Get ID of next article
		/// </summary>
		/// <returns>
		/// True - OK
		/// False - Not OK
		/// </returns>
		private bool NextArticle()
		{
			bool ret = false;
			// Request the next article
			byteSendInfo = StringToByteArr("NEXT\r\n");
			strRemote.Write(byteSendInfo, 0, byteSendInfo.Length);
			bytesSize = strRemote.Read(downBuffer, 0, 2048);
			string[] Group = Encoding.ASCII.GetString(downBuffer, 0, bytesSize).Split(' ');
			// Show information about the article in the txtLog TextBox
			if (Group.Length > 0)
			{
				if (Group[0] == "223")
				{
					Response += Group[0] + " Next article ID is " + Group[1] + "\r\n";
					// The ID of the next article
					currID = Convert.ToInt32(Group[1]);
					messCurr++;
					ret = true;
				}
				else if (Group[0] == "412")
				{
					Response = "412 Newsgroup not selected\r\n";
				}
				else if (Group[0] == "421")
				{
					Response += "421 Last article\r\n";
				}
			}
			else
			{
				Response += "Unexpected answer form server/No articles\r\n";
			}
			//fLog.txtLog.AppendText(System.Text.Encoding.ASCII.GetString(downBuffer, 0, bytesSize));
			fLog.txtLog.AppendText(Response /*+ currID + "\r\n"*/);
			Response = "";
			return ret;
		}

		/// <summary>
		/// Get ID of previous article
		/// </summary>
		/// <returns>
		/// True - OK
		/// False - Not OK
		/// </returns>
		private bool LastArticle()
		{
			bool ret = false;
			// Request the next article
			byteSendInfo = StringToByteArr("LAST\r\n");
			strRemote.Write(byteSendInfo, 0, byteSendInfo.Length);
			bytesSize = strRemote.Read(downBuffer, 0, 2048);
			string[] Group = Encoding.ASCII.GetString(downBuffer, 0, bytesSize).Split(' ');
			// Show information about the article in the txtLog TextBox
			if (Group.Length > 0)
			{
				if (Group[0] == "223")
				{
					Response += Group[0] + " Last article ID is " + Group[1] + "\r\n";
					// The ID of the next article
					currID = Convert.ToInt32(Group[1]);
					messCurr--;
					ret = true;
				}
				else if (Group[0] == "412")
				{
					Response = "412 Newsgroup not selected\r\n";
					ret = false;
				}
				else if (Group[0] == "422")
				{
					Response += "422 First article\r\n";
					ret = false;
				}
			}
			else
			{
				Response += "Unexpected answer form server/No articles\r\n";
				ret = false;
			}
			//fLog.txtLog.AppendText(System.Text.Encoding.ASCII.GetString(downBuffer, 0, bytesSize));
			fLog.txtLog.AppendText(Response /*+ currID + "\r\n"*/);
			Response = "";
			return ret;
		}

		/// <summary>
		/// Get head of article
		/// </summary>
		/// <returns>
		/// Head of article
		/// </returns>
		private string GetHead()
		{
			string headTmp = "";
			// Get the header
			txtHead.Text = "";
			// Initialize the buffer to 2048 bytes
			downBuffer = new byte[2048];
			// Request the headers of the article
			byteSendInfo = StringToByteArr("HEAD " + currID + "\r\n");
			// Send the request to the NNTP server
			strRemote.Write(byteSendInfo, 0, byteSendInfo.Length);
			while ((bytesSize = strRemote.Read(downBuffer, 0, downBuffer.Length)) > 0)
			{
				NewChunk = Encoding.ASCII.GetString(downBuffer, 0, bytesSize);
				headTmp += NewChunk;
				// No such article in the group
				if (NewChunk.Substring(0, 3) == "423")
				{
					fLog.txtLog.AppendText("001 No such article (H)\r\n");
					// End this method because it's retrieving a nonexistent article
					return null;
				}
				else if (NewChunk.Substring(NewChunk.Length - 5, 5) == "\r\n.\r\n")
				{
					// If the last thing in the buffer is "\r\n.\r\n" the message's finished and non-existent messages count is reset
					break;
				}
			}
			//txtHead.Text = headTmp;
			return headTmp;
		}

		/// <summary>
		/// Get body of article
		/// </summary>
		/// <returns>
		/// Body of article
		/// </returns>
		private string GetBody()
		{
			string bodyTmp = "";
			// Get the body
			txtBody.Text = "";
			// Initialize the buffer to 2048 bytes
			downBuffer = new byte[2048];
			// Request the headers of the article
			byteSendInfo = StringToByteArr("BODY " + currID + "\r\n");
			// Send the request to the NNTP server
			strRemote.Write(byteSendInfo, 0, byteSendInfo.Length);
			while ((bytesSize = strRemote.Read(downBuffer, 0, downBuffer.Length)) > 0)
			{
				NewChunk = Encoding.ASCII.GetString(downBuffer, 0, bytesSize);
				bodyTmp += NewChunk;

				if (NewChunk.Substring(0, 3) == "423")
				{
					fLog.txtLog.AppendText("001 No such article (B)\r\n");
					// End this method because it's retrieving a nonexistent article
					return null;
				}

				// If the last thing in the buffer is "\r\n.\r\n" the message's finished
				if (NewChunk.Length < 5)
				{
					break;
					//fLog.txtLog.AppendText("Short chunk at the end of message.\r\n");
				}
				if (NewChunk.Substring(NewChunk.Length - 5, 5) == "\r\n.\r\n")
				{
					break;
				}
			}
			fLog.txtLog.AppendText("000 Displaying article " + currID + "\r\n");
			//txtBody.Text = bodyTmp;
			return bodyTmp;
		}
		/*
		private string[] formatHead(string inHead)
		{
			string[] outHead = new string[] { "", "", "", "" };
			string[] headTemp = inHead.Split('\n');
			foreach (string headChunk in headTemp)
			{
				if (headChunk.Length > 2)
					if (headChunk.Substring(0, 3) == "221")
					{
						outHead[0] = headChunk.Split(' ')[1];
					}
				if (headChunk.Length > 4)
					if (headChunk.Substring(0, 5) == "From:")
					{
						outHead[1] = headChunk;
					}
				if (headChunk.Length > 7)
					if (headChunk.Substring(0, 8) == "Subject:")
					{
						outHead[2] = headChunk;
					}
				if (headChunk.Length > 4)
					if (headChunk.Substring(0, 5) == "Date:")
					{
						outHead[3] = headChunk;
					}
			}
			return outHead;
		}
		*/
		/*
		private string formatHead(string inHead)
		{
			string outHead = "";
			string[] headTemp = inHead.Split('\n');
			foreach (string headChunk in headTemp)
			{
				if (headChunk.Length > 2)
					if (headChunk.Substring(0, 3) == "221")
					{
						outHead += headChunk.Split(' ')[1] + "\t";
					}
				if (headChunk.Length > 4)
					if (headChunk.Substring(0, 5) == "From:")
					{
						outHead += headChunk + "\t";//(headChunk.Substring(6, headChunk.Length));
					}
				if (headChunk.Length > 7)
					if (headChunk.Substring(0, 8) == "Subject:")
					{
						outHead += headChunk + "\t";//(headChunk.Substring(9, headChunk.Length));
					}
				if (headChunk.Length > 4)
					if (headChunk.Substring(0, 5) == "Date:")
					{
						outHead += headChunk;//(headChunk.Substring(6, headChunk.Length));
					}
			}
			return outHead;
		}
		*/

		/*
		/// <summary>
		/// Get list of heads
		/// </summary>
		private void GetHeads()
		{
			lstHeads.Items.Clear();
			tableHeads.Controls.Clear();
			//tableHeads.RowCount = 0;
			//tableHeads.Height = 20;
			int i = 0;
			tableHeads.SuspendLayout();
			while (NextArticle() && (i <= 100))
			{
				string[] hTemp = formatHead(GetHead());
				lstHeads.Items.Add(
				string.Format(
				"{0, -8} {1, -50} {2, -50} {3, -30}",
				hTemp[0],
				CutString(hTemp[1], 35),
				CutString(hTemp[2], 35),
				CutString(hTemp[3], 35)
				));
				i++;
				//tableHeads.RowCount++;
				//tableHeads.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
				tableHeads.Controls.Add(new Label() { Text = hTemp[0], Anchor = AnchorStyles.Left, AutoSize = true }, 0, i + 1);
				tableHeads.Controls.Add(new Label() { Text = hTemp[1], Anchor = AnchorStyles.Left, AutoSize = true }, 1, i + 1);
				tableHeads.Controls.Add(new Label() { Text = hTemp[2], Anchor = AnchorStyles.Left, AutoSize = true }, 2, i + 1);
				tableHeads.Controls.Add(new Label() { Text = hTemp[3], Anchor = AnchorStyles.Left, AutoSize = true }, 3, i + 1);
			}
			tableHeads.ResumeLayout();
		}
		*/

		/// <summary>
		/// Quit server when exiting program
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (tcpClient != null && tcpClient.Connected == true)
			{
				downBuffer = new byte[2048];
				// Request a certain newsgroup
				byteSendInfo = StringToByteArr("QUIT\r\n");
				strRemote.Write(byteSendInfo, 0, byteSendInfo.Length);
				bytesSize = strRemote.Read(downBuffer, 0, 2048);
				fLog.txtLog.AppendText(Encoding.ASCII.GetString(downBuffer, 0, bytesSize));
			}
		}

		/*
		public string CutString(string str, int length)
		{
			if (str.Length > length)
				return str.Substring(0, length - 3) + "...";
			else if (str.Length < length)
			{
				for (int i = 0; str.Length <= length; i++)
				{
					str += "_";
				}
			}
			return str;
		}
		*/

		internal class TreeNodeHierachy
		{
			public int Level { get; set; }
			public TreeNode Node { get; set; }
			public Guid Id { get; set; }
			public Guid ParentId { get; set; }
			public string RootText { get; set; }
		}

		private List<TreeNodeHierachy> overAllNodeList;

		private void AddNodes(IEnumerable<string> data)
		{
			overAllNodeList = new List<TreeNodeHierachy>();
			foreach (var item in data)
			{
				var nodeList = new List<TreeNodeHierachy>();
				var split = item.Split('.');
				for (var i = 0; i < split.Count(); i++)
				{
					var guid = Guid.NewGuid();
					var parent = i == 0 ? null : nodeList.First(n => n.Level == i - 1);
					var root = i == 0 ? null : nodeList.First(n => n.Level == 0);
					nodeList.Add(new TreeNodeHierachy
					{
						Level = i,
						Node = new TreeNode(split[i]) { Tag = guid },
						Id = guid,
						ParentId = parent != null ? parent.Id : Guid.Empty,
						RootText = root != null ? root.RootText : split[i]
					});
				}

				// figure out dups here
				if (!overAllNodeList.Any())
				{
					overAllNodeList.AddRange(nodeList);
				}
				else
				{
					nodeList = nodeList.OrderBy(x => x.Level).ToList();
					for (var i = 0; i < nodeList.Count; i++)
					{

						var existingNode = overAllNodeList.FirstOrDefault(
							 n => n.Node.Text == nodeList[i].Node.Text && n.Level == nodeList[i].Level && n.RootText == nodeList[i].RootText);
						if (existingNode != null && (i + 1) < nodeList.Count)
						{

							nodeList[i + 1].ParentId = existingNode.Id;
						}
						else
						{
							overAllNodeList.Add(nodeList[i]);
						}
					}
				}
			}

			foreach (var treeNodeHierachy in overAllNodeList.Where(x => x.Level == 0))
			{
				treeNewsgroups.Nodes.Add(AddChildNodes(treeNodeHierachy));
			}
			treeNewsgroups.PathSeparator = ".";
		}

		private TreeNode AddChildNodes(TreeNodeHierachy node)
		{
			var treeNode = node.Node;
			foreach (var treeNodeHierachy in overAllNodeList.Where(n => n.ParentId == node.Id))
			{
				treeNode.Nodes.Add(AddChildNodes(treeNodeHierachy));
			}
			return treeNode;
		}

		private void saveArticleToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (txtBody.Text != "")
			{
				saveFileDialog1.FileName = txtNNTPServer.Text + "_" + treeNewsgroups.SelectedNode.FullPath + "_" + currID + ".txt";
				if (saveFileDialog1.ShowDialog() == DialogResult.OK)
				{
					string filename = saveFileDialog1.FileName;
					string outText = "Article number " + currID + " from group " + treeNewsgroups.SelectedNode.FullPath + " on server" + txtNNTPServer.Text + ".\r\n\r\nHead:\r\n" + txtHead.Text + "\r\nBody:\r\n" + txtBody.Text;
					File.WriteAllText(filename, outText);
					fLog.txtLog.AppendText("File saved");
				}
			}

			else
			{
				MessageBox.Show("Nothing to save.", "Saving failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
				fLog.txtLog.AppendText("No article to save");
			}
		}
	}
}