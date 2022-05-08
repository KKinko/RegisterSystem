using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegisterSystem.Data.Party;
using RegisterSystem.Facade.AbstractViews;

namespace RegisterSystem.Tests.Facade.AbstractViews
{
    [TestClass]
    public class PaymentViewTests : AbstractClassTests<PaymentView, AdditionalView>
    {
        private class testClass : PaymentView { }
        protected override PaymentView createObj() => new testClass();
        [TestMethod] public void PaymentTest() => isDisplayNamed<PaymentMethod?>("Maksmisviis");
    }
}
