using Microsoft.AspNetCore.Http;

namespace ConsultoriasService.Api.Helpers
{
    public static class RequestHelper
    {
        public static string ObterAuthHeader(HttpContext httpContext)
        {
            return httpContext.Request.Headers["Authorization"];
        }
    }
}
