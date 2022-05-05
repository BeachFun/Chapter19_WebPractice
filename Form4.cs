using System;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Chapter19_WebPractice
{
	public partial class Form4 : Form
	{
		Socket server = null;
		Socket client = null;

		public Form4()
		{
			InitializeComponent();
		}

		private void serverStartButton_Click(object sender, EventArgs e)
		{
			if (server != null && server.Connected)
				server.Disconnect(false);

			int port;
			try
			{
				port = int.Parse(portTextBox.Text);
            }
            catch
            {
				MessageBox.Show($"Не удалось запустить сервер на указанном порте ({portTextBox.Text})");
				return;
            }

			server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			EndPoint endPoint = new IPEndPoint(IPAddress.Any, port);

			string Host = Dns.GetHostName();
			string IP = Dns.GetHostByName(Host).AddressList[0].ToString();

			Message(IP, endPoint.ToString());

			try
			{
				server.Bind(endPoint);
				server.Listen(100);
			}
			catch (Exception exc)
			{
				MessageBox.Show($"Невозможно запустить сервер: {exc.Message}");
				return;
			}

			server.BeginAccept(new AsyncCallback(AcyncAcceptCallback), server);
		}

		async void Message(string IP, string endPoint)
        {
			await Task.Run(() => MessageBox.Show($"IP-адрес сервера: {IP}\nПорт сервера: {endPoint}"));
		}

		private void connectToServerButton_Click(object sender, EventArgs e)
		{
			if (client != null && client.Connected)
				client.Disconnect(false);

			IPAddress addr = GetAddress(serverAddressTextBox.Text);

			if(addr == null)
			{
				MessageBox.Show("Я в шоке, не смог разобрать адрес");
				return;
			}

			client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			EndPoint point = new IPEndPoint(addr, 33777);

			try
			{
				client.Connect(point);
			}
			catch (Exception exc)
			{
				MessageBox.Show($"Ошибка соединения: {exc.Message}");
			}
		}

		private void SendToServerButton_Click(object sender, EventArgs e)
		{
			if(client == null || !client.Connected)
			{
				MessageBox.Show("Сначала соединитесь с сервером");
				return;
			}

			client.Send(Encoding.ASCII.GetBytes(commandTextBox.Text));

			byte[] buffer = new byte[1024];
			int bytes = client.Receive(buffer);

			if (bytes > 0)
			{
				string s = Encoding.UTF8.GetString(buffer, 0, bytes);
				richTextBox1.AppendText($"{s}\n");
			}
		}

		void AcyncAcceptCallback(IAsyncResult result)
		{
			Socket serverSocket = result.AsyncState as Socket;

			SocketData data = new SocketData();
			data.ClientConnection = serverSocket.EndAccept(result);

			data.ClientConnection.BeginReceive(data.Buffer, 0, 1024, SocketFlags.None, new AsyncCallback(ReadCallback), data);
		} // По-моему вызывается один раз, когда к серверу подключается клиент, и принимает только одно сообщение, потом программа крашится

		void ReadCallback(IAsyncResult result)
		{
			SocketData data = result.AsyncState as SocketData;
			int bytes = data.ClientConnection.EndReceive(result);

			if(bytes > 0)
			{
				string s = Encoding.UTF8.GetString(data.Buffer, 0, bytes);
				Console.WriteLine($"Получено сообщение от клиента: {s}");
				data.ClientConnection.Send(Encoding.UTF8.GetBytes($"Сообщение от сервера -> получено: {s.Length} символов"));
			}
		} // Получает сообщения от клиента, вроде

		public IPAddress GetAddress(string address)
		{
			IPAddress ipAddress = null;

			try
			{
				ipAddress = IPAddress.Parse(address);
			}
			catch (Exception)
			{
				IPHostEntry heserver;

				try
				{
					heserver = Dns.GetHostEntry(address);

					if (heserver.AddressList.Length == 0) return null;

					ipAddress = heserver.AddressList[0];
				}
				catch
				{
					return null;
				}
			}

			return ipAddress;
		}

		class SocketData
		{
			public const int BufferSize = 1024;

			byte[] buffer = new byte[BufferSize];

			public Socket ClientConnection { get; set; }

			public byte[] Buffer
			{
				get => buffer;
				set => buffer = value;
			}
		}
	}
}
