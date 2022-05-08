using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegisterSystem.Data.Party;
using RegisterSystem.Domain.IRepos;
using RegisterSystem.Infra;
using RegisterSystem.Infra.Initializers;

namespace RegisterSystem.Tests.Infra.Initializers
{
    [TestClass]
    public class EventsInitializerTests
        : SealedBaseTests<EventsInitializer, BaseInitializer<EventData>>
    {
        protected override EventsInitializer createObj()
        {
            var db = GetRepo.Instance<RegisterDb>();
            return new EventsInitializer(db);
        }
    }
}