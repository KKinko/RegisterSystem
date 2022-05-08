using RegisterSystem.Data.AbstractData;

namespace RegisterSystem.Data.Party
{
    public sealed class EventCompanyData: UniqueData
    {
        public string EventId { get; set; } = string.Empty;
        public string CompanyId { get; set; } = string.Empty;
    }
}
