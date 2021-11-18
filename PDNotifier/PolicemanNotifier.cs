using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDNotifier
{
    public class PolicemanNotifier : IHandle<MessageEvent>
    {
        public void Handle(object sender, MessageEvent args)
        {
            Console.WriteLine($"New message from Dashboard: {args.Message}");
        }
    }
}
