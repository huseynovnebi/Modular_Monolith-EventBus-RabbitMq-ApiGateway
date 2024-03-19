using EventBus;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Payment;
using PaymentAPI.Events;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
//builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IEventBus, BaseEventBus>();
builder.Services.AddSingleton<PaymentHandler>();
builder.Services.AddSingleton<PaymentService>();

var app = builder.Build();

var eventBus = app.Services.GetRequiredService<IEventBus>();

app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection(); // You can comment out or remove this line if you're not using HTTPS




var paymentHandler = app.Services.GetRequiredService<PaymentHandler>();
eventBus.Subscribe<OrderCreatedIntegrationEvent>(paymentHandler);

// Here, you need to define a default route to handle incoming requests

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
//app.UseAuthorization();
app.Run();
