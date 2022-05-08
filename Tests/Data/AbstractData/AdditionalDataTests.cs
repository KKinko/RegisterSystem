using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegisterSystem.Data.AbstractData;

namespace RegisterSystem.Tests.Data.AbstractData
{
    [TestClass]
    public class AdditionalDataTests : AbstractClassTests<AdditionalData, UniqueData>
    {
        private class testClass : AdditionalData { }
        protected override AdditionalData createObj() => new testClass();
        [TestMethod] public void InformationTest() => isProperty<string>();
    }
}
