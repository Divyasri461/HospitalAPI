namespace HospitalAPI.Models
{
    public class RevenueBySpecialization
    {
        public string? Specialization { get; internal set; }
        public decimal TotalRevenue { get; internal set; }
    }
}