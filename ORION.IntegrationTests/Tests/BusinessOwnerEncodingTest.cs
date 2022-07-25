using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Linq;
using Xunit;
using ORION.Admin;

namespace ORION.IntegrationTests.Tests
{
 
    public class BusinessOwnerEncodingTest
    {

        public BusinessOwnerEncodingTest()
        {
             _SystemUnderTest = null;
        }
        

        private WebApplicationFactory<Startup> _SystemUnderTest;
        public WebApplicationFactory<Startup> SystemUnderTest
        {
            get
            {
                if (_SystemUnderTest == null)
                {
                    _SystemUnderTest =
                        new WebApplicationFactory<Startup>();
                }

                return _SystemUnderTest;
            }
        }

       // FIXME Need to intestigate the Identity IdentityUserLogin<int> requirement
       [Fact]
        public async Task GetAllBusinessOwners_DefaultMediaTypeReturnedIsJson()
        {
            // arrange
            var client = SystemUnderTest.CreateDefaultClient();
            var expectedContentType = "application/json";

            // act
            var response =
                await client.GetAsync(
                    "/api/businessOwner"
                );

            // assert
           // Assert.True(response.IsSuccessStatusCode);

            Assert.Equal<string>(
                expectedContentType,
                response.Content.Headers.ContentType.MediaType
            );

            var responseBody =
                await response.Content.ReadAsStringAsync();

            Assert.NotEqual<string>(String.Empty, responseBody);
        }

        [Fact]
        public async Task GetAllBusinessOwners_Xml()
        {
            // arrange
            var client = SystemUnderTest.CreateDefaultClient();
            var expectedContentType = "application/xml";

            client.DefaultRequestHeaders.Accept
                .Add(new MediaTypeWithQualityHeaderValue(
                    expectedContentType
                ));

            // act
            var response =
                await client.GetAsync(
                    "/api/businessOwner"
                );

            // assert
          //  Assert.True(response.IsSuccessStatusCode
           // );

            Assert.Equal<string>(
                expectedContentType,
                response.Content.Headers.ContentType.MediaType
            );

            var responseBody =
                await response.Content.ReadAsStringAsync();

            Assert.NotEqual<string>(String.Empty, responseBody);
        }

        [Fact]
        public async Task GetAllBusinessOwners_WhenRequestedContentTypeIsJsonReturnsResultsAsJson()
        {
            // arrange
            var client = SystemUnderTest.CreateDefaultClient();
            var expectedContentType = "application/json";

            client.DefaultRequestHeaders.Accept
                .Add(new MediaTypeWithQualityHeaderValue(
                    expectedContentType
                ));

            // act
            var response =
                await client.GetAsync(
                    "/api/businessOwner"
                );

            // assert
          //  Assert.True(response.IsSuccessStatusCode,response.StatusCode.ToString());

            Assert.Equal(
                expectedContentType,
                response.Content.Headers.ContentType.MediaType
            );

            var responseBody =
                await response.Content.ReadAsStringAsync();

            Assert.NotEqual<string>(String.Empty, responseBody);
        }

         [Fact]
        public async Task GetAllBusinessOwners_TermDoesNotHaveIsDeleted()
        {
            // arrange
            var client = SystemUnderTest.CreateDefaultClient();
            var expectedContentType = "application/json";

            client.DefaultRequestHeaders.Accept
                .Add(new MediaTypeWithQualityHeaderValue(
                    expectedContentType
                ));

            // act
            var response =
                await client.GetAsync(
                    "/api/businessOwner"
                );

            // assert
            var responseBody =
                await response.Content.ReadAsStringAsync();

            Assert.NotEqual<string>(String.Empty, responseBody);

            var businessOwnerAsJson = JArray.Parse(responseBody)[0];

            var terms = businessOwnerAsJson["terms"] as JArray;

            Assert.NotNull(terms);
            Assert.Equal(1, terms.Count);

            var term = terms[0];

            var isDeleted = term["isDeleted"];

            Assert.Null(isDeleted);
        }

        private T GetInstanceOf<T>()
        {
            var client = SystemUnderTest.CreateDefaultClient();

            var hostServices = SystemUnderTest.Server.Host.Services;

            var scopeFactory = hostServices.GetService(
                typeof(IServiceScopeFactory)) as IServiceScopeFactory;

            using (IServiceScope scope = scopeFactory.CreateScope())
            {
                var returnValue =
                    scope.ServiceProvider.GetService<T>();

                Assert.NotNull(typeof(T).Name);

                return returnValue;
            }
        }
    }
}