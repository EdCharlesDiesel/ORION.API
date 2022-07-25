using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using ORION.Admin.Security;
using Xunit;

namespace ORION.Admin.UnitTests.Security
{
    public class PopulateSubscriptionClaimsMiddlewareTest
    {
        public PopulateSubscriptionClaimsMiddlewareTest()
        {
             _SystemUnderTest = null;
            _SubscriptionServiceInstance = null;
        }

        private PopulateSubscriptionClaimsMiddleware _SystemUnderTest;
        public PopulateSubscriptionClaimsMiddleware SystemUnderTest
        {
            get
            {
                if (_SystemUnderTest == null)
                {
                    _SystemUnderTest = 
                        new PopulateSubscriptionClaimsMiddleware(
                            SubscriptionServiceInstance
                        );
                }

                return _SystemUnderTest;
            }
        }

        private MockSubscriptionService _SubscriptionServiceInstance;
        public MockSubscriptionService SubscriptionServiceInstance
        {
            get
            {
                if (_SubscriptionServiceInstance == null)
                {
                    _SubscriptionServiceInstance = new MockSubscriptionService();
                }

                return _SubscriptionServiceInstance;
            }
        }


        [Fact]
        public async Task SubscriptionClaimIsNotAddedWhenUserIsNotAuthenticated()
        {
            DefaultHttpContext httpContext = GetHttpContextForAnonymousUser();

            // act
            await SystemUnderTest.InvokeAsync(httpContext, GetDoNothingNextDelegate());

            // assert
            Assert.Equal(0, httpContext.User.Claims.Count());
        }

        [Fact]
        public async Task SubscriptionClaimIsNotAddedWhenSubscriptionDoesNotExistForUser()
        {
            // arrange
            var httpContext = GetHttpContextForAuthenticatedUser();

            // act
            await SystemUnderTest.InvokeAsync(httpContext, GetDoNothingNextDelegate());

            // assert
            Assert.Equal(1, httpContext.User.Claims.Count());
        }

        [Fact]
        public async Task SubscriptionClaimIsAddedWhenSubscriptionExists()
        {
            // arrange
            string expectedSubscriptionType = SecurityConstants.SubscriptionType_Ultimate;

            SubscriptionServiceInstance.SubscriptionTypeReturnValue =
                expectedSubscriptionType;

            DefaultHttpContext httpContext =
                GetHttpContextForAuthenticatedUser();

            // act
            await SystemUnderTest.InvokeAsync(
                httpContext, GetDoNothingNextDelegate());

            // assert
            Assert.Equal(2, httpContext.User.Claims.Count());

            var subscriptionClaim =
                httpContext.User.Claims.Where(
                    c => c.Type == SecurityConstants.Claim_SubscriptionType).FirstOrDefault();

            Assert.NotNull(subscriptionClaim);

            Assert.Equal(expectedSubscriptionType, subscriptionClaim.Value);
        }

        private DefaultHttpContext GetHttpContextForAuthenticatedUser()
        {
            var httpContext = new DefaultHttpContext();

            var claims = new List<Claim>();

            claims.Add(new Claim(
                ClaimTypes.Name, "test user"));

            var identity = new ClaimsIdentity(claims);

            httpContext.User = new ClaimsPrincipal(identity);

            return httpContext;
        }

        private DefaultHttpContext GetHttpContextForAnonymousUser()
        {
            // arrange
            var httpContext = new DefaultHttpContext();

            httpContext.User = new ClaimsPrincipal();
            return httpContext;
        }

        #pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        private async Task DoNothing(HttpContext context)
        #pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {

        }

        private RequestDelegate GetDoNothingNextDelegate()
        {
            return new RequestDelegate(DoNothing);
        }
    }
}