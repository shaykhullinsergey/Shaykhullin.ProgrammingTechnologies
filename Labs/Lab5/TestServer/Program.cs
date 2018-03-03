using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using RusherNetLib.Core;
using RusherNetLib.NetServer;

namespace TestServer
{
  class Program
  {
		private static List<Person> persons = new List<Person>();

    static void Main(string[] args)
    {
      var server = new Server()
          .AddHandler(ServerType.Started, OnStarted)
          .AddHandler(ServerType.Accepted, OnAccepted)
          .AddHandler(ServerType.Sended, OnSended)
          .AddHandler(ServerType.Received, OnReceived)
          .AddHandler(ServerType.Disconnected, OnDisconnected)
          .AddHandler(ServerType.Stopped, OnStopped)
          .Start("127.0.0.12", 4000);

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

			Thread.Sleep(100);

			foreach (var person in persons)
			{
				var message = person.Connection.CreateMessage();
				message["Type"] = "List";
				message["List"] = string.Join(",", persons.Select(x => x.Name).ToArray());
				person.Connection.Send(message);

				Thread.Sleep(100);

				message["Type"] = "Send";
				message["Author"] = "SERVER";
				message["Text"] = $"Connected {p.Name}";
				person.Connection.Send(message);
			}
		}
    //Когда сервер отослал данные
    private static void OnSended(IConnection conn, IMessage msg)
    {
			var person = persons.First(x => x.Connection == conn);

			Console.WriteLine($"OnSended: {person.Name}");
    }
    //Когда сервер принял данные
    private static void OnReceived(IConnection conn, IMessage msg)
    {
			if(msg["Type"] == "Send")
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
    //Когда сервер отключил клиент
    private static void OnDisconnected(IConnection conn, IMessage msg)
    {
			var p = persons.First(x => x.Connection == conn);
			persons.Remove(p);
			Console.WriteLine($"OnDisconnected: {p.Name}");

			Thread.Sleep(100);
			foreach (var person in persons)
			{
				var message = person.Connection.CreateMessage();
				message["Type"] = "List";
				message["List"] = string.Join(",", persons.Select(x => x.Name).ToArray());
				person.Connection.Send(message);

				Thread.Sleep(100);

				message["Type"] = "Send";
				message["Author"] = "SERVER";
				message["Text"] = $"Disconnected {p.Name}";
				person.Connection.Send(message);
			}
		}
    //Когда сервер остановился
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

