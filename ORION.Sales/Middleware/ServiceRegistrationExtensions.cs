﻿using ORION.Sales.DataAccess.DbContexts;

namespace ORION.Sales.Middleware
{
    public static class ServiceRegistrationExtensions
    {
        public static IServiceCollection RegisterBusinessServices(
            this IServiceCollection services)
        {
            services.AddScoped<IEmployeeService, EmployeeService>();
            //services.AddScoped<IPromotionService, PromotionService>();
            //services.AddScoped<EmployeeFactory>();
            return services;
        }

        public static IServiceCollection RegisterDataServices(
            this IServiceCollection services, IConfiguration configuration)
        {
            // add the DbContext
            services.AddDbContext<OrionSalesDbContext>(options =>
                options.UseSQ(configuration.GetConnectionString("EmployeeManagementDB")));

            // register the repository
            //services.AddScoped<IEmployeeManagementRepository, EmployeeManagementRepository>();
            return services;
        }
    }
}
