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
    public class EventsCiviliansRepoTests
        : SealedRepoTests<EventsCiviliansRepo, Repo<EventCivilian, EventCivilianData>, EventCivilian, EventCivilianData>
    {
        protected override EventsCiviliansRepo createObj() => new(GetRepo.Instance<RegisterDb>());
        protected override object? getSet(RegisterDb db) => db.EventsCivilians;
    }
}
