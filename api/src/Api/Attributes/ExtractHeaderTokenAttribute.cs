using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;

namespace Infrastructure.Attributes
{
    public class ExtractHeaderTokenAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            const string HeaderKeyName = "Authorization";
            context.HttpContext.Request.Headers.TryGetValue(HeaderKeyName, out StringValues headerValue);
            string token = headerValue.ToString().Replace("Bearer ", "");

            if (context.HttpContext.Items.ContainsKey(HeaderKeyName))
            {
                context.HttpContext.Items[HeaderKeyName] = token;
            }
            else
            {
                context.HttpContext.Items.Add(HeaderKeyName, token);
            }
        }
    }
}
