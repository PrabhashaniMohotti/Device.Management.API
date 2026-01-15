using Device.Management.API.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Device.Management.API.DataAccess
{
    public class DevicesDbContext : DbContext
    {
        public DevicesDbContext(DbContextOptions<DevicesDbContext> options)
        : base(options) { }

        public DbSet<DeviceEntity> Device => Set<DeviceEntity>();
    }
}
