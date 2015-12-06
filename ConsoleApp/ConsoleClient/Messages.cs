using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleClient
{
    public class Messages
    {
        private string message { get; set; }

        private DateTime time;
        private DateTime Time {
            get {
                return time;
            }
            set
            {
                value = DateTime.Now;
            }
        }

        public Messages() { }

        public Messages(string message, DateTime time)
        {
            this.message = message;
            this.time = time;
        }

        public override string ToString()
        {
            return Time + ": " + message ;
        }
    }
}
