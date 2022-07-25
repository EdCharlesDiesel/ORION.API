// using Microsoft.Extensions.Configuration;
// using Microsoft.Extensions.DependencyInjection;

// namespace ORION.DBTest
// {
//     public class Startup
//     {
//         public Startup(IConfiguration configuration)
//         {
//             Configuration = configuration;
//         }

//         public IConfiguration Configuration { get; }

//         // This method gets called by the runtime. Use this method to add services to the container.
//         public void ConfigureServices(IServiceCollection services)
//         {
//             // services.Configure<CookiePolicyOptions>(options =>
//             // {
//             //     // This lambda determines whether user consent for non-essential cookies is needed for a given request.
//             //     options.CheckConsentNeeded = context => true;
//             // });

//             // services.AddControllersWithViews();
//             // services.AddRazorPages();
//             // services.AddDbLayer(Configuration.GetConnectionString("DefaultConnection"),
//             //     "SABBGDB");

//             // services.AddAllQueries(this.GetType().Assembly);
//             // services.AddAllCommandHandlers(this.GetType().Assembly);
//             // services.AddAllEventHandlers(this.GetType().Assembly);
//         }      
//     }
// }
