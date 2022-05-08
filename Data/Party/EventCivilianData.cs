using RegisterSystem.Data.AbstractData;

namespace RegisterSystem.Data.Party
{
    public sealed class EventCivilianData: UniqueData
    {
        public string EventId { get; set; } = string.Empty;
        public string CivilianId { get; set; } = string.Empty;
    }
}
