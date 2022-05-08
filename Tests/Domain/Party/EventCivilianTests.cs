using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegisterSystem.Aids;
using RegisterSystem.Data.Party;
using RegisterSystem.Domain.AbstractEntities;
using RegisterSystem.Domain.Party;

namespace RegisterSystem.Tests.Domain.Party
{
    [TestClass]
    public class EventCivilianTests : SealedClassTests<EventCivilian, UniqueEntity<EventCivilianData>>
    {
        protected override EventCivilian createObj() => new(GetRandom.Value<EventCivilianData>());
        [TestMethod] public void EventIdTest() => isReadOnly(obj.Data.EventId);
        [TestMethod] public void EventTest() => itemTest<IEventsRepo, Event, EventData>(
            obj.EventId, d => new Event(d), () => obj.Event);
        [TestMethod] public void CivilianIdTest() => isReadOnly(obj.Data.CivilianId);
        [TestMethod] public void CivilianTest() => itemTest<ICiviliansRepo, Civilian, CivilianData>(
            obj.CivilianId, d => new Civilian(d), () => obj.Civilian);
    }
}
