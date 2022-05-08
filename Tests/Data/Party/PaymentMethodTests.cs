using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegisterSystem.Aids;
using RegisterSystem.Data.Party;

namespace RegisterSystem.Tests.Data.Party
{
    [TestClass]
    public class PaymentMethodTests : TypeTests
    {
        [TestMethod] public void CashTest() => doTest(PaymentMethod.Cash, 0, "Sularaha");
        [TestMethod] public void TransferTest() => doTest(PaymentMethod.Transfer, 1, "Pangaülekanne");
        private static void doTest(PaymentMethod payementMethod, int value, string description)
        {
            areEqual(value, (int)payementMethod);
            areEqual(description, payementMethod.Description());
        }
    }
}
