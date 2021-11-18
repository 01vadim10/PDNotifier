using System;
using System.Collections.Generic;
using System.Text;

namespace PDNotifier
{
    public interface ISend<TEvent> where TEvent : IEvent
    {
        public event EventHandler<TEvent> OnChange;
    }
}
