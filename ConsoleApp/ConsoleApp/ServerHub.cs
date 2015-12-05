using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Threading.Tasks;

namespace ConsoleApp
{
    [HubName("ServerHub")]
    public class ServerHub : Hub
    {
        public void Send(string message)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<ServerHub>();
            context.Clients.All.addMessage(message);
        }

        public override Task OnConnected()
        {
            Console.WriteLine("Client connected: " + Context.ConnectionId);
            return base.OnConnected();
        }
    }
}
