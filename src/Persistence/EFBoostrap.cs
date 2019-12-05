using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Persistence
{
    public static class EFBoostrap
    {
        public static void ConfigureServices_InfrastructureDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            string migrationsAssembly = typeof(DataContext).GetTypeInfo().Assembly.GetName().Name;

            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(connectionString, sqlOptions =>
                    {
                        sqlOptions.MigrationsAssembly(migrationsAssembly);
                        sqlOptions.EnableRetryOnFailure(maxRetryCount: 15,
                            maxRetryDelay: TimeSpan.FromSeconds(30),
                            errorNumbersToAdd: null);
                    }
                ), ServiceLifetime.Transient);

        }

        public static void Configure_InfrastructureDatabase(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                DataContext context = scope.ServiceProvider.GetService<DataContext>();
                context.Database.Migrate();
            }
        }
    }
}
