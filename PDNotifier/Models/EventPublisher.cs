using Autofac.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDNotifier.Models
{
    public class EventPublisher : IEventPublisher
    {
        public void Publish(object @event)
        {
            throw new NotImplementedException();
        }
    }
}
