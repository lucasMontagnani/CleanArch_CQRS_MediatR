using CleanArch_CQRS_MediatR.Domain.Abstractions;
using CleanArch_CQRS_MediatR.Infrastructure.Context;
using CleanArch_CQRS_MediatR.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch_CQRS_MediatR.CrossCutting.AppDependencies
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var mySqlConnection = configuration.GetConnectionString("DefaultConnecetion");

            services.AddDbContext<AppDbContext>(options => options.UseMySql(mySqlConnection, new MySqlServerVersion(new Version(8, 0, 37))));

            // Registrar IDbConnection como instância única
            services.AddSingleton<IDbConnection>(provider =>
            {
                var connection = new MySqlConnection(mySqlConnection);
                connection.Open();
                return connection;
            });

            services.AddScoped<IMemberRepository, MemberRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Registrar MediatR
            var myHandlers = AppDomain.CurrentDomain.Load("CleanArch_CQRS_MediatR.Application");
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(myHandlers));
                        
            services.AddScoped<IMemberDapperRepository, MemberDapperRepository>();

            return services;
        }
    }
}
