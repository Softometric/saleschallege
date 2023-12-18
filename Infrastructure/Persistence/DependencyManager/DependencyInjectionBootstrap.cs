using Application.Common.Behaviour;
using Application.Common.Interfaces.Repository;
using Infrastructure.Persistence.Factories;
using Infrastructure.Persistence.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Infrastructure.Persistence.DependencyManager
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

            services.AddHttpClient();
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddTransient<IUnitOfWork, UoW>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IInventoryRepository, InventoryRepository>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
          //  services.AddTransient<IDateTime, DateTimeService>();
            return services;
        }
    }
}
