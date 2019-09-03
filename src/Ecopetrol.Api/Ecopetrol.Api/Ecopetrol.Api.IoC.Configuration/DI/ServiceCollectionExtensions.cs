using AutoMapper;
using Ecopetrol.Api.API.Common.Settings;
using Ecopetrol.Api.IoC.Configuration.AutoMapper;
using Ecopetrol.Api.Services;
using Ecopetrol.Api.Services.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Ecopetrol.Api.IoC.Configuration.DI
{
    public static class ServiceCollectionExtensions
    {
        public static AppSettings ConfigureBusinessServices(this IServiceCollection services, IConfiguration configuration)
        {
            var appSettingsSection = configuration.GetSection(nameof(AppSettings));
            if (appSettingsSection == null)
                throw new System.Exception("No appsettings section has been found");

            var appSettings = appSettingsSection.Get<AppSettings>();

            if (!appSettings.IsValid())
                throw new Exception("No valid settings.");

            services.Configure<AppSettings>(appSettingsSection);

            //Automap settings
            services.AddAutoMapper();
            var mapper = MappingConfigurationsHelper.ConfigureMapper();
            services.AddSingleton<IMapper>(mapper);


            services.AddTransient<IUserService, UserService>();

            return appSettings;
        }
    }
}
