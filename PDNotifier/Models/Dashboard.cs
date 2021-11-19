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

        public void Notify(string msg)
        {
            OnChange?.Invoke(this, new MessageEvent { 
                Message = msg
            });
        }
    }
}
