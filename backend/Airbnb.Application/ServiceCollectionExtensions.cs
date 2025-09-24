using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Airbnb.Application.Services;
using Airbnb.Application.Interfaces;

namespace Airbnb.Application
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServiceCollectionExtensions).Assembly));
            services.AddAutoMapper(typeof(ServiceCollectionExtensions).Assembly);
            services.AddValidatorsFromAssembly(typeof(ServiceCollectionExtensions).Assembly);

            // Register application services
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
