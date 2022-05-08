using RegisterSystem.Data.AbstractData;

namespace RegisterSystem.Data.Party
{
    public sealed class EventData : AdditionalData 
    { 
        public string? EventName { get; set; }
        public DateTime? Time { get; set; }
        public string? Place { get; set; }
    }
}
