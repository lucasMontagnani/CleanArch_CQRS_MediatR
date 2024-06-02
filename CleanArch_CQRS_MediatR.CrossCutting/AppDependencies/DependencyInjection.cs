using CleanArch_CQRS_MediatR.Application.Members.Commands.Validations;
using CleanArch_CQRS_MediatR.Domain.Abstractions;
using CleanArch_CQRS_MediatR.Infrastructure.Context;
using CleanArch_CQRS_MediatR.Infrastructure.Repositories;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch_CQRS_MediatR.CrossCutting.AppDependencies
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Registrando conexao com o banco
            var mySqlConnection = configuration.GetConnectionString("DefaultConnecetion");
            services.AddDbContext<AppDbContext>(options => options.UseMySql(mySqlConnection, new MySqlServerVersion(new Version(8, 0, 37))));

            // Registrar IDbConnection como instância única
            services.AddSingleton<IDbConnection>(provider =>
            {
                var connection = new MySqlConnection(mySqlConnection);
                connection.Open();
                return connection;
            });

            // Registrar MediatR
            var myHandlers = AppDomain.CurrentDomain.Load("CleanArch_CQRS_MediatR.Application");
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblies(myHandlers);
                cfg.AddOpenBehavior(typeof(ValidationBehaviour<,>));
            });

            // Registrando Injecoes de Dependencia
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IMemberRepository, MemberRepository>();
            services.AddScoped<IMemberDapperRepository, MemberDapperRepository>();

            // Registrando validador de commands
            services.AddValidatorsFromAssembly(Assembly.Load("CleanArch_CQRS_MediatR.Application"));

            return services;
        }
    }
}
