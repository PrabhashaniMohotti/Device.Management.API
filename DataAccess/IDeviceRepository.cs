using Device.Management.API.DataAccess.DTOs;

namespace Device.Management.API.DataAccess
{
    public interface IDeviceRepository
    {
        Task<int> CreateDeviceAsync(DeviceDTO deviceDto);
    }
}