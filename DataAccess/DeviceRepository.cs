using Device.Management.API.DataAccess.DTOs;
using Device.Management.API.DataAccess.Entities;

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
            //_context.Device.Update(device);
            await _context.SaveChangesAsync();
        }
    }
}
