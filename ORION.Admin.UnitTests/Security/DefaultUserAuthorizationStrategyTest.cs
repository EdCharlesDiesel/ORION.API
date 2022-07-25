using Xunit;
using System.Security.Claims;
using ORION.Admin.Security;

using Xunit;

namespace ORION.Admin.UnitTests.Security
{
    public class DefaultUserAuthorizationStrategyTest
    {
        public DefaultUserAuthorizationStrategyTest()
        {
            _SystemUnderTest = null;
            _PrincipalProvider = null;
        }

        private DefaultUserAuthorizationStrategy _SystemUnderTest;
        public DefaultUserAuthorizationStrategy SystemUnderTest
        {
            get
            {
                if (_SystemUnderTest == null)
                {
                    _SystemUnderTest =
                        new DefaultUserAuthorizationStrategy(
                            PrincipalProvider);
                }

                return _SystemUnderTest;
            }
        }

        private MockUserClaimsPrincipalProvider _PrincipalProvider;
        public MockUserClaimsPrincipalProvider PrincipalProvider
        {
            get
            {
                if (_PrincipalProvider == null)
                {
                    _PrincipalProvider = new MockUserClaimsPrincipalProvider();
                }

                return _PrincipalProvider;
            }
        }

        [Fact]
        public void IsAuthorizedForSearch_ReturnsFalseForNoClaims()
        {
            Assert.False(SystemUnderTest.IsAuthorizedForSearch);
        }

        [Fact]
        public void IsAuthorizedForSearch_ReturnsTrueForAdministrator()
        {
            PrincipalProvider.AddClaim(
                ClaimTypes.Role,
                SecurityConstants.RoleName_Admin);

            Assert.True(SystemUnderTest.IsAuthorizedForSearch);
        }

        [Fact]
        public void IsAuthorizedForSearch_ReturnsTrueForBasicSubscription()
        {
            PrincipalProvider.AddClaim(
                SecurityConstants.Claim_SubscriptionType, 
                SecurityConstants.SubscriptionType_Basic);

            Assert.True(SystemUnderTest.IsAuthorizedForSearch);
        }

        [Fact]
        public void IsAuthorizedForSearch_ReturnsTrueForUltimateSubscription()
        {
            PrincipalProvider.AddClaim(
                SecurityConstants.Claim_SubscriptionType, 
                SecurityConstants.SubscriptionType_Ultimate);

            Assert.True(SystemUnderTest.IsAuthorizedForSearch);
        }


        [Fact]
        public void IsAuthorizedForImages_ReturnsFalseForNoClaims()
        {
            Assert.False(SystemUnderTest.IsAuthorizedForImages);
        }

        [Fact]
        public void IsAuthorizedForImages_ReturnsTrueForAdministrator()
        {
            PrincipalProvider.AddClaim(
                ClaimTypes.Role,
                SecurityConstants.RoleName_Admin);

            Assert.True(SystemUnderTest.IsAuthorizedForImages);
        }

        [Fact]
        public void IsAuthorizedForImages_ReturnsFalseForBasicSubscription()
        {
            PrincipalProvider.AddClaim(
                SecurityConstants.Claim_SubscriptionType,
                SecurityConstants.SubscriptionType_Basic);

            Assert.False(SystemUnderTest.IsAuthorizedForImages);
        }

        [Fact]
        public void IsAuthorizedForImages_ReturnsTrueForUltimateSubscription()
        {

            PrincipalProvider.AddClaim(
                SecurityConstants.Claim_SubscriptionType,
                SecurityConstants.SubscriptionType_Ultimate);

            Assert.True(SystemUnderTest.IsAuthorizedForImages);
        }

    }
}