using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegisterSystem.Aids;
using RegisterSystem.Data.Party;
using RegisterSystem.Domain.Party;
using RegisterSystem.Facade;
using RegisterSystem.Facade.Party;

namespace RegisterSystem.Tests.Facade
{
    [TestClass]
    public class BaseViewFactoryTests : AbstractClassTests<BaseViewFactory<EventView, Event, EventData>, object>
    {
        private class testClass : BaseViewFactory<EventView, Event, EventData>
        {
            protected override Event toEntity(EventData d) => new(d);
        }
        protected override BaseViewFactory<EventView, Event, EventData> createObj() => new testClass();

        [TestMethod] public void CreateTest() { }
        [TestMethod]
        public void CreateViewTest()
        {
            var v = GetRandom.Value<EventView>();
            var o = obj.Create(v);
            areEqualProperties(v, o.Data);
        }
        [TestMethod]
        public void CreateObjectTest()
        {
            var d = GetRandom.Value<EventData>();
            var v = obj.Create(new Event(d));
            areEqualProperties(d, v);
        }
    }
}
