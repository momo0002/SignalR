using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace Web.Hubs
{
    [HubName("MyHub")]
    public class MyHub : Hub
    {
        public void Send(string message)
        {
            Clients.All.SendMessage(message);
        }
    }
}