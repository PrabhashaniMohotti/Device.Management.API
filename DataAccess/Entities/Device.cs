using System.ComponentModel.DataAnnotations.Schema;

namespace Device.Management.API.DataAccess.Entities
{
    [Table("device")]
    public class DeviceEntity
    {
        public int id { get; set; }
        public string name { get; set; } = string.Empty!;
        public string brand { get; set; } = string.Empty!;
        public int state { get; set; }
        public DateTime created_at { get; set; }
    }
}
