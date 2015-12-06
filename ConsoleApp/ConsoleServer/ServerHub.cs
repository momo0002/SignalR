using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Threading.Tasks;

namespace ConsoleServer
{
    [HubName("ServerHub")]
    public class ServerHub : Hub
    {
        public void Send(string message)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<ServerHub>();
            context.Clients.All.addMessage(message);
            Console.WriteLine(message);
        }

        public override Task OnConnected()
        {
            Console.WriteLine("Client connected: " + Context.ConnectionId);
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            Console.WriteLine("Client Disconnected: " + Context.ConnectionId);
            return base.OnDisconnected(stopCalled);
        }

        public override Task OnReconnected()
        {
            Console.WriteLine("Client reconnected: " + Context.ConnectionId);
            return base.OnReconnected();
        }
    }
}
