using System.Threading.Tasks;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using AngleSharp;

namespace ORION.IntegrationTests.Tests
{
    public class UserInterfaceTest:
         IClassFixture<WebApplicationFactory<ORION.Admin.Startup>>
    {
        private readonly
            WebApplicationFactory<ORION.Admin.Startup> _factory;
        public UserInterfaceTest(WebApplicationFactory<ORION.Admin.Startup> factory)
        {
            _factory = factory;
        }

        [Fact(Skip = "DeletePostSuccessTest")]
        public async Task TestMenu()
        {
            var client = _factory.CreateClient();
            
            //Create an angleSharp default configuration
            var config = Configuration.Default;

            //Create a new context for evaluating webpages 
            //with the given config
            var context = BrowsingContext.New(config);

            var response = await client.GetAsync("/");
            response.EnsureSuccessStatusCode();
            string source = await response.Content.ReadAsStringAsync();
            var document = await context.OpenAsync(req =>
                req.Content(source));
            var node = document.QuerySelector("a[href=\"/Home\"]");   

            Assert.NotNull(node);
        }
    }
}
