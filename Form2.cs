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
	public partial class Form2 : Form
	{
		private HttpClient httpClient = new HttpClient();
		public Form2()
		{
			InitializeComponent();
		}

		private void downloadB_Click(object sender, EventArgs e)
		{
			DownloadCodePageInTextBox();
		}

		private void httpRequest_Enter(object sender, EventArgs e)
        {
			DownloadCodePageInTextBox();
		}

		private async void DownloadCodePageInTextBox()
		{
			try
			{
				Uri url = new Uri(httpRequest.Text);

				await Task.Run(() => httpClient.GetPageStatus(url));

				pageCode.Text = httpClient.PageContent.ToString();
            }
            catch { }
		}

	}
}
