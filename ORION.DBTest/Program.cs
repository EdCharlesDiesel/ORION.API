using System;
using System.Collections.Generic;
using System.Linq;
using ORION.DataAccess.Contexts;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using ORION.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace ORION.DBTest
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {

            Console.WriteLine("Program just started: Populating database, please press key to proceed...");
            Console.ReadKey();

            var context = new OrionDesignTimeDbContextFactory()
                .CreateDbContext();
            var firstCategory = new Category
            {
                CategoryName = "Design Patterns",
                Description = "Computer Programming",
                
                
                Products = new List<Product>()
                    {
                        new Product
                        {
                            //ProductName = "C# 9 and .NET 5 - Modern Cross-Platform Development",
                            //Description = "The new MacBook Pro with the best power efficient processor M1",
                            //StartValidityDate = new DateTime(2019, 6, 1),
                            //EndValidityDate = new DateTime(2019, 10, 1),
                            //DurationInDays = 5,
                            //UnitPrice = 1000,
                            //EntityVersion = 1
                        },
                        new Product
                        {
                            //ProductName = "Head First Design Patterns",
                            //Description = "The new MacBook Pro with the best power efficient processor M2",
                            //StartValidityDate = new DateTime(2019, 12, 1),
                            //EndValidityDate = new DateTime(2020, 2, 1),
                            //DurationInDays=71,
                            //UnitPrice=1750,
                            //EntityVersion=1
                        }
                        
                    }
            };
            context.Categories.Add(firstCategory);
            await context.SaveChangesAsync();

            Console.WriteLine(
                "DB populated: first Category id is " +
                firstCategory.Id);
           // ModifyCategory();
        }

        public static void ModifyCategory()
        {
            Console.WriteLine("Program just started: Populating database, please press key to proceed...b");
            Console.ReadKey();

            var context = new OrionDesignTimeDbContextFactory()
                .CreateDbContext();

            var toModify = context.Categories
                .Where(m => m.CategoryName == "PC")
                .Include(m => m.Products)
                .FirstOrDefault();

            toModify.Description =
                            "Desktop and Laptops";
            //foreach (var product in toModify.Products)
            //    product.UnitPrice = product.UnitPrice * 1.1m;
            context.SaveChanges();

            var verifyChanges = context.Categories
                    .Where(m => m.CategoryName == "PC")
                    .FirstOrDefault();

            Console.WriteLine(
                "New description: " +
                verifyChanges.Description);

            Console.WriteLine("Press Key to continue");
            Console.ReadKey();

            var period = new DateTime(2019, 8, 10);
            
            //var list = context.Products
            //    .Where(m => period >= m.StartValidityDate
            //    && period <= m.EndValidityDate)
            //    .Select(m => new ProductListDTO
            //    {
            //        StartValidityDate = m.StartValidityDate,
            //        EndValidityDate = m.EndValidityDate,
            //        ProductName = m.ProductName,
            //        DurationInDays = m.DurationInDays,
            //        Id = m.Id,
            //        UnitPrice = m.UnitPrice,
            //        CategoryId = m.CategoryId
            //    })
            //    .ToList();

            //foreach (var result in list)
                //Console.WriteLine(result.ToString());
            Console.WriteLine("Please press any key when done");
            Console.ReadKey();
        }
        
        public static void TestWeatherData()
        {
            WeatherData weatherData = new WeatherData();

            CurrentConditionsDisplay currentConditionsDisplay =
            new CurrentConditionsDisplay(weatherData);

            StatisticsDisplay statisticsDisplay = new StatisticsDisplay(weatherData);
            ForecastDisplay forecastDisplay = new ForecastDisplay(weatherData);

            weatherData.setMeasurements(80,65,30.4f);
            weatherData.setMeasurements(82,70,29.2f);
            weatherData.setMeasurements(78,90,29.2f);
        }

        //TODO Make use of this code or remove it
        #region CommentedCodeWillUseLater
            // Console.WriteLine("To Add users please press any key");
            // Console.ReadKey();
          //  Seed(context, )
       // }

        // public static async Task Seed(this OrionDbContext context, IServiceScope serviceScope)
        // {
        //     await context.Database.MigrateAsync();

        //     if (!await context.Roles.AnyAsync())
        //     {
        //         var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole<int>>>();
        //         var role = new IdentityRole<int> { Name = "Admins" };
        //         await roleManager.CreateAsync(role);
        //     }

        //     if (!await context.Roles.AnyAsync())
        //     {
        //         var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole<int>>>();
        //         var role = new IdentityRole<int> { Name = "Developers" };
        //         await roleManager.CreateAsync(role);
        //     }

        //     if (!await context.Roles.AnyAsync())
        //     {
        //         var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole<int>>>();
        //         var role = new IdentityRole<int> { Name = "BusinessOwners" };
        //         await roleManager.CreateAsync(role);
        //     }

        //     if (!await context.Roles.AnyAsync())
        //     {
        //         var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole<int>>>();
        //         var role = new IdentityRole<int> { Name = "SuperUsers" };
        //         await roleManager.CreateAsync(role);
        //     }

        //     if (!await context.Roles.AnyAsync())
        //     {
        //         var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole<int>>>();
        //         var role = new IdentityRole<int> { Name = "NormalUsers" };
        //         await roleManager.CreateAsync(role);
        //     }

        //     if (!await context.Users.AnyAsync())
        //     {

        //         var userManager = serviceScope.ServiceProvider.GetService<UserManager<MasterUser>>();
        //         string user = "Admin";
        //         string password = "_Admin_pwd1";
        //         MasterUser currUser = null;
        //         var result = await userManager.CreateAsync(currUser = new MasterUser
        //                                                     {
        //                                                         UserName = user, 
        //                                                         Email = "admin@sabbg.online", 
        //                                                         EmailConfirmed = true 
        //                                                     },  password);

        //         await userManager.AddToRoleAsync(currUser, "Admins");
        //     } 

        //     if (!await context.Users.AnyAsync())
        //     {

        //         var userManager = serviceScope.ServiceProvider.GetService<UserManager<MasterUser>>();
        //         string user = "Khotso";
        //         string password = "_khotsoPassword_";
        //         MasterUser currUser = null;
        //         var result = await userManager.CreateAsync(currUser = new MasterUser
        //                                                     {
        //                                                         UserName = user, 
        //                                                         Email = "khotso@Orion.com", 
        //                                                         EmailConfirmed = true 
        //                                                     },  password);

        //         await userManager.AddToRoleAsync(currUser, "Developers");
        //     }  

        //     if (!await context.Users.AnyAsync())
        //     {

        //         var userManager = serviceScope.ServiceProvider.GetService<UserManager<MasterUser>>();
        //         string user = "thuto";
        //         string password = "_thutoPassword_";
        //         MasterUser currUser = null;
        //         var result = await userManager.CreateAsync(currUser = new MasterUser
        //                                                     {
        //                                                         UserName = user, 
        //                                                         Email = "thuto@sabbg.online", 
        //                                                         EmailConfirmed = true 
        //                                                     },  password);

        //         await userManager.AddToRoleAsync(currUser, "SuperUsers");
        //     } 

        //     if (!await context.Users.AnyAsync())
        //     {

        //         var userManager = serviceScope.ServiceProvider.GetService<UserManager<MasterUser>>();
        //         string user = "mosawenkosi";
        //         string password = "_khotsoPassword_";
        //         MasterUser currUser = null;
        //         var result = await userManager.CreateAsync(currUser = new MasterUser
        //                                                     {
        //                                                         UserName = user, 
        //                                                         Email = "mosawenkosi@sabbg.online", 
        //                                                         EmailConfirmed = true 
        //                                                     },  password);

        //         await userManager.AddToRoleAsync(currUser, "NormalUsers");
        //     } 

        //     if (!await context.Users.AnyAsync())
        //     {

        //         var userManager = serviceScope.ServiceProvider.GetService<UserManager<MasterUser>>();
        //         string user = "Matema";
        //         string password = "_matemaPassword_";
        //         MasterUser currUser = null;
        //         var result = await userManager.CreateAsync(currUser = new MasterUser
        //                                                     {
        //                                                         UserName = user, 
        //                                                         Email = "matema@sabbg.online", 
        //                                                         EmailConfirmed = true 
        //                                                     },  password);

        //         await userManager.AddToRoleAsync(currUser, "BusinessOwners");
        //     }            
     //   }      
        #endregion
              
    }

    internal class StatisticsDisplay
    {
        public StatisticsDisplay(WeatherData weatherData)
        {
            WeatherData = weatherData;
        }

        public WeatherData WeatherData { get; }
    }

    internal class ForecastDisplay
    {
        private WeatherData weatherData;

        public ForecastDisplay(WeatherData weatherData)
        {
            this.weatherData = weatherData;
        }
    }
}
