using Device.Management.API.DataAccess;
using Device.Management.API.DataAccess.DTOs;
using Device.Management.API.DataAccess.Entities;
using Device.Management.API.Models;

namespace Device.Management.API.Services
{
    public class DeviceService
    {
        private readonly IDeviceRepository _repository;

        public DeviceService(IDeviceRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> CreateDeviceAsync(DeviceDTO deviceDto)
        {
            deviceDto.CreatedAt = DateTime.UtcNow;

            return await _repository.CreateDeviceAsync(deviceDto);
        }

        public async Task<DeviceViewModel> UpdateDeviceAsync(DeviceDTO deviceDto)
        {
            var device = await GetDeviceById(deviceDto.Id);
            
            if (device.state == (int)DeviceState.InUse)
            {
                throw new Exception("Cannot update the device that is currently in use");
            }

            device.state = (int)deviceDto.State;
            device.name = deviceDto.Name;
            device.brand = deviceDto.Brand;

            await _repository.UpdateDeviceAsync(device);

            var deviceModel = new DeviceViewModel
            {
                Brand = device.brand,
                CreatedAt = device.created_at,
                Id = device.id,
                Name = device.name,
                State = device.state
            };

            return deviceModel;
        }

        private async Task<DeviceEntity> GetDeviceById(int id)
        {
            var device = await _repository.GetDeviceById(id);
            if (device == null)
            {
                throw new Exception("Device not found");
            }

            return device;
        }
    }
}
