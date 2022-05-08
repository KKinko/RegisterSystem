using RegisterSystem.Data.Party;
using RegisterSystem.Domain.AbstractEntities;
using RegisterSystem.Domain.IRepos;

namespace RegisterSystem.Domain.Party
{
    public interface IEventsCompaniesRepo : IRepo<EventCompany> 
    {
        //List<EventCivilian> GetId();
    }
    public sealed class EventCompany : UniqueEntity<EventCompanyData>
    {
        public EventCompany() : this(new()) { }
        public EventCompany(EventCompanyData d) : base(d) { }
        public string EventId => getValue(Data?.EventId);
        public string CompanyId => getValue(Data?.CompanyId);
        public Event? Event => GetRepo.Instance<IEventsRepo>()?.Get(EventId);
        public Company? Company => GetRepo.Instance<ICompaniesRepo>()?.Get(CompanyId);
    }

}
