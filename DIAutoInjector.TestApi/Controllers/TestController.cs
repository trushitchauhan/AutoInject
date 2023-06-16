using Microsoft.AspNetCore.Mvc;
using DIAutoInjector.TestApi.Services;

namespace DIAutoInjector.TestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly ITransientHelper _transientHelper;
        private readonly IScopedHelper _scopedHelper;
        private readonly ISingletonHelper _singletonHelper;
        private readonly IManualHelper _manualHelper;

        public TestController(ILogger<TestController> logger, ITransientHelper transientHelper, IScopedHelper scopedHelper, ISingletonHelper singletonHelper, IManualHelper manualHelper)
        {
            _logger = logger;
            _transientHelper = transientHelper;
            _scopedHelper = scopedHelper;
            _singletonHelper = singletonHelper;
            _manualHelper = manualHelper;
        }

        [HttpGet]
        public async Task<IActionResult> Test()
        {
            _logger.LogInformation("Transient: " + _transientHelper.InstanceId);
            _logger.LogInformation("Scoped: " + _scopedHelper.InstanceId);
            _logger.LogInformation("Singleton: " + _singletonHelper.InstanceId);
            _logger.LogInformation("Manual: " + _manualHelper.InstanceId);
            return Ok();
        }
    }
}