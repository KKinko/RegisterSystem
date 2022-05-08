using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegisterSystem.Facade.AbstractViews;

namespace RegisterSystem.Tests.Facade.AbstractViews
{
    [TestClass]
    public class UniqueViewTests : AbstractClassTests<UniqueView, object>
    {
        private class testClass : UniqueView { }
        protected override UniqueView createObj() => new testClass();
        [TestMethod] public void IdTest() => isProperty<string>();
    }
}
