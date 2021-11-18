using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDNotifier
{
    public class Dashboard : ISend<MessageEvent>
    {
        public event EventHandler<MessageEvent> OnChange = delegate { };

        public void Notify()
        {
            OnChange?.Invoke(this, new MessageEvent { 
                Message = "The situation on streets is peaceful." 
            });
        }
    }
}
