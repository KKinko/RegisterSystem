using RegisterSystem.Data.Party;
using RegisterSystem.Domain.Party;
using RegisterSystem.Infra.AbstractRepos;

namespace RegisterSystem.Infra.Party
{
    public sealed class EventsCompaniesRepo : Repo<EventCompany, EventCompanyData>, IEventsCompaniesRepo
    {
        public EventsCompaniesRepo(RegisterDb? db) : base(db, db?.EventsCompanies) { }
        protected internal override EventCompany toDomain(EventCompanyData d) => new(d);
        //public List<EventCompanies> GetId() => Get().FindAll(x => x.Id );
    }
}
