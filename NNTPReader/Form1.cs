using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;

namespace NNTPReader
{
	public partial class Form1 : Form
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
		// Stores the ID of the last message in a newsgroup
		int lastID;
		// Stores chunks of the articles from the buffer
		string NewChunk;

		public Form1()
		{
			InitializeComponent();
			Connect();
		}

		private void btnGo_Click(object sender, EventArgs e)
		{
			Connect();
		}

		private void btnGetNews_Click(object sender, EventArgs e)
		{
			GetNews();
		}

		private void btnNext_Click(object sender, EventArgs e) //���� ������� � ��������� �������
		{
			if (NextArticle())
			{
				txtHead.Text = GetHead();
				txtBody.Text = GetBody();
			}
			//else
			//{
			//	txtLog.AppendText("002 Last article\r\n");
			//}

			//if (firstID < lastID)
			//{
			//	GetHead();
			//	GetBody();
			//	NextArticle();
			//}
			//else
			//{
			//	GetHead(); 
			//	GetBody();
			//	txtLog.AppendText("002 Last article\r\n");
			//}
		}

		private void lstNewsgroups_SelectedIndexChanged(object sender, EventArgs e)
		{
			GetNews();
			//NextArticle();
		}

		public static byte[] StringToByteArr(string str)
		{
			System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
			return encoding.GetBytes(str);
		}

