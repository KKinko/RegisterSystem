using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegisterSystem.Facade.AbstractViews;

namespace RegisterSystem.Tests.Facade.AbstractViews
{
    [TestClass]
    public class AdditionalTests : AbstractClassTests<AdditionalView, UniqueView>
    {
        private class testClass : AdditionalView { }
        protected override AdditionalView createObj() => new testClass();
        [TestMethod] public void InformationTest() => isDisplayNamed<string?>("LisaInfo");
    }
}
