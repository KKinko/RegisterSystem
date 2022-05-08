using RegisterSystem.Data.AbstractData;

namespace RegisterSystem.Data.Party
{
    public sealed class CivilianData : PaymentData
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? IdCode { get; set; }
    }
}
