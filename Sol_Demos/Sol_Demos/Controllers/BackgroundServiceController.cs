using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sol_Demos.Services;

namespace Sol_Demos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class BackgroundServiceController : ControllerBase
    {
        private readonly BackgroundServiceDemo _backgroundServiceDemo;

        public BackgroundServiceController(BackgroundServiceDemo backgroundServiceDemo)
        {
            _backgroundServiceDemo = backgroundServiceDemo;
        }

        [HttpPost("start")]
        public async Task<IActionResult> StartService()
        {
            await _backgroundServiceDemo.StartService();
            return Ok("Background service started.");
        }

        [HttpPost("stop")]
        public async Task<IActionResult> StopService()
        {
            await _backgroundServiceDemo.StopService();
            return Ok("Background service stopped.");
        }
    }
}