using Device.Management.API.DataAccess.DTOs;
using Device.Management.API.DataAccess.Entities;
using Device.Management.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Device.Management.API.DataAccess
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly DevicesDbContext _context;

        public DeviceRepository(DevicesDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateDeviceAsync(DeviceDTO deviceDto)
        {
            var device = new DeviceEntity
            {
                name = deviceDto.Name,
                brand = deviceDto.Brand,
                state = (int)deviceDto.State,
                created_at = deviceDto.CreatedAt
            };

            _context.Device.Add(device);
            await _context.SaveChangesAsync();
            return device.id;
        }

        public async Task<DeviceEntity?> GetDeviceById(int id)
        {
            return await _context.Device.FindAsync(id);
        }

        public async Task UpdateDeviceAsync(DeviceEntity device)
        {
            await _context.SaveChangesAsync();
        }

        public async Task<List<DeviceDTO>> GetAllDevicesAsync()
        {
            return await _context.Device
                .Select(device => new DeviceDTO
                {
                    Id = device.id,
                    Name = device.name,
                    Brand = device.brand,
                    State = (DeviceState)device.state,
                    CreatedAt = device.created_at
                }).ToListAsync();
        }

        public async Task<List<DeviceDTO>> GetDevicesByBrandAsync(string brand)
        {
            return await _context.Device
                .Where(device => device.brand == brand)
                .Select(device => new DeviceDTO
                {
                    Id = device.id,
                    Name = device.name,
                    Brand = device.brand,
                    State = (DeviceState)device.state,
                    CreatedAt = device.created_at
                }).ToListAsync();
        }

        public async Task<List<DeviceDTO>> GetDevicesByStateAsync(DeviceState state)
        {
            return await _context.Device
                .Where(device => device.state == (int)state)
                .Select(device => new DeviceDTO
                {
                    Id = device.id,
                    Name = device.name,
                    Brand = device.brand,
                    State = (DeviceState)device.state,
                    CreatedAt = device.created_at
                }).ToListAsync();
        }

        public async Task DeleteDeviceAsync(int id)
        {
            var device = await _context.Device.FindAsync(id);
            if (device != null)
            {
                _context.Device.Remove(device);
                await _context.SaveChangesAsync();
            }
        }
    }
}
