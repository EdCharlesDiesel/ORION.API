using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace ORION.DataAccess.Contexts
{
    public class OrionDesignTimeDbContextFactory
        : IDesignTimeDbContextFactory<OrionDbContext>
    {
        private const string  connectionString =
            @"Server=(localdb)\mssqllocaldb;Database=ORION_MainDb;
                Trusted_Connection=True;MultipleActiveResultSets=true";
        public OrionDbContext CreateDbContext(params string[] args)
        {
            var builder = new DbContextOptionsBuilder<OrionDbContext>();
            
            builder.UseSqlServer(connectionString);
            return new OrionDbContext(builder.Options);
        }
    

       public OrionDbContext Create()
        {
            var environmentName =
                Environment.GetEnvironmentVariable(
                    "ASPNETCORE_ENVIRONMENT");

            var basePath = AppContext.BaseDirectory;

            return Create(basePath, environmentName);
        }

        // TODO Investigte 
        // public OrionDbContext CreateDbContext(string[] args)
        // {
        //     return Create(
        //         Directory.GetCurrentDirectory(),
        //         Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"));
        // }

        private OrionDbContext Create(string basePath, string environmentName)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{environmentName}.json", true)
                .AddEnvironmentVariables();

            var config = builder.Build();

            var connstr = config.GetConnectionString("default");

            if (String.IsNullOrWhiteSpace(connstr) == true)
            {
                throw new InvalidOperationException(
                    "Could not find a connection string named 'default'.");
            }
            else
            {
                return Create(connstr);
            }
        }

        private OrionDbContext Create(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentException(
             $"{nameof(connectionString)} is null or empty.",
             nameof(connectionString));

            var optionsBuilder =
                 new DbContextOptionsBuilder<OrionDbContext>();

            Console.WriteLine(
                "OrionDesignTimeDbContextFactory.Create(string): Connection string: {0}",
                connectionString);

            optionsBuilder.UseSqlServer(connectionString);

            return new OrionDbContext(optionsBuilder.Options);
        }
    }
}
