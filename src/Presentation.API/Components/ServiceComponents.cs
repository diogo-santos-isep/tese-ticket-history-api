﻿namespace Presentation.API.Components
{
    using BLL.Services.Interfaces;
    using BLL.Services.Implementations;
    using Microsoft.Extensions.DependencyInjection;
    public static class ServiceComponents
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ITicketActionService, TicketActionService>();

            return services;
        }
    }
}
