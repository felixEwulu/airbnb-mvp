using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Airbnb.Application.Services;
using Airbnb.Domain.Repositories;
using Airbnb.Infrastructure.Repositories;

namespace Airbnb.Application
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(typeof(ServiceCollectionExtensions).Assembly);
            services.AddAutoMapper(typeof(ServiceCollectionExtensions).Assembly);
            services.AddValidatorsFromAssembly(typeof(ServiceCollectionExtensions).Assembly);

            // Register service implementations
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
