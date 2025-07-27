namespace WebAPI
{
    public class HeaderChecker
    {
        private readonly RequestDelegate _next;
        private readonly string _webApiKey;

        public HeaderChecker(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _webApiKey = configuration["WebAPIKey"] ?? string.Empty;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Method.Equals("OPTIONS", StringComparison.OrdinalIgnoreCase))
            {
                await _next.Invoke(context);
                return;
            }

            var excludedPaths = new List<string> { };

            var request = context.Request.Path.Value!.ToLower();

            var epep = context.Request.Headers["key"];

            if (excludedPaths.Contains(request))
            {
                await _next.Invoke(context);
            }
            else if (context.Request.Headers.TryGetValue("key", out Microsoft.Extensions.Primitives.StringValues value) && value == _webApiKey)
            {
                await _next.Invoke(context);
            }
            else
            {
                context.Response.StatusCode = 400;
            }
        }
    }
}
