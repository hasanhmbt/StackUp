using MediatR;
using Microsoft.Extensions.DependencyInjection;
using StackUp.Application.ApplicationServices.Services;
using StackUp.Application.MappingProfiles;
using System.Reflection;

namespace StackUp.Application.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ProductProfile), typeof(CategoryProfile), typeof(SupplierProfile), typeof(OrderProfile), typeof(InventoryProfile), typeof(CustomerProfile), typeof(OrderDetailsProfile));

            services.AddScoped<ProductService>();
            services.AddScoped<CategoryService>();
            services.AddScoped<OrderService>();
            services.AddScoped<SupplierService>();
            services.AddScoped<InventoryService>();
            services.AddScoped<CustomerService>();
            services.AddScoped<OrderDetailsService>();



            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

            return services;
        }
    }
}
