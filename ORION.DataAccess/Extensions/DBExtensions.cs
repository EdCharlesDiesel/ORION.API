using DDD.DomainLayer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ORION.DataAccess.Contexts;
using ORION.DataAccess.Models;

namespace ORION.DataAccess.Extensions
{
    public static class DBExtensions
    {
        public static IServiceCollection AddDbLayer(this IServiceCollection services,
            string connectionString, string migrationAssembly)
        {
            services.AddDbContext<OrionDbContext>(options =>
                options.UseSqlServer(connectionString, b => b.MigrationsAssembly(migrationAssembly)));
         //   services.AddIdentity<MasterUser, IdentityRole<int>>()
           //     .AddEntityFrameworkStores<OrionDbContext>()
           //     .AddDefaultTokenProviders();
            services.AddAllRepositories(typeof(DBExtensions).Assembly);
            return services;
        }

        public static async Task Seed(this OrionDbContext context, IServiceScope serviceScope)
        {
            //await context.Database.MigrateAsync();

            //if (!await context.Roles.AnyAsync())
            //{
            //    var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole<int>>>();
            //    var role = new IdentityRole<int> { Name = "Admins" };
            //    await roleManager.CreateAsync(role);

            //}
            // if (!await context.Users.AnyAsync())
            // {

            //     var userManager = serviceScope.ServiceProvider.GetService<UserManager<MasterUser>>();
            //     string user = "Admin";
            //     string password = "_Admin_pwd1";
            //     MasterUser currUser = null;
            //     var result = await userManager.CreateAsync(currUser = new MasterUser { UserName = user, Email = "admin@Orion.com", EmailConfirmed = true }, password);

            //     await userManager.AddToRoleAsync(currUser, "Admins");

            //  }

            if (!await context.Categories.AnyAsync())
            {
                var firstCategory = new Category
                {
                    CategoryName = "PC",
                    Description = "Personal Computers",
                    
                    Products = new List<Product>()
                        {
                            //new Product
                            //{
                            //    ProductName = "MacBook Pro M1",
                            //    StartValidityDate = new DateTime(2019, 6, 1),
                            //    EndValidityDate = new DateTime(2019, 10, 1),
                            //    DurationInDays = 7,
                            //    UnitPrice = 1000,
                            //    EntityVersion = 1
                            //},
                            //new Product
                            //{
                            //    ProductName = "MacBook Pro M2",
                            //    StartValidityDate = new DateTime(2019, 12, 1),
                            //    EndValidityDate = new DateTime(2020, 2, 1),
                            //    DurationInDays=7,
                            //    UnitPrice=500,
                            //    EntityVersion=1
                            //}
                        }
                };
                context.Categories.Add(firstCategory);
                await context.SaveChangesAsync();
            }
        }
    }
}
