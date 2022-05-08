using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegisterSystem.Data.Party;
using RegisterSystem.Domain.IRepos;
using RegisterSystem.Domain.Party;
using RegisterSystem.Infra;
using RegisterSystem.Infra.AbstractRepos;
using RegisterSystem.Infra.Party;

namespace RegisterSystem.Tests.Infra.Party
{
    [TestClass]
    public class EventsRepoTests : SealedRepoTests<EventsRepo, Repo<Event, EventData>, Event, EventData>
    {
        protected override EventsRepo createObj() => new(GetRepo.Instance<RegisterDb>());
        protected override object? getSet(RegisterDb db) => db.Events;
    }
}
