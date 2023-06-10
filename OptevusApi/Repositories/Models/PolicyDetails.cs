using System.ComponentModel.DataAnnotations;

namespace OptevusApi.Repositories.Models
{
    public class PolicyDetails
    {
        [Key]
        public int PolicyId { get; set; }
        public DateTime DateOfPurchase { get; set; }
        public int CustomerId { get; set; }
        public string Fuel { get; set; }
        public string VehicleSegment { get; set; }
        public int Premium { get; set; }
        public bool BodilyInjury { get; set; }
        public string CustomerGender { get; set; }
        public string CustomerIncomeGroup { get; set; }
        public string? CustomerRegion { get; set; }
        public bool CustomerMaritalStatus { get; set; }
    }
}
