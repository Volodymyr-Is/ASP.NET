using Dz_16._01.Models;

namespace Dz_16._01.Middleware
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlerMiddleware> _logger;

        public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, IServiceProvider serviceProvider)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                using (var scope = serviceProvider.CreateScope())
                {
                    var dbContext = scope.ServiceProvider.GetRequiredService<MyDBContext>();

                    var errorLog = new ErrorLogger
                    {
                        ErrorDetails = ex.Message,
                        LogDate = DateTime.UtcNow
                    };

                    dbContext.ErrorLoggers.Add(errorLog);
                    await dbContext.SaveChangesAsync();
                }

                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";

                var errorInfo = new ErrorInfo
                {
                    StatusCode = 500,
                    ErrorMessage = "An error occurred while processing your request."
                };

                await context.Response.WriteAsJsonAsync(errorInfo);
            }
        }
    }
}
