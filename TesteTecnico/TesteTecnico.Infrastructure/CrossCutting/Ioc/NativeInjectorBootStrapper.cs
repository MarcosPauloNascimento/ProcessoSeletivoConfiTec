using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using TesteTecnico.Application;
using TesteTecnico.Application.Interfaces;
using TesteTecnico.Domain.Core.Interfaces.Repositories;
using TesteTecnico.Domain.Core.Interfaces.Services;
using TesteTecnico.Domain.Core.Notifications;
using TesteTecnico.Domain.Services;
using TesteTecnico.Infrastructure.Data;
using TesteTecnico.Infrastructure.Data.Repositories;

namespace TesteTecnico.Infrastructure.CrossCutting.Ioc
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {

            // API
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // APPLICATION
            services.AddScoped<IApplicationServiceUser, ApplicationServiceUser>();

            // Domain  
            services.AddTransient<SqlContext>();
            services.AddScoped<IServiceUser, ServiceUser>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<INotifier, Notifier>();

        }
    }
}