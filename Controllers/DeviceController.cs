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

        /// <summary>
        /// Creates a new device
        /// </summary>
        /// <param name="createDeviceModel"></param>
        /// <returns>Id of the created device</returns>
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

        /// <summary>
        /// Update an existing device
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateDeviceModel"></param>
        /// <returns>Returns updated device model</returns>
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

        /// <summary>
        /// Gets a device by its Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Device details</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDeviceById(int id)
        {
            var device = await _deviceService.GetDeviceByIdAsync(id);
            if (device == null)
                return NotFound();

            return Ok(device);
        }

        /// <summary>
        /// Get all devices
        /// </summary>
        /// <returns>All the device detais</returns>
        [HttpGet("All")]
        public async Task<IActionResult> GetAllDevices()
        {
            var devices = await _deviceService.GetAllDevicesAsync();

            return Ok(devices);
        }

        /// <summary>
        /// get all devices by brand
        /// </summary>
        /// <param name="brand"></param>
        /// <returns>All the device details as a list</returns>
        [HttpGet("ByBrand/{brand}")]
        public async Task<IActionResult> GetDevicesByBrand(string brand)
        {
            var devices = await _deviceService.GetDevicesByBrandAsync(brand);
            return Ok(devices);
        }

        /// <summary>
        /// get all devices by state
        /// </summary>
        /// <param name="state"></param>
        /// <returns>All the device details as a list</returns>
        [HttpGet("ByState/{state}")]
        public async Task<IActionResult> GetDevicesByState(int state)
        {
            var devices = await _deviceService.GetDevicesByStateAsync((DeviceState)state);
            return Ok(devices);
        }

        /// <summary>
        /// Deletes a device by its Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDevice(int id)
        {
            await _deviceService.DeleteDeviceAsync(id);
            return NoContent();
        }
    }
}
