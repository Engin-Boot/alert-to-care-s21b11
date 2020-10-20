using System.Diagnostics.CodeAnalysis;
namespace AlertToCareAPI.Models
{
    [ExcludeFromCodeCoverage]
    public class Bed
    {
        public string Id { get; set; }
        public string IcuId { get; set; }
        public bool IsOccupied { get; set; }
    }
}
