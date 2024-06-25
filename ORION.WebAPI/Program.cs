//Log.Logger = new LoggerConfiguration()
//    .MinimumLevel.Debug()
//    .CreateLogger();

using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using ORION.WebAPI.DbContexts;
using ORION.WebAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.ReturnHttpNotAcceptable = true;
})
.AddXmlDataContractSerializerFormatters();

builder.Services.AddProblemDetails();

builder.Services.AddSingleton<FileExtensionContentTypeProvider>();

#if DEBUG
builder.Services.AddTransient<IMailService, LocalMailService>();
#else 
builder.Services.AddTransient<IMailService, CloudMailService>();
#endif
//builder.Services.AddSingleton<CitiesDataStore>();
IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
builder.Services.AddDbContext<OrionContext>(options => options.UseSqlServer(configuration.GetConnectionString("OrionConnectionStrings")));

builder.Services.AddScoped<IShiftRepository, ShiftRepository>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddSwaggerGen(setupAction =>
//{    
//    setupAction.SwaggerDoc(
//        $"zxczxc",
//        new()
//        {
//            Title = "ORION API",
//            Description = "Through this API you can access data from ORION"
//        });

//});

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
