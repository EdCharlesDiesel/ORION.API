namespace ORION.Sales.Middleware
{
    public class PersonCreditCarManagementSecurityHeadersMiddleware
    {
        private readonly RequestDelegate _next;

        public PersonCreditCarManagementSecurityHeadersMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            IHeaderDictionary headers = context.Response.Headers;
             
            // Add CSP + X-Content-Type
            headers["Content-Security-Policy"] = "default-src 'self';frame-ancestors 'none';"; 
            headers["X-Content-Type-Options"] = "nosniff"; 

            await _next(context);
        }
    }
}

 