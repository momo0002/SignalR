using Microsoft.AspNet.SignalR.Client;
using System;
using System.Net.Http;

namespace ConsoleApp2
{   
    class Program
    {
        private static IHubProxy HubProxy { get; set; }
        const string ServerURI = "http://localhost:23373/";
        private static HubConnection Connection { get; set; }

        static void Main(string[] args)
        {
            ConnectAsync();
            Console.ReadLine();
        }

        private static async void ConnectAsync()
        {
            Connection = new HubConnection(ServerURI);
            HubProxy = Connection.CreateHubProxy("MyHub");

            
            try
            {
                await Connection.Start();                
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("Unable to connect to server: Start server before connecting clients. " + e.InnerException);
                //No connection: Don't enable Send button or show chat UI
                return;
            }
            Console.WriteLine("Connected to server at " + ServerURI + Environment.NewLine);
        }
    }
}
