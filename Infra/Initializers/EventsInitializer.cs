using RegisterSystem.Data.AbstractData;
using RegisterSystem.Data.Party;

namespace RegisterSystem.Infra.Initializers
{
    public sealed class EventsInitializer : BaseInitializer<EventData>
    {
        public EventsInitializer(RegisterDb? db) : base(db, db?.Events) { }
        protected override IEnumerable<EventData> getEntities => new[] {
            createEvent("AS Puu jaanipäev", new DateTime(1980, 07, 31), "Tartus", "zzzzzzz"),
            createEvent("Anna sünnipäev", new DateTime(1979, 09, 19), "Tallinnas", "adasxxasd"),
            createEvent("Jõulupidu", new DateTime(1980, 03, 01), "Saaremaa", "xxxxxxxxxxxx  xxx"),
            createEvent("Suvepäevad",new DateTime(1903, 03, 01), "Narva", "adsasda asda dasda aasd"),
        };
        internal static EventData createEvent(string eventName, DateTime time, string  place, string information)
        {
            var address = new EventData
            {
                Id = UniqueData.NewId,
                EventName = eventName,
                Time = time,
                Place = place,
                Information = information
            };
            return address;
        }
    }

}