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

        public async Task<DeviceViewModel?> UpdateDeviceAsync(DeviceDTO deviceDto)
        {
            var device = await GetDeviceById(deviceDto.Id);

            if (device == null)
                return null;

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

        private async Task<DeviceEntity?> GetDeviceById(int id)
        {
            var device = await _repository.GetDeviceById(id);
            return device;
        }

        public async Task<DeviceViewModel?> GetDeviceByIdAsync(int id)
        {
            var device = await GetDeviceById(id);
            if (device == null)
                return null;

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

        public async Task<List<DeviceViewModel>> GetAllDevicesAsync()
        {
            var deviceDtos = await _repository.GetAllDevicesAsync();

            var deviceModels = deviceDtos.Select(deviceDto => MapDeviceDtoToDeviceViewModel(deviceDto)).ToList();
            return deviceModels;
        }

        public async Task<List<DeviceViewModel>> GetDevicesByBrandAsync(string brand)
        {
            var deviceDtos = await _repository.GetDevicesByBrandAsync(brand);

            var deviceModels = deviceDtos.Select(deviceDto => MapDeviceDtoToDeviceViewModel(deviceDto)).ToList();
            return deviceModels;
        }

        public async Task<List<DeviceViewModel>> GetDevicesByStateAsync(DeviceState state)
        {
            var deviceDtos = await _repository.GetDevicesByStateAsync(state);

            var deviceModels = deviceDtos.Select(deviceDto => MapDeviceDtoToDeviceViewModel(deviceDto)).ToList();
            return deviceModels;
        }

        private DeviceViewModel MapDeviceDtoToDeviceViewModel(DeviceDTO deviceDto)
        {
            return new DeviceViewModel
            {
                Id = deviceDto.Id,
                Name = deviceDto.Name,
                Brand = deviceDto.Brand,
                State = (int)deviceDto.State,
                CreatedAt = deviceDto.CreatedAt
            };
        }

        public async Task DeleteDeviceAsync(int id)
        {
            await _repository.DeleteDeviceAsync(id);
        }
    }
}
