using Ecopetrol.Api.API.Common.Settings;
using Ecopetrol.Api.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;

namespace Ecopetrol.Api.IoC.Configuration.Data
{
    public static class EntityFrameworkConfiguration
    {
        public static void ConfigureEntityFramework(this IServiceCollection services, IConfiguration configuration)
        {
            var appSettingsSection = configuration.GetSection(nameof(AppSettings));
            if (appSettingsSection == null)
                throw new System.Exception("No appsettings section has been found");

            var connectionString = "Data Source=ecopetrol.database.windows.net;Persist Security Info=True;User ID=dba;Password=P@ssword11;Initial Catalog=ecopetrol;";
            services.AddDbContext<FaqDbContext>(opts => opts.UseSqlServer(connectionString), ServiceLifetime.Scoped);
        }
    }
}
