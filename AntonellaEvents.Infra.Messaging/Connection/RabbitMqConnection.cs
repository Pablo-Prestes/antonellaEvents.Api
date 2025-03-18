using AntonellaEvents.Infra.Messaging.Consumers;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace AntonellaEvents.Infra.Messaging.Connection
{
    public static class RabbitMqConnection
    {
        public static void AddRabbitMqService(this IServiceCollection services)
        {
            services.AddMassTransit(busConfigurator =>
            {
                busConfigurator.AddConsumer<EventCreatedConsumer>();

                busConfigurator.UsingRabbitMq((ctx, cfg) =>
                {
                    cfg.Host(new Uri("amqp://localhost:5672"), host => 
                    {
                        host.Username("guest");
                        host.Password("guest");

                        cfg.ConfigureEndpoints(ctx);
                    });

					cfg.ReceiveEndpoint("event-created-queue", e =>
					{
						e.UseMessageRetry(r => r.Interval(3, TimeSpan.FromSeconds(5)));
						e.ConfigureConsumer<EventCreatedConsumer>(ctx);
					});
				});
            });
        }
    }
}
