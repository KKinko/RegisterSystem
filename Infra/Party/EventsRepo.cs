using RegisterSystem.Data.Party;
using RegisterSystem.Domain.Party;
using RegisterSystem.Infra.AbstractRepos;

namespace RegisterSystem.Infra.Party
{
    public sealed class EventsRepo : Repo<Event, EventData>, IEventsRepo
    {

        public EventsRepo(RegisterDb? db) : base(db, db?.Events) { }
        protected internal override Event toDomain(EventData d) => new(d);

        public  List<Event> GetFuture() => Get().FindAll(x => x.Time >= DateTime.Now);//  GetAll(x => x.Time <= DateTime.Now);
            

        public  List<Event> GetPast() => Get().FindAll(x => x.Time <= DateTime.Now);
        
    }
}