		private void Connect()
		{
			// Open the socket to the server
			tcpClient = new System.Net.Sockets.TcpClient(txtNNTPServer.Text, 119);
			strRemote = tcpClient.GetStream();
			// Read the bytes
			bytesSize = strRemote.Read(downBuffer, 0, 2048);
			// Retrieve the response
			Response = System.Text.Encoding.ASCII.GetString(downBuffer, 0, bytesSize);
			// Just as in HTTP, if code 200 is not returned, something's not right
			if (Response.Substring(0, 3) != "200")
			{
				MessageBox.Show("The server returned an unexpected response.", "Connection failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			// Show the response
			txtLog.Text = Response + "\n";

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
				//else
				//{
				//	txtLog.AppendText("004 Unexpected answer from the server\r\n");
				//	break;
				//}
			}
			// Split lines into an array
			string[] ListLines = Response.Split('\n');
			// Loop line by line
			foreach (String ListLine in ListLines)
			{
				// If the response starts with 215, it's the line that indicates the status
				if (ListLine.Length > 3 && ListLine.Substring(0, 3) == "215")
				{
					// Add the status response line to the log window
					txtLog.AppendText(ListLine + "\r\n");
				}
				else
				{
					// Add the newsgroup to the combobox
					string[] Newsgroup = ListLine.Split(' ');
					lstNewsgroups.Items.Add(Newsgroup[0]);
				}
			}
		}

		private void GetNews()
		{
			// If a newsgroup is selected in the ComboBox
			if (lstNewsgroups.SelectedIndex != -1)
			{
				// Request a certain newsgroup
				byteSendInfo = StringToByteArr("GROUP " + lstNewsgroups.SelectedItem.ToString() + "\r\n");
				strRemote.Write(byteSendInfo, 0, byteSendInfo.Length);
				Response = "";
				bytesSize = strRemote.Read(downBuffer, 0, 2048);
				//Response = System.Text.Encoding.ASCII.GetString(downBuffer, 0, bytesSize);
				// Split the information about the newsgroup by blank spaces
				string[] Group = System.Text.Encoding.ASCII.GetString(downBuffer, 0, bytesSize).Split(' ');
				// Show information about the newsgroup in the txtLog TextBox
				if (Group.Length > 0)
				{
					Response += Group[0] + " " + Group[1] + " messages in the group (" + Group[2] + "..." + Group[3] + ")\r\n";
					// The ID of the first article in this newsgroup
					firstID = Convert.ToInt32(Group[2]);
					// The ID of the last article in this newsgroup
					lastID = Convert.ToInt32(Group[3]);
				}
				else
					Response += "004 Unexpected answer form server\r\n";
				txtLog.AppendText(Response);
				Response = "";

			}
			else
			{
				MessageBox.Show("Please connect to a server and select a newsgroup from the dropdown list first.", "Newsgroup retrieval", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private bool NextArticle()
		{
			bool ret = false;
			if (tcpClient != null && tcpClient.Connected == true /*&& firstID >= 0*/ && lstNewsgroups.SelectedIndex != -1)
			{
				// Request the next article
				byteSendInfo = StringToByteArr("NEXT\r\n");
				strRemote.Write(byteSendInfo, 0, byteSendInfo.Length);
				bytesSize = strRemote.Read(downBuffer, 0, 2048);
				string[] Group = System.Text.Encoding.ASCII.GetString(downBuffer, 0, bytesSize).Split(' ');
				// Show information about the article in the txtLog TextBox
				if (Group.Length > 0 && Group[0] == "223")
				{
					Response += Group[0] + " Next article ID is " + Group[1] + "\r\n";
					// The ID of the next article
					firstID = Convert.ToInt32(Group[1]);
					ret = true;
				}
				else if (Group.Length > 0 && Group[0] == "421")
				{
					Response += "421 Last article\r\n";
				}
				else
				{
					Response += "Unexpected answer form server\r\n";
				}
				//txtLog.AppendText(System.Text.Encoding.ASCII.GetString(downBuffer, 0, bytesSize));
				txtLog.AppendText(Response /*+ firstID + "\r\n"*/);
				Response = "";
			}
			return ret;
		}

		/// <summary>
		/// 0 - ok,
		/// 1 - no article,
		/// 2 - last article,
		/// 3 - not connected/no newsgroup.
		/// </summary>
		/// <returns></returns>
		private string GetHead()
		{
			if (tcpClient != null && tcpClient.Connected == true /*&& firstID >= 0*/ && lstNewsgroups.SelectedIndex != -1)
			{
				string headTmp = "";
				// Get the header
				txtHead.Text = "";
				// Initialize the buffer to 2048 bytes
				downBuffer = new byte[2048];
				// Request the headers of the article
				byteSendInfo = StringToByteArr("HEAD " + firstID + "\r\n");
				// Send the request to the NNTP server
				strRemote.Write(byteSendInfo, 0, byteSendInfo.Length);
				while ((bytesSize = strRemote.Read(downBuffer, 0, downBuffer.Length)) > 0)
				{
					NewChunk = System.Text.Encoding.ASCII.GetString(downBuffer, 0, bytesSize);
					headTmp += NewChunk;
					// No such article in the group
					if (NewChunk.Substring(0, 3) == "423")
					{
						// Ready for the next article, unless there is nothing else there...
						if (firstID >= lastID)
						{
							txtLog.AppendText("002 Last article\r\n");
							return null;
						}
						else
						{
							txtLog.AppendText("001 No such article\r\n");
							// Next article please
							//firstID++;
							//NextArticle();
							// End this method because it's retrieving a nonexistent article
							return null;
						}
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
			else
			{
				MessageBox.Show("Please select a newsgroup from the dropdown list and click on 'Get News' first.", "Newsgroup retrieval", MessageBoxButtons.OK, MessageBoxIcon.Error);
				txtLog.AppendText("003 Not connected/Newsgroup not selected\r\n");
				return null;
			}
		}


		private string GetBody()
		{
			if (tcpClient != null && tcpClient.Connected == true /*&& firstID >= 0*/ && lstNewsgroups.SelectedIndex != -1)
			{
				string bodyTmp = "";
				// Get the body
				txtBody.Text = "";
				// Initialize the buffer to 2048 bytes
				downBuffer = new byte[2048];
				// Request the headers of the article
				byteSendInfo = StringToByteArr("BODY " + firstID + "\r\n");
				// Send the request to the NNTP server
				strRemote.Write(byteSendInfo, 0, byteSendInfo.Length);
				while ((bytesSize = strRemote.Read(downBuffer, 0, downBuffer.Length)) > 0)
				{
					NewChunk = System.Text.Encoding.ASCII.GetString(downBuffer, 0, bytesSize);
					bodyTmp += NewChunk;
					// If the last thing in the buffer is "\r\n.\r\n" the message's finished
					if (NewChunk.Length < 5)
					{
						break;
						//txtLog.AppendText("Short chunk at the end of message.\r\n");
					}
					if (NewChunk.Substring(NewChunk.Length - 5, 5) == "\r\n.\r\n")
					{
						break;
					}
				}
				txtLog.AppendText("000 Displaying article\r\n");
				//txtBody.Text = bodyTmp;
				return bodyTmp;
				// Ready for the next article, unless there is nothing else there...
				//if (firstID < lastID)
				//{
				//	//firstID++;
				//	txtLog.AppendText("000 Ready for the next article\r\n");
				//}
				//else
				//{
				//	txtLog.AppendText("002 Last article\r\n");
				//}
			}
			else
			{
				MessageBox.Show("Please select a newsgroup from the dropdown list and click on 'Get News' first.", "Newsgroup retrieval", MessageBoxButtons.OK, MessageBoxIcon.Error);
				txtLog.AppendText("003 Not connected/Newsgroup not selected\r\n");
				return null;
			}
		}

		private void GetHeads()
		{
			while (NextArticle())
			{

			}
		}

		/// <summary>
		/// Quit server when closing
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
				Response = "";
				bytesSize = strRemote.Read(downBuffer, 0, 2048);
				Response = System.Text.Encoding.ASCII.GetString(downBuffer, 0, bytesSize);
				string mess = System.Text.Encoding.ASCII.GetString(downBuffer, 0, bytesSize);
				txtLog.AppendText(mess);
				//MessageBox.Show(mess, "test", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}