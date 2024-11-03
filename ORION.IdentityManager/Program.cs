using ORION.IdentityManager;

var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddDbContext<ApplicationDbContext>();


var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
