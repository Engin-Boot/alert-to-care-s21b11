namespace AlertToCareAPI.Models
{
    public class Alert
    {
        public string Id { get; set; }
        public string PatientId { get; set; }
        public string Message { get; set; }
        public int IsActive { get; set; }
        public string BedId { get; set; }
        public string IcuId { get; set; }

    }
}
