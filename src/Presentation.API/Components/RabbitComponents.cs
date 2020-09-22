namespace Presentation.API.Components
{
    using BLL.RabbitMQ.Consumers.Implementations;
    using BLL.Services.Interfaces;
    using Infrastructure.CrossCutting.Settings.Implementations;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Options;

    public static class RabbitComponents
    {
        public static IServiceCollection AddRabbitMQConsumers(this IServiceCollection services)
        {
            var rabbitSettings = services.BuildServiceProvider().GetRequiredService<IOptions<RabbitMQSettings>>().Value;
            var dbSettings = services.BuildServiceProvider().GetRequiredService<IOptions<MongoDBConnection>>().Value;
            services.AddSingleton(p => new TicketStateChangedEventConsumer(rabbitSettings,dbSettings));
            services.AddSingleton(p => new TicketReassignedEventConsumer(rabbitSettings, dbSettings));
            services.AddSingleton(p => new TicketCreatedEventConsumer(rabbitSettings, dbSettings));
            services.AddSingleton(p => new TicketFieldsUpdatedEventConsumer(rabbitSettings, dbSettings));

            return services;
        }
    }
}
