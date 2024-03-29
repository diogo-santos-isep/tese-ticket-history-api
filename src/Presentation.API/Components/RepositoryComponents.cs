﻿namespace Presentation.API.Components
{
    using DAL.Repositories.Interfaces;
    using DAL.Repositories.Implementations;
    using Microsoft.Extensions.DependencyInjection;
    public static class RepositoryComponents
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ITicketActionRepository, TicketActionRepository>();

            return services;
        }
    }
}
