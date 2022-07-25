
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using ORION.DataAccess.Services;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace ORION.IntegrationTests.Tests
{
    public class BusinessOwnerRoutingFixture
    {
        private WebApplicationFactory<ORION.Admin.Startup> _SystemUnderTest;
        public WebApplicationFactory<ORION.Admin.Startup> SystemUnderTest
        {
            get
            {
                if (_SystemUnderTest == null)
                {
                    _SystemUnderTest =
                        new WebApplicationFactory<ORION.Admin.Startup>();
                }

                return _SystemUnderTest;
            }
        }

        private async Task PopulateTestData()
        {
            var client = SystemUnderTest.CreateDefaultClient();

            var response = await client.GetAsync("/businessOwner/VerifyDatabaseIsPopulated");

            Assert.NotNull(response);

            int statusCodeAsInt = (int)response.StatusCode;

            Assert.True(statusCodeAsInt < 400);
        }

        private int GetBusinessOwnerIdByName(string firstName, string lastName)
        {
            var client = SystemUnderTest.CreateDefaultClient();
            
            var hostServices = SystemUnderTest.Server.Host.Services;

            var scopeFactory = hostServices.GetService(
                typeof(IServiceScopeFactory)) as IServiceScopeFactory;

            using (IServiceScope scope = scopeFactory.CreateScope())
            {
                var businessOwnerService = 
                    scope.ServiceProvider.GetService(
                        typeof(IBusinessOwnerService)) as IBusinessOwnerService;

                Assert.NotNull(
                    businessOwnerService);

                var match = businessOwnerService.Search(
                    firstName, lastName).FirstOrDefault();

                Assert.NotNull(match);

                return match.Id;
            }           
        }

       [Fact]
        public async Task Utility_GetBusinessOwnerIdByFirstNameLastName()
        {
            var client =
                SystemUnderTest.CreateDefaultClient();

            await PopulateTestData();

            var actual = GetBusinessOwnerIdByName("jimmy", "carter");

            Assert.True(actual > 0);
        }

        [Fact]
        public async Task LoadBusinessOwnerByLastNameFirstName()
        {
            var client = 
                SystemUnderTest.CreateDefaultClient();

            await PopulateTestData();

            var response = 
                await client.GetAsync(
                    "/businessOwner/washington/george");
            
            Assert.NotNull(response);
            Assert.True(response.IsSuccessStatusCode);

            var content = await response.Content.ReadAsStringAsync();
            //FIXME StringAssert
            // StringAssert.Contains(content, "George", "Missing first name");
            // StringAssert.Contains(content, "Washington", "Missing last name");
            // StringAssert.Contains(content, "Westmoreland County", "Missing birth city");
        }  

        [Fact]
        public async Task LoadBusinessOwnerById_LegacyAspx()
        {
            var client = 
                SystemUnderTest.CreateDefaultClient();

            await PopulateTestData();

            int businessOwnerId = 
                GetBusinessOwnerIdByName("George", "Washington");

            Assert.NotEqual<int>(0, businessOwnerId);

            var response = 
                await client.GetAsync(
                    String.Format("/businessOwner/{0}.aspx", businessOwnerId));
                                
            Assert.NotNull(response);
            Assert.True(response.IsSuccessStatusCode);

            var content = await response.Content.ReadAsStringAsync();

            // StringAssert.Contains(content, "George", "Missing first name");
            // StringAssert.Contains(content, "Washington", "Missing last name");
            // StringAssert.Contains(content, "Westmoreland County", "Missing birth city");
        }

         [Fact]
        public async Task LoadBusinessOwnerDetailById()
        {
            var client = 
                SystemUnderTest.CreateDefaultClient();

            await PopulateTestData();

            int businessOwnerId = 
                GetBusinessOwnerIdByName("George", "Washington");

            Assert.NotEqual<int>(0, businessOwnerId);

            var response = 
                await client.GetAsync(
                    String.Format("/businessOwner/details/{0}", businessOwnerId));
                                
            Assert.NotNull(response);
            Assert.True(response.IsSuccessStatusCode);

            var content = await response.Content.ReadAsStringAsync();

            // StringAssert.Contains(content, "George", "Missing first name");
            // StringAssert.Contains(content, "Washington", "Missing last name");
            // StringAssert.Contains(content, "Westmoreland County", "Missing birth city");
        }
              
    }
}
