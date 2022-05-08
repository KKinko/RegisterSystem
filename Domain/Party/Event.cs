using RegisterSystem.Data.Party;
using RegisterSystem.Domain.AbstractEntities;
using RegisterSystem.Domain.IRepos;

namespace RegisterSystem.Domain.Party
{
    public interface IEventsRepo : IRepo<Event> 
    {

        List<Event> GetFuture();
        List<Event> GetPast();
    }
    public sealed class Event : AdditionalEntity<EventData>
    {
        public Event() : this(new()) { }
        public Event(EventData d) : base(d) { }
        public string EventName => getValue(Data?.EventName);
        public DateTime Time => getValue(Data?.Time);
        public string Place => getValue(Data?.Place);
        public override string ToString() => $"{EventName} {Time} {Place}";




        public Lazy<List<EventCivilian>> EventsCivilians
        {
            get
            {
                var l = GetRepo.Instance<IEventsCiviliansRepo>()?
                   .GetAll(x => x.EventId)?
                   .Where(x => x.EventId == Id)?
                   .ToList() ?? new List<EventCivilian>();
                return new Lazy<List<EventCivilian>>(l);
            }
        }

        public Lazy<List<Civilian?>> Civilians
        {
            get
            {
                var l = EventsCivilians.Value
                .Select(x => x.Civilian)
                .ToList() ?? new List<Civilian?>();
                return new Lazy<List<Civilian?>>(l);
            }
        }

        public Lazy<List<EventCompany>> EventsCompanies
        {
            get
            {
                var l = GetRepo.Instance<IEventsCompaniesRepo>()?
                   .GetAll(x => x.EventId)?
                   .Where(x => x.EventId == Id)?
                   .ToList() ?? new List<EventCompany>();
                return new Lazy<List<EventCompany>>(l);
            }
        }

        public Lazy<List<Company?>> Companies
        {
            get
            {
                var l = EventsCompanies.Value
                .Select(x => x.Company)
                .ToList() ?? new List<Company?>();
                return new Lazy<List<Company?>>(l);
            }
        }
    }
}
