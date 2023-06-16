using DIAutoInjector.TestApi.Services;

namespace DIAutoInjector.TestApi.Middlewares
{
    public class IdentityLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        public readonly ISingletonHelper _singletonHelper;
        public IdentityLoggingMiddleware(RequestDelegate next, ILogger<IdentityLoggingMiddleware> logger, ISingletonHelper singletonHelper)
        {
            _logger = logger;
            _singletonHelper = singletonHelper;
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context, IScopedHelper scopedHelper, ITransientHelper transientHelper)
        {
            _logger.LogInformation("Transient: " + transientHelper.InstanceId);
            _logger.LogInformation("Scoped: " + scopedHelper.InstanceId);
            _logger.LogInformation("Singleton: " + _singletonHelper.InstanceId);
            await _next(context);
        }
    }
}
