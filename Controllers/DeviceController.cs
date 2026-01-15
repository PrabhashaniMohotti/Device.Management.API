using Device.Management.API.DataAccess.DTOs;
using Device.Management.API.Models;
using Device.Management.API.Services;
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
        public async Task<IActionResult> CreateDevice(CreateDeviceModel createDeviceModel)
        {
            var deviceDto = new DeviceDTO
            {
                Name = createDeviceModel.Name,
                Brand = createDeviceModel.Brand,
                State = (DeviceState)createDeviceModel.State
            };

            var createdDeviceResponce = await _deviceService.CreateDeviceAsync(deviceDto);
            return Ok(createdDeviceResponce);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> UpdateDevice(UpdateDeviceModel updateDeviceModel)
        {
            var deviceDto = new DeviceDTO
            {
                Id = updateDeviceModel.Id,
                Name = updateDeviceModel.Name,
                Brand = updateDeviceModel.Brand,
                State = (DeviceState)updateDeviceModel.State
            };

            var updateResponce = await _deviceService.UpdateDeviceAsync(deviceDto);
            return Ok(updateResponce);
        }
    }
}
