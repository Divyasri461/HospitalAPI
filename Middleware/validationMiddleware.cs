namespace HospitalAPI.Middleware
{
    public class ValidationMiddleware
    {
        private readonly RequestDelegate _next;

        public ValidationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Method == "POST" || context.Request.Method == "PUT")
            {
                if (context.Request.ContentLength==null || context.Request.ContentLength == 0)
                {
                    context.Response.StatusCode = 400;
                    await context.Response.WriteAsync("Request body cannot be empty");
                    return;
                }
            }

            await _next(context);
        }
    }
}