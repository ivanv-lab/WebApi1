using Newtonsoft.Json;

namespace WebApi1
{
    public class ErrorhandlerMiddleware
    {
        private readonly RequestDelegate _next;
        public ErrorhandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        public static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            {
                var statusCode = StatusCodes.Status500InternalServerError;
                var message = "Internal server error";

                var result = JsonConvert.SerializeObject(new { error = message });
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = statusCode;
                return context.Response.WriteAsync(result);
            }
        }
    }
}
