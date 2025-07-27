using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyStack.KeepAlive.Service;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KeepAliveController : ControllerBase
    {
        private readonly IKeepAliveService _service;

        public KeepAliveController(IKeepAliveService service)
        {
            _service = service;
        }

        [HttpGet("ping")]
        public async Task<IActionResult> Ping()
        {
            var version = await _service.GetVersionAsync();

            return Ok(new
            {
                alive = true,
                version = version ?? "unknown",
                timestamp = DateTime.UtcNow
            });
        }
    }
}
