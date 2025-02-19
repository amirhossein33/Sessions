namespace Coingecko
{
    public class RateLimitingMiddleware
    {
        private static readonly SemaphoreSlim _semaphore = new(5); 

        private readonly RequestDelegate _next;

        public RateLimitingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await _semaphore.WaitAsync();

            try
            {
                await _next(context);
            }
            finally
            {
                _semaphore.Release();
            }
        }
    }

    public static class RateLimitingMiddlewareExtensions
    {
        public static IApplicationBuilder UseRateLimitingMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<RateLimitingMiddleware>();
        }
    }

}
