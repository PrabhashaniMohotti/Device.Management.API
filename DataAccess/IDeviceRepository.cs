using Device.Management.API.DataAccess.DTOs;
using Device.Management.API.DataAccess.Entities;
using Device.Management.API.Models;

namespace Device.Management.API.DataAccess
{
    public interface IDeviceRepository
    {
        Task<int> CreateDeviceAsync(DeviceDTO deviceDto);
        Task<DeviceEntity?> GetDeviceById(int id);
        Task UpdateDeviceAsync(DeviceEntity Device);
        Task<List<DeviceDTO>> GetAllDevicesAsync();
        Task<List<DeviceDTO>> GetDevicesByBrandAsync(string brand);
        Task<List<DeviceDTO>> GetDevicesByStateAsync(DeviceState state);
        Task DeleteDeviceAsync(int id);
    }
}