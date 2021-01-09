using System.Reflection;
using Microsoft.AspNetCore.Mvc;

namespace Calculator.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppController : ControllerBase
    {
        private string _appVersion;
        public AppController()
        {
            _appVersion = Assembly
                .GetEntryAssembly()
                .GetCustomAttribute<AssemblyInformationalVersionAttribute>()
                .InformationalVersion;
        }

        [HttpGet("version")]
        public IActionResult GetAppVersion() => Ok(new { appVersion = _appVersion });
    }
}