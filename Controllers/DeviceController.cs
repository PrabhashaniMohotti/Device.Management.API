using Microsoft.AspNetCore.Mvc;

namespace Device.Management.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeviceController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Success");
        }
    }
}
