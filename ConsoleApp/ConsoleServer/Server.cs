using System;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;

namespace ConsoleServer
{
    public class Server
    {
        const string ServerURI = "http://localhost:8080";

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
                using (WebApp.Start(ServerURI))
                {
                    Console.WriteLine("Server running on {0}", ServerURI);
                    Console.ReadLine();
                }
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
