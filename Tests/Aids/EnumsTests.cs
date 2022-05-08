using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegisterSystem.Aids;
using RegisterSystem.Data.Party;

namespace RegisterSystem.Tests.Aids
{
    [TestClass]
    public class EnumsTests : TypeTests
    {
        [TestMethod]
        public void DescriptionTest()
             => areEqual("Sularaha", Enums.Description(PaymentMethod.Cash));
        [TestMethod]
        public void ToStringTest()
              => areEqual("Cash", PaymentMethod.Cash.ToString());
    }
}
