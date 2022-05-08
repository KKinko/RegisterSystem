using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegisterSystem.Aids;
using RegisterSystem.Data.Party;
using RegisterSystem.Domain.AbstractEntities;

namespace RegisterSystem.Tests.Domain.AbstarctEntities
{
    [TestClass]
    public class PaymentEntityTests : AbstractClassTests<PaymentEntity<CivilianData>, AdditionalEntity<CivilianData>>
    {
        private class testClass : PaymentEntity<CivilianData>
        {
            public testClass() : this(new CivilianData()) { }
            public testClass(CivilianData d) : base(d) { }
        }
        protected override PaymentEntity<CivilianData> createObj() => new testClass(GetRandom.Value<CivilianData>());
        [TestMethod] public void PaymentTest() => isReadOnly(obj.Data.Payment);
    }
}