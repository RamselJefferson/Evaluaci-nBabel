using AutoMapper.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Reflection;

namespace Core.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            

        }
    }
}
