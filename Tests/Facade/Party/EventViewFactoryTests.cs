using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegisterSystem.Data.Party;
using RegisterSystem.Domain.Party;
using RegisterSystem.Facade.Party;

namespace RegisterSystem.Tests.Facade.Party
{
    [TestClass]
    public class EventViewFactoryTests
        : ViewFactoryTests<EventViewFactory, EventView, Event, EventData>
    {
        protected override Event toObject(EventData d) => new(d);
    }
}
