
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegisterSystem.Aids;
using RegisterSystem.Data.Party;
using RegisterSystem.Domain.AbstractEntities;

namespace RegisterSystem.Tests.Domain.AbstarctEntities
{
    [TestClass]
    public class UniqueEntityTests : AbstractClassTests<UniqueEntity<EventData>, UniqueEntity>
    {
        private EventData? d;
        private class testClass : UniqueEntity<EventData>
        {
            public testClass() : this(new EventData()) { }
            public testClass(EventData d) : base(d) { }
        }
        protected override UniqueEntity<EventData> createObj()
        {
            d = GetRandom.Value<EventData>();
            return new testClass(d);
        }
        [TestMethod] public void IdTest() => isReadOnly(obj.Data.Id);
        [TestMethod] public void DataTest() => isReadOnly(d);
        [TestMethod] public void DefaultStrTest() => areEqual("Undefined", UniqueEntity.DefaultStr);
    }
}
