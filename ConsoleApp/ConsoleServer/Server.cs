using System;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;

namespace ConsoleApp
{
    public class Server
    {
        private static IDisposable SignalR { get; set; }
        const string ServerURI = "http://localhost:8080/signalr";

        static void Main(string[] args)
        {
            Console.WriteLine("Starting server...");
            Task.Run(() => StartServer());
            Console.ReadLine();
        }

        private static void StartServer()
        {
            try
            {
                SignalR = WebApp.Start(ServerURI);
            }
            catch (TargetInvocationException e)
            {
                Console.WriteLine("Server failed to start. A server is already running on " + ServerURI + e.InnerException);
                return;
            }

            Console.WriteLine("Server started at " + ServerURI);
        }
    }
}
