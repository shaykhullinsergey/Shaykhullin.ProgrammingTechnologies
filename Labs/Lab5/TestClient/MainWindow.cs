using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;

using RusherNetLib.Core;
using RusherNetLib.NetClient;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace TestClient
{
	public partial class MainWindow : Form
	{
		private readonly IPAddress multicastAddress = IPAddress.Parse("224.12.12.12");
		private readonly int multicastPort = 4000;

		private readonly IPAddress localAddress = IPAddress.Parse("127.0.0.1");
		private readonly int localPort = 4001;

		private readonly IPAddress remoteAddress;
		private readonly int remotePort;

		private readonly IClient client;

		public MainWindow()
		{
			InitializeComponent();

			using (var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp))
			{
				socket.Bind(new IPEndPoint(localAddress, localPort));

				socket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.AddMembership, 
					new MulticastOption(multicastAddress, localAddress));

				var multicastEndPoint = new IPEndPoint(multicastAddress, multicastPort) as EndPoint;
				socket.SendTo(Encoding.ASCII.GetBytes($"{localAddress}:{localPort}"), multicastEndPoint);

				var data = new byte[100];
				socket.ReceiveFrom(data, ref multicastEndPoint);

				var str = Encoding.ASCII.GetString(data).Trim('\0');
				var separator = str.IndexOf(":");
				remoteAddress = IPAddress.Parse(str.Substring(0, separator));
				remotePort = int.Parse(str.Substring(separator + 1));
			}

			client = new Client()
					.AddHandler(ClientType.Connected, OnConnected)
					.AddHandler(ClientType.Received, OnReceived)
					.AddHandler(ClientType.Disconnected, OnDisconnected)
					.Connect(remoteAddress.ToString(), remotePort);
		}

		private void OnDisconnected(IConnection conn, IMessage msg)
		{
			MessageBox.Show("Connection lost!");
			Application.Exit();
		}

		private void OnReceived(IConnection conn, IMessage msg)
		{
			if (msg["Type"] == "List")
			{
				loop.Enqueue(() =>
				{
					listBox1.Items.Clear();
					listBox1.Items.AddRange(msg["List"].Split(','));
				});
			}
			else if (msg["Type"] == "Name")
			{
				loop.Enqueue(() =>
				{
					Text = msg["Name"];
				});
			}
			else if (msg["Type"] == "Send")
			{
				loop.Enqueue(() =>
				{
					messages.AppendText($"{msg["Author"]}: {msg["Text"]}\n");
				});
			}
			else if (msg["Type"] == "PrivateSend")
			{
				loop.Enqueue(() =>
				{
					messages.AppendText($"FROM {msg["Author"]}: {msg["Text"]}\n");
				});
			}
		}

		private void OnConnected(IConnection conn, IMessage msg)
		{
			MessageBox.Show("Connected! " + conn.SocketError);
		}

		private void SendClicked(object sender, EventArgs e)
		{
			if (listBox1.SelectedItems.Count == 0)
			{
				var msg = client.CreateMessage();
				msg["Type"] = "Send";
				msg["Text"] = inputTextBox.Text;
				client.Send(msg);
			}
			else
			{
				var msg = client.CreateMessage();
				msg["Type"] = "PrivateSend";
				msg["Persons"] = string.Join(",", listBox1.SelectedItems.Cast<string>().Where(x => x != Text));
				msg["Text"] = inputTextBox.Text;
				client.Send(msg);
			}

			inputTextBox.Text = "";
			listBox1.SelectedItems.Clear();
		}

		private Queue<Action> loop = new Queue<Action>();
		private async void MainWindow_Load(object sender, EventArgs e)
		{
			while (true)
			{
				while (loop.Any())
				{
					loop.Dequeue()();
				}

				await Task.Delay(100);
			}
		}
	}
}
