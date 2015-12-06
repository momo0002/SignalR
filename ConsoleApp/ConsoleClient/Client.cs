using Microsoft.AspNet.SignalR.Client;
using System;
using System.Net.Http;

namespace ConsoleClient
{   
    public class Client
    {
        private static IHubProxy HubProxy { get; set; }
        const string ServerURI = "http://localhost:8080/signalr";
        private static HubConnection Connection { get; set; }

        static void Main(string[] args)
        {
            ConnectAsync();

            string line = null;
            while ((line = Console.ReadLine()) != null)
            {
                var message = new Messages(line, DateTime.Now);
                try
                {
                    HubProxy.Invoke("Send", message.ToString()).Wait();
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine(e.InnerException);
                }
            }

            Console.ReadLine();
        }

        private static async void ConnectAsync()
        {
            Connection = new HubConnection(ServerURI);
            HubProxy = Connection.CreateHubProxy("ServerHub");

            HubProxy.On("Send", message => Console.WriteLine(message));

            try
            {
                //await Connection.Start().ContinueWith(t => Console.WriteLine("Connected.."));
                await Connection.Start();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("Unable to connect to server: Start server before connecting clients. " + e.InnerException);
                //No connection: Don't enable Send button or show chat UI
                return;
            }
        }
    }
}
