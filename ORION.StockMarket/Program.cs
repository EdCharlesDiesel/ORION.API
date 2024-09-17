using Microsoft.EntityFrameworkCore;
using ORION.StockMarket.DataAccess.DbContexts;
using ORION.StockMarket.DataAccess.Services;
using Serilog;
namespace ORION.StockMarket
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                //.WriteTo.()
                //.WriteTo.File("logs/cityinfo.txt", rollingInterval: RollingInterval.Day)

                .CreateLogger();
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<OrionSalesPersonDbContext>(
                dbContextOptions => dbContextOptions.UseSqlServer(
                    builder.Configuration["ConnectionStrings:Orion_StockMarket_ConnectionString"]));

            builder.Services.AddScoped<ISalesPersonRepository, SalesPersonRepository>();

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
