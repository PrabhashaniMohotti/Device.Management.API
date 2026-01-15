using Device.Management.API.DataAccess.DTOs;
using Device.Management.API.DataAccess.Entities;

namespace Device.Management.API.DataAccess
{
    public interface IDeviceRepository
    {
        Task<int> CreateDeviceAsync(DeviceDTO deviceDto);
        Task<DeviceEntity?> GetDeviceById(int id);
        Task UpdateDeviceAsync(DeviceEntity Device);
    }
}