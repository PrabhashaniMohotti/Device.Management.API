namespace Device.Management.API.Models
{
    public class CreateUpdateDeviceModel
    {
        public string Name { get; set; } = string.Empty!;
        public string Brand { get; set; } = string.Empty!;
        public int State { get; set; }
    }
}
