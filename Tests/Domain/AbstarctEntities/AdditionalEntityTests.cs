using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegisterSystem.Aids;
using RegisterSystem.Data.Party;
using RegisterSystem.Domain.AbstractEntities;

namespace RegisterSystem.Tests.Domain.AbstarctEntities
{
    [TestClass]
    public class AdditionalEntityTests : AbstractClassTests<AdditionalEntity<CompanyData>, UniqueEntity<CompanyData>>
    {
        private class testClass : AdditionalEntity<CompanyData>
        {
            public testClass() : this(new CompanyData()) { }
            public testClass(CompanyData d) : base(d) { }
        }
        protected override AdditionalEntity<CompanyData> createObj() => new testClass(GetRandom.Value<CompanyData>());
        [TestMethod] public void InformationTest() => isReadOnly(obj.Data.Information);
    }
}