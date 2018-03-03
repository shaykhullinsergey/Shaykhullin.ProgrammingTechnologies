using RusherNetLib.Core;
using RusherNetLib.NetClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestClient
{
	public partial class MainWindow : Form
	{
		private readonly IClient client;

		public MainWindow()
		{
			InitializeComponent();

			client = new Client()
					.AddHandler(ClientType.Connected, OnConnected)
					.AddHandler(ClientType.Received, OnReceived)
					.AddHandler(ClientType.Disconnected, OnDisconnected)
					.Connect("127.0.0.12", 4000);
		}

		private void OnDisconnected(IConnection conn, IMessage msg)
		{
			MessageBox.Show("Disconnected!");
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
			else if(msg["Type"] == "PrivateSend")
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
				if (loop.Any())
				{
					loop.Dequeue()();
				}

				await Task.Delay(100);
			}
		}
	}
}
