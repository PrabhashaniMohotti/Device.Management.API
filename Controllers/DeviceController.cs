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
        public async Task<IActionResult> CreateDevice(CreateUpdateDeviceModel createDeviceModel)
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

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDevice(int id, CreateUpdateDeviceModel updateDeviceModel)
        {
            var deviceDto = new DeviceDTO
            {
                Id = id,
                Name = updateDeviceModel.Name,
                Brand = updateDeviceModel.Brand,
                State = (DeviceState)updateDeviceModel.State
            };

            var updateResponce = await _deviceService.UpdateDeviceAsync(deviceDto);

            if (updateResponce == null)
                return NotFound();

            return Ok(updateResponce);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDeviceById(int id)
        {
            var device = await _deviceService.GetDeviceByIdAsync(id);
            if (device == null)
                return NotFound();

            return Ok(device);
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetAllDevices()
        {
            var devices = await _deviceService.GetAllDevicesAsync();

            return Ok(devices);
        }

        [HttpGet("ByBrand/{brand}")]
        public async Task<IActionResult> GetDevicesByBrand(string brand)
        {
            var devices = await _deviceService.GetDevicesByBrandAsync(brand);
            return Ok(devices);
        }

        [HttpGet("ByState/{state}")]
        public async Task<IActionResult> GetDevicesByState(int state)
        {
            var devices = await _deviceService.GetDevicesByStateAsync((DeviceState)state);
            return Ok(devices);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDevice(int id)
        {
            await _deviceService.DeleteDeviceAsync(id);
            return NoContent();
        }
    }
}
