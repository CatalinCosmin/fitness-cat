using Microsoft.AspNetCore.Http;

namespace Infrastructure.Extensions
{
    public static class HttpContextExtensions
    {
        public static Guid GetAccountId(this HttpContext context)
        {
            var claim = context.User.Claims.Single(u => u.Type == "id");
            var id = Guid.Parse(claim.Value);

            return id;
        }
    }
}
