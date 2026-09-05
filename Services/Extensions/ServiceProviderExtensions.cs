using Films.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;   // ← додай цей using

namespace Films.Services.Extensions
{
    public static class ServiceCollectionExtensions   // ← ось цей клас обов’язковий
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<ICreate, CreateService>();
            services.AddTransient<IEdit, EditService>();
            services.AddTransient<IDelete, DeleteService>();
            services.AddTransient<IDetails, DetailsService>();
        }
    }
}
