using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegisterSystem.Data.Party;
using RegisterSystem.Domain.Party;
using RegisterSystem.Facade.Party;

namespace RegisterSystem.Tests.Facade.Party
{
    [TestClass]
    public class EventCivilianViewFactoryTests
        : ViewFactoryTests<EventCivilianViewFactory, EventCivilianView, EventCivilian, EventCivilianData>
    {
        protected override EventCivilian toObject(EventCivilianData d) => new(d);
    }
}
