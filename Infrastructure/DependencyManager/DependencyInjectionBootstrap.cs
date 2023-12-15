using Application.Common.Behaviour;
using Application.Common.Helpers;
using Application.Common.Interfaces;
using Application.Common.Interfaces.Repository;
using Application.Common.Interfaces.Utility;
using Confluent.Kafka;
using FluentValidation;
using Infrastructure.Persistence.Factories;
using Infrastructure.Persistence.Interceptors;
using Infrastructure.Persistence.Repositories;
using Infrastructure.Services;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Reflection;

namespace Infrastructure.DependencyManager
{
    public static class DependencyInjectionBootstrap
    {
        public static IServiceCollection AddSpecialServices(this IServiceCollection services, IConfiguration configuration)
        {
            var conString = configuration.GetValue<string>("DefaultConnection");
            services.AddDbContext<SalesDbContext>(options =>
            {
                options.UseSqlServer(conString);
            });

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddHttpClient();
            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddScoped(typeof(IMongoRepository<>), typeof(MongoRepository<>));
            services.AddSingleton<BaseClientHelper>();
            services.AddTransient<IUnitOfWork, UoW>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddScoped<AuditableEntitySaveChangesInterceptor>();
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IDateTime, DateTimeService>();
            return services;
        }
    }
}
