public class BaseEventBus
{
    private readonly Dictionary<Type, List<object>> _handlers = new Dictionary<Type, List<object>>();

    public void Subscribe<TEvent>(IEventHandler<TEvent> handler)
    {
        var eventType = typeof(TEvent);

        if (!_handlers.TryGetValue(eventType, out var handlers))
        {
            handlers = new List<object>();
            _handlers[eventType] = handlers;
        }

        handlers.Add(handler);
    }

    public async Task PublishAsync<TEvent>(TEvent @event)
    {
        var eventType = typeof(TEvent);

        if (_handlers.TryGetValue(eventType, out var handlers))
        {
            foreach (var handler in handlers)
            {
                if (handler is IEventHandler<TEvent> eventHandler)
                {
                    await eventHandler.HandleAsync(@event);
                }
            }
        }
    }
}
