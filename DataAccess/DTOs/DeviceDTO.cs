using Device.Management.API.Models;

namespace Device.Management.API.DataAccess.DTOs
{
    public class DeviceDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty!;
        public string Brand { get; set; } = string.Empty!;
        public DeviceState State { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
