using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EventBus;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

public class BaseEventBus : IEventBus
{
    private readonly Dictionary<string, List<object>> _handlers = new Dictionary<string, List<object>>();
    private readonly ConnectionFactory _connectionFactory;
    private readonly IConnection _connection;
    private readonly IModel _channel;

    public BaseEventBus()
    {
        _connectionFactory = new ConnectionFactory() { HostName = "localhost" };
        _connection = _connectionFactory.CreateConnection();
        _channel = _connection.CreateModel();
    }

    public void Subscribe<TEvent>(IEventHandler<TEvent> handler)
    {
        var eventName = GetEventName<TEvent>();

        if (!_handlers.TryGetValue(eventName, out var handlers))
        {
            handlers = new List<object>();
            _handlers[eventName] = handlers;

            _channel.ExchangeDeclare(eventName, ExchangeType.Fanout);

            var queueName = _channel.QueueDeclare().QueueName;

            _channel.QueueBind(queueName, eventName, "");

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var @event = JsonConvert.DeserializeObject<TEvent>(message);
                handler.HandleAsync(@event);
            };
            _channel.BasicConsume(queue: queueName, autoAck: false, consumer: consumer);
        }

        handlers.Add(handler);
    }

    public async Task PublishAsync<TEvent>(TEvent @event)
    {
        var eventName = GetEventName<TEvent>();
        var message = JsonConvert.SerializeObject(@event);
        var body = Encoding.UTF8.GetBytes(message);
        _channel.BasicPublish(exchange: eventName, routingKey: "", basicProperties: null, body: body);
    }

    private string GetEventName<TEvent>()
    {
        return typeof(TEvent).Name;
    }
}
