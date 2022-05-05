using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Windows.Forms;

namespace Chapter19_WebPractice
{
	class MainClass
	{
		static void Main()
        {
            Console.WindowHeight = 16;
            Console.WindowWidth = 80;
            Console.BufferHeight = 16;
            Console.BufferWidth = 80;

            OpenForm4();
		}


		[STAThread]
		static void OpenForm1()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form1());
		}


		[STAThread]
		static void OpenForm2()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form2());
		}


		[STAThread]
		static void OpenForm3()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form3());
		}


		[STAThread]
		static void OpenForm4()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form4());
		}


		static void ShowPageCodeInConsole()
		{
			WebRequest request;
			try
			{
				request = HttpWebRequest.Create("https://vk.com/audios468614009?section=all");

				HttpWebResponse response = request.GetResponse() as HttpWebResponse;
				StreamReader reader = new StreamReader(response.GetResponseStream());
				StringBuilder pageBuilder = new StringBuilder();

				string line;
				while ((line = reader.ReadLine()) != null)
					pageBuilder.AppendLine(line);

				response.Close();
				reader.Close();

				Console.WriteLine(pageBuilder.ToString());
			}
			catch
			{
				Console.WriteLine("Page not founded!");
			}
		}
	}
}
