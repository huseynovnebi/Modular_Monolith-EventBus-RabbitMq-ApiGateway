using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBus
{
    public interface IEventBus
    {
        void Subscribe<TEvent>(IEventHandler<TEvent> handler);
        Task PublishAsync<TEvent>(TEvent @event);
    }
}
