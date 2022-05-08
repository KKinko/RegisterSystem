using RegisterSystem.Data.Party;
using RegisterSystem.Domain.AbstractEntities;
using RegisterSystem.Domain.IRepos;

namespace RegisterSystem.Domain.Party
{
    public interface IEventsCiviliansRepo : IRepo<EventCivilian> 
    {
        //List<EventCivilian> GetId();
    }

    public sealed class EventCivilian : UniqueEntity<EventCivilianData>
    {
        public EventCivilian() : this(new()) { }
        public EventCivilian(EventCivilianData d) : base(d) { }
        public string EventId => getValue(Data?.EventId);
        public string CivilianId => getValue(Data?.CivilianId);
        public Event? Event => GetRepo.Instance<IEventsRepo>()?.Get(EventId);
        public Civilian? Civilian => GetRepo.Instance<ICiviliansRepo>()?.Get(CivilianId);
    }
    
}
