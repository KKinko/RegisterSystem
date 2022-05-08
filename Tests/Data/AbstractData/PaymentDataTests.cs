using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegisterSystem.Data.AbstractData;
using RegisterSystem.Data.Party;

namespace RegisterSystem.Tests.Data.AbstractData
{
    [TestClass]
    public class PaymentDataTests : AbstractClassTests<PaymentData, AdditionalData>
    {
        private class testClass : PaymentData { }
        protected override PaymentData createObj() => new testClass();
        [TestMethod] public void PaymentTest() => isProperty<PaymentMethod>();
    }
}
