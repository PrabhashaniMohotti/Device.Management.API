using Device.Management.API.DataAccess;
using Device.Management.API.DataAccess.DTOs;

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
    }
}
