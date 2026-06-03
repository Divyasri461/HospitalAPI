using System.Diagnostics;

namespace HospitalAPI.Middleware
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;

        public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var stopwatch = Stopwatch.StartNew();

            var method = context.Request.Method;
            var path = context.Request.Path;

            _logger.LogInformation($"REQUEST: {method} {path}");

            await _next(context);

            stopwatch.Stop();

            _logger.LogInformation($"RESPONSE: {method} {path} | Time: {stopwatch.ElapsedMilliseconds} ms");
        }
    }
}