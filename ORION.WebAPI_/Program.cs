using Asp.Versioning.ApiExplorer;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.OpenApi.Models;
using ORION.WebAPI.DbContexts;
using ORION.WebAPI.Services;
using Serilog;
using System.Reflection;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()    
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

//builder.Logging.ClearProviders();
//builder.Logging.AddConsole();

var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");




//if (environment == Environments.Development)
//{
//    builder.Host.UseSerilog(
//        (context, loggerConfiguration) => loggerConfiguration
//            .MinimumLevel.Debug()
//            .WriteTo.Console());
//}
//else
//{
//    var secretClient = new SecretClient(
//            new Uri("https://pluralsightdemokeyvault.vault.azure.net/"),
//            new DefaultAzureCredential());
//    builder.Configuration.AddAzureKeyVault(secretClient,
//        new KeyVaultSecretManager());

//    builder.Host.UseSerilog(
//        (context, loggerConfiguration) => loggerConfiguration
//            .MinimumLevel.Debug()
//            .WriteTo.Console()
//            .WriteTo.File("logs/cityinfo.txt", rollingInterval: RollingInterval.Day)
//            .WriteTo.ApplicationInsights(new TelemetryConfiguration
//            {
//                InstrumentationKey = builder.Configuration["ApplicationInsightsInstrumentationKey"]
//            }, TelemetryConverter.Traces));
//}


// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.ReturnHttpNotAcceptable = true;
})
.AddXmlDataContractSerializerFormatters();

builder.Services.AddProblemDetails();
//builder.Services.AddProblemDetails(options =>
//{
//    options.CustomizeProblemDetails = ctx =>
//    {
//        ctx.ProblemDetails.Extensions.Add("additionalInfo",
//            "Additional info example");
//        ctx.ProblemDetails.Extensions.Add("server", 
//            Environment.MachineName);
//    };
//});

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

//builder.Services.AddAuthentication("Bearer")
//    .AddJwtBearer(options =>
//    {
//        options.TokenValidationParameters = new()
//        {
//            ValidateIssuer = true,
//            ValidateAudience = true,
//            ValidateIssuerSigningKey = true,
//            ValidIssuer = builder.Configuration["Authentication:Issuer"],
//            ValidAudience = builder.Configuration["Authentication:Audience"],
//            IssuerSigningKey = new SymmetricSecurityKey(
//               Convert.FromBase64String(builder.Configuration["Authentication:SecretForKey"]))
//        };
//    }
//    );

//builder.Services.AddAuthorization(options =>
//{
//    options.AddPolicy("MustBeFromAntwerp", policy =>
//    {
//        policy.RequireAuthenticatedUser();
//        policy.RequireClaim("city", "Antwerp");
//    });
//});

//builder.Services.AddApiVersioning(setupAction =>
//{
//    setupAction.ReportApiVersions = true;
//    setupAction.AssumeDefaultVersionWhenUnspecified = true;
//    setupAction.DefaultApiVersion = new ApiVersion(1, 0);
//}).AddMvc()
//.AddApiExplorer(setupAction =>
//{
//    setupAction.SubstituteApiVersionInUrl = true;
//});

// Learn more about configuring Swagger/OpenAPI at
// https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//var apiVersionDescriptionProvider = builder.Services.BuildServiceProvider()
//  .GetRequiredService<IApiVersionDescriptionProvider>();

builder.Services.AddSwaggerGen(setupAction =>
{
    //foreach (var description in
    //    apiVersionDescriptionProvider.ApiVersionDescriptions)
    //{
    setupAction.SwaggerDoc(
        $"zxczxc",
        new()
        {
            Title = "City Info API",
            Description = "Through this API you can access cities and their points of interest."
        });

    });

    var xmlCommentsFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentsFile);

    //setupAction.IncludeXmlComments(xmlCommentsFullPath);

    //setupAction.AddSecurityDefinition("CityInfoApiBearerAuth", new()
    //{
    //    Type = SecuritySchemeType.Http,
    //    Scheme = "Bearer",
    //    Description = "Input a valid token to access this API"
    //});

    //setupAction.AddSecurityRequirement(new()
    //{
    //    {
    //        new ()
    //        {
    //            Reference = new OpenApiReference {
    //                Type = ReferenceType.SecurityScheme,
    //                Id = "CityInfoApiBearerAuth" }
    //        },
    //        new List<string>()
    //    }
    //});
//});

builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders = ForwardedHeaders.XForwardedFor
    | ForwardedHeaders.XForwardedProto;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler();
}

app.UseForwardedHeaders();


//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
//app.UseSwaggerUI(setupAction =>
//{
//    var descriptions = app.Dis();
//    foreach (var description in descriptions)
//    {
//        setupAction.SwaggerEndpoint(
//            $"/swagger/{description.GroupName}/swagger.json",
//            description.GroupName.ToUpperInvariant());
//    }
//});
//}

app.UseHttpsRedirection();

app.UseRouting();

//app.UseAuthentication();

//app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
