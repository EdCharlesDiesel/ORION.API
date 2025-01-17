﻿using Microsoft.EntityFrameworkCore;
using ORION.Sales.DataAccess.DbContexts;
using ORION.Sales.DataAccess.Services;

namespace ORION.Sales.Middleware
{
    public static class ServiceRegistrationExtensions
    {
        public static IServiceCollection RegisterBusinessServices(
            this IServiceCollection services)
        {
            services.AddScoped<ICreditCardRepository, CreditCardRepository>();
            //services.AddScoped<IPromotionService, PromotionService>();
         //   services.AddScoped<EmployeeFactory>();
            return services;
        }

        public static IServiceCollection RegisterDataServices(
            this IServiceCollection services, IConfiguration configuration)
        {
            // add the DbContext
            services.AddDbContext<OrionSalesDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("EmployeeManagementDB")));

            // register the repository
            //services.AddScoped<IEmployeeManagementRepository, EmployeeManagementRepository>();
            return services;
        }
    }
}
