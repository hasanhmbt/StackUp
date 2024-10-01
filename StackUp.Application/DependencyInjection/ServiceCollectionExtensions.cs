using Microsoft.Extensions.DependencyInjection;
using StackUp.Application.MappingProfiles;
using StackUp.Application.Services;

namespace StackUp.Application.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {

            services.AddAutoMapper(typeof(ProductProfile));


            services.AddScoped<ProductService>();


            return services;
        }
    }
}
