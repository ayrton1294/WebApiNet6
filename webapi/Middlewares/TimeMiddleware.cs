namespace webapi.Middelwares
{
    public class TimeMiddleware
    {
        readonly RequestDelegate _next;

        public TimeMiddleware(RequestDelegate nextRequest)
        {
            this._next = nextRequest;
        }

        public async Task Invoke(HttpContext context)
        {
            
            if (context.Request.Query.Any(p => p.Key == "time"))
            {
                await context.Response.WriteAsync(DateTime.Now.ToShortTimeString());
            }

            if (!context.Response.HasStarted)
            {
                await _next.Invoke(context);
            }

            
        }

    }
    public static class TimeMiddlewareExtension
    {
        public static IApplicationBuilder UseTimeMiddelware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<TimeMiddleware>();
        }
    }
}
