using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RusherNetLib.Core;
using RusherNetLib.NetServer;

namespace TestServer
{
	class Program
	{
		private static string LocalAddress = Dns.GetHostEntry(Dns.GetHostName()).AddressList
			.Last(x => x.AddressFamily == AddressFamily.InterNetwork)
			.ToString();

		private static readonly int LocalPortPort = 4000;

		private static List<Person> persons = new List<Person>();

		static void Main(string[] args)
		{
			Console.WriteLine(LocalAddress);

			Task.Run(() =>
			{
				var multicastAddress = IPAddress.Parse("224.12.12.12");
				const int milticastPort = 4000;

				var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
				socket.Bind(new IPEndPoint(IPAddress.Any, milticastPort));
				socket.MulticastLoopback = true;

				socket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.AddMembership,
					new MulticastOption(multicastAddress, IPAddress.Any));

				var multicastEndPoint = new IPEndPoint(multicastAddress, milticastPort) as EndPoint;

				while (true)
				{
					var data = new byte[100];
					Console.WriteLine("START");
					socket.ReceiveFrom(data, ref multicastEndPoint);
					Console.WriteLine("END");

					var str = Encoding.ASCII.GetString(data).Trim('\0');

					Console.WriteLine(str);
					var separator = str.IndexOf(":", StringComparison.Ordinal);
					var remoteAddress = str.Substring(0, separator);
					var remotePort = int.Parse(str.Substring(separator + 1));

					socket.SendTo(Encoding.ASCII.GetBytes(LocalAddress + ":" + LocalPortPort),
						new IPEndPoint(IPAddress.Parse(remoteAddress), remotePort));

					Thread.Sleep(1000);
				}
			});

			Thread.Sleep(1000);

			var server = new Server()
					.AddHandler(ServerType.Started, OnStarted)
					.AddHandler(ServerType.Accepted, OnAccepted)
					.AddHandler(ServerType.Sended, OnSended)
					.AddHandler(ServerType.Received, OnReceived)
					.AddHandler(ServerType.Disconnected, OnDisconnected)
					.AddHandler(ServerType.Stopped, OnStopped)
					.Start(LocalAddress, LocalPortPort);

			Console.ReadLine();
			server.Stop();
			Console.ReadLine();
		}
		//Когда сервер стартовал
		private static void OnStarted(IConnection conn, IMessage msg)
		{
			Console.WriteLine("OnStarted");
		}
		//Когда сервер принял клиент
		private static void OnAccepted(IConnection conn, IMessage msg)
		{
			var p = new Person
			{
				Name = Guid.NewGuid().ToString(),
				Connection = conn
			};
			persons.Add(p);
			Console.WriteLine($"OnAccepted: {p.Name}");

			var name = conn.CreateMessage();
			name["Type"] = "Name";
			name["Name"] = p.Name;
			conn.Send(name);

			Thread.Sleep(1000);

			foreach (var person in persons)
			{
				var message = person.Connection.CreateMessage();
				message["Type"] = "List";
				message["List"] = string.Join(",", persons.Select(x => x.Name).ToArray());
				person.Connection.Send(message);

				Thread.Sleep(1000);

				message["Type"] = "Send";
				message["Author"] = "SERVER";
				message["Text"] = $"Connected {p.Name}";
				person.Connection.Send(message);
			}
		}
		private static void OnSended(IConnection conn, IMessage msg)
		{
			var person = persons.First(x => x.Connection == conn);

			Console.WriteLine($"OnSended: {person.Name}");
		}
		private static void OnReceived(IConnection conn, IMessage msg)
		{
			if (msg["Type"] == "Send")
			{
				var person = persons.First(x => x.Connection == conn);

				msg["Author"] = person.Name;
				foreach (var p in persons.Where(x => x != person))
				{
					p.Connection.Send(msg);
				}

				msg["Author"] = "You";
				person.Connection.Send(msg);
			}
			else if (msg["Type"] == "PrivateSend")
			{
				var person = persons.First(x => x.Connection == conn);

				var message = conn.CreateMessage();
				message["Type"] = "PrivateSend";
				message["Author"] = person.Name;
				message["Text"] = msg["Text"];

				var names = msg["Persons"].Split(',');
				foreach (var name in names)
				{
					var psn = persons.First(x => x.Name == name);
					psn.Connection.Send(message);
				}
			}
		}
		private static void OnDisconnected(IConnection conn, IMessage msg)
		{
			var p = persons.First(x => x.Connection == conn);
			persons.Remove(p);
			Console.WriteLine($"OnDisconnected: {p.Name}");

			Thread.Sleep(1000);
			foreach (var person in persons)
			{
				var message = person.Connection.CreateMessage();
				message["Type"] = "List";
				message["List"] = string.Join(",", persons.Select(x => x.Name).ToArray());
				person.Connection.Send(message);

				Thread.Sleep(1000);

				message["Type"] = "Send";
				message["Author"] = "SERVER";
				message["Text"] = $"Disconnected {p.Name}";
				person.Connection.Send(message);
			}
		}
		private static void OnStopped(IConnection conn, IMessage msg)
		{
			Console.WriteLine("OnStopped");
		}
	}

	class Person
	{
		public string Name { get; set; }
		public IConnection Connection { get; set; }
	}
}

