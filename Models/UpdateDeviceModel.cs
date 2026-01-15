namespace Device.Management.API.Models
{
    public class UpdateDeviceModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty!;
        public string Brand { get; set; } = string.Empty!;
        public int State { get; set; }
    }
}
