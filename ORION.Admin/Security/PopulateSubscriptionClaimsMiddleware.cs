using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using ORION.DataAccess.Services;

namespace ORION.Admin.Security
{
    public class PopulateSubscriptionClaimsMiddleware : IMiddleware
    {
        private ISubscriptionService _SubscriptionService;

        public PopulateSubscriptionClaimsMiddleware(
            ISubscriptionService subscriptionServiceInstance)
        {
            _SubscriptionService = subscriptionServiceInstance;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if (context.User != null &&
                context.User.HasClaim(
                    c => c.Type == ClaimTypes.Name) == true)
            {
                var usernameClaim = 
                    context.User.Claims.Where(
                        c => c.Type == ClaimTypes.Name).FirstOrDefault();

                var username = usernameClaim.Value;
                
                var subscriptionType =
                    _SubscriptionService.GetSubscriptionType(
                        username);                

                if (subscriptionType != null)
                {
                    var claims = new List<Claim>();

                    // copy the existing claims
                    claims.AddRange(context.User.Claims);

                    AddClaim(claims, 
                        SecurityConstants.Claim_SubscriptionType, 
                        subscriptionType);

                    var identity = new ClaimsIdentity(claims);

                    context.User = new System.Security.Claims.ClaimsPrincipal(identity);
                }
            }
                        
            await next(context);
        }

        private static void AddClaim(List<Claim> claims, string claimTypeName, string value)
        {
            claims.Add(new Claim(claimTypeName, value));
        }
    }
}