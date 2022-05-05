using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace Chapter19_WebPractice
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void downloadB_Click(object sender, EventArgs e)
		{
			WebRequest request;
			try
			{
				string reqStr = httpRequest.Text;

				request = HttpWebRequest.Create(reqStr);

				HttpWebResponse response = request.GetResponse() as HttpWebResponse;
				StreamReader reader = new StreamReader(response.GetResponseStream());
				StringBuilder pageBuilder = new StringBuilder();

				string line;
				while ((line = reader.ReadLine()) != null)
					pageBuilder.AppendLine(line);

				response.Close();
				reader.Close();

				pageCode.Text = pageBuilder.ToString();
			}
			catch
			{
				MessageBox.Show("Page not founded!");
			}
		}
	}
}
