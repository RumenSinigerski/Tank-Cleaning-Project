using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using TankCleaningProject.Data;
using TankCleaningProject.Data.Models;

namespace TankCleaningProject.Infrastructure
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder PrepareDatabase(
           this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            var services = serviceScope.ServiceProvider;

            MigrateDatabase(services);

            SeedProductType(services);
            //SeedAdministrator(services);

            return app;
        }

        private static void MigrateDatabase(IServiceProvider services)
        {
            var data = services.GetRequiredService<ApplicationDbContext>();

            data.Database.Migrate();
        }

        //private static void SeedAdministrator(IServiceProvider services)
        //{
        //    throw new NotImplementedException();
        //}

        private static void SeedProductType(IServiceProvider services)
        {
            var data = services.GetRequiredService<ApplicationDbContext>();

            if (data.ProductTypes.Any())
            {
                return;
            }

            data.ProductTypes.AddRange(new[]
            {
                new ProductType { Name = "Food", Price = 50.00 },
                new ProductType { Name = "ADR" , Price = 60.00}
                
            });

            data.SaveChanges();
        }

       
    }
}
