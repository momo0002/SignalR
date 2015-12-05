using Microsoft.AspNet.SignalR.Client;
using System;
using System.Net.Http;

namespace ConsoleApp2
{   
    public class Client
    {
        private static IHubProxy HubProxy { get; set; }
        const string ServerURI = "http://localhost:8080";
        private static HubConnection Connection { get; set; }

        static void Main(string[] args)
        {
            ConnectAsync();
            Console.ReadLine();
        }

        private static async void ConnectAsync()
        {
            Connection = new HubConnection(ServerURI);
            HubProxy = Connection.CreateHubProxy("ServerHub");

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
            var line = "Hello";

            try
            {
                await HubProxy.Invoke("Send", line);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.InnerException);
            }
                         
        }
    }
}
