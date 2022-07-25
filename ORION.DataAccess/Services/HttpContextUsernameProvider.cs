
using Microsoft.AspNetCore.Http;
using ORION.DataAccess.Interfaces;
using System;

namespace ORION.DataAccess.Services
{
    public class HttpContextUsernameProvider : IUsernameProvider
    {
        private IHttpContextAccessor _ContextAccessor;

        public HttpContextUsernameProvider(IHttpContextAccessor contextAccessor)
        {
            if (contextAccessor == null)
                throw new ArgumentNullException(nameof(contextAccessor), 
                    $"{nameof(contextAccessor)} is null.");

            _ContextAccessor = contextAccessor;
        }

        public string GetUsername()
        {
            var context = _ContextAccessor.HttpContext;

            if (context != null && context.User != null && context.User.Identity != null)
            {
                return context.User.Identity.Name;
            }
            else
            {
                return null;
            }
        }
    }
}
