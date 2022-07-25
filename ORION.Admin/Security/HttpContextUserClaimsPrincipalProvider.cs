using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace ORION.Admin.Security
{
    public class HttpContextUserClaimsPrincipalProvider : IUserClaimsPrincipalProvider
    {

        private IHttpContextAccessor _ContextAccessor;

        public HttpContextUserClaimsPrincipalProvider(IHttpContextAccessor contextAccessor)
        {
            if (contextAccessor == null)
                throw new ArgumentNullException(nameof(contextAccessor),
                    $"{nameof(contextAccessor)} is null.");

            _ContextAccessor = contextAccessor;
        }

        public ClaimsPrincipal GetUser()
        {
            var context = _ContextAccessor.HttpContext;

            if (context != null && context.User != null)
            {
                return context.User;
            }
            else
            {
                return null;
            }
        }
    }
}