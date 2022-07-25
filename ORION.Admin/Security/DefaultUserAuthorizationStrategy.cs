using System;
using System.Security.Claims;

namespace ORION.Admin.Security
{
    public class DefaultUserAuthorizationStrategy : IUserAuthorizationStrategy
    {
        private SecurityUtility _SecurityUtility;

        public DefaultUserAuthorizationStrategy(
            IUserClaimsPrincipalProvider provider)
        {
            ClaimsPrincipal principal = provider.GetUser();

            _SecurityUtility =
                new SecurityUtility(principal.Identity, principal);
        }
        public bool IsAuthorizedForSearch
        {
            get
            {
                if (IsAdministrator() == true)
                {
                    return true;
                }
                else
                {
                    return _SecurityUtility.HasClaim(
                        SecurityConstants.Claim_SubscriptionType);
                }
            }
        }

        private bool IsAdministrator()
        {
            return _SecurityUtility.IsInRole(
                SecurityConstants.RoleName_Admin);
        }

        // public bool IsAuthorizedForImages => throw new System.NotImplementedException();

        public bool IsAuthorizedForImages
        {
            get
            {
                if (IsAdministrator() == true)
                {
                    return true;
                }
                else
                {
                    return _SecurityUtility.HasClaim(
                        SecurityConstants.Claim_SubscriptionType, 
                        SecurityConstants.SubscriptionType_Ultimate);
                }
            }
        }

    }
}