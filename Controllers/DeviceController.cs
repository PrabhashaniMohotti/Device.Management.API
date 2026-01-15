using Device.Management.API.DataAccess.DTOs;
using Device.Management.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Device.Management.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeviceController : ControllerBase
    {
        private readonly DeviceService _deviceService;

        public DeviceController(DeviceService deviceService)
        {
            _deviceService = deviceService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateDevice(DeviceViewModel deviceViewModel)
        {
            var deviceDto = new DeviceDTO
            {
                Name = deviceViewModel.Name,
                Brand = deviceViewModel.Brand,
                State = (DeviceState)deviceViewModel.State
            };

            var createdDeviceResponce = await _deviceService.CreateDeviceAsync(deviceDto);
            return Ok(createdDeviceResponce);
        }
    }
}
