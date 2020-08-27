namespace Presentation.API.Components
{
    using DAL.RabbitMQ.Consumers.Implementations;
    using Infrastructure.CrossCutting.Settings.Implementations;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Options;

    public static class RabbitComponents
    {
        public static IServiceCollection AddRabbitMQConsumers(this IServiceCollection services)
        {
            services.AddSingleton(p => new TicketStateChangedConsumer(p.GetService<IOptions<RabbitMQSettings>>().Value));

            return services;
        }
    }
}
