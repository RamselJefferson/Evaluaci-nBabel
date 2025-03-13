using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Core.Application.Interfaces.Repositorys;
using Infrastructure.Persistance.Repository;
using Core.Application.Interfaces.Services;
using Infrastructure.Persistance.Services;

namespace Infrastructure.Persistance
{
    public static class ServiceRegistration
    {
        public static void AddPersistanceInfrastructure(this IServiceCollection svc, IConfiguration config)
        {


            // Registrar DbConnection
            svc.AddSingleton<IDbConnection>(sp =>
                new SqlConnection(config.GetConnectionString("DefaultConnection")));

            svc.AddTransient<IOrderRepository, OrderRepository>();
            svc.AddTransient<IOrderService, OrderService>();



        }
    }
}
