using Microsoft.AspNet.SignalR;
using System;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class MyHub : Hub
    {
        public void Send(string message, string time)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<MyHub>();
            context.Clients.All.addMessage(message, time);
        }

        public override Task OnConnected()
        {
            Console.WriteLine("Client connected: " + Context.ConnectionId);
            return base.OnConnected();
        }
    }
}
