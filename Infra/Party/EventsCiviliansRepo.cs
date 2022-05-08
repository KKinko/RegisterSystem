using RegisterSystem.Data.Party;
using RegisterSystem.Domain.Party;
using RegisterSystem.Infra.AbstractRepos;

namespace RegisterSystem.Infra.Party
{
    public sealed class EventsCiviliansRepo : Repo<EventCivilian, EventCivilianData>, IEventsCiviliansRepo
    {
        public EventsCiviliansRepo(RegisterDb? db) : base(db, db?.EventsCivilians) { }
        protected internal override EventCivilian toDomain(EventCivilianData d) => new(d);

        //public List<EventCivilian> GetId() => Get().FindAll(x => x.Id );
    }
}
