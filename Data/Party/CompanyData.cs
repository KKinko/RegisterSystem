using RegisterSystem.Data.AbstractData;

namespace RegisterSystem.Data.Party
{
    public sealed class CompanyData : PaymentData
    {
        public string? CompanyName { get; set; }
        public string? RegisterCode { get; set; }
        public int? Participants { get; set; }
        
    }
}
