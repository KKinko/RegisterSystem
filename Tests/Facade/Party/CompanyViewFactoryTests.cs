using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegisterSystem.Aids;
using RegisterSystem.Data.Party;
using RegisterSystem.Domain.Party;
using RegisterSystem.Facade;
using RegisterSystem.Facade.Party;

namespace RegisterSystem.Tests.Facade.Party
{
    [TestClass]
    public class CompanyViewFactoryTests
        : SealedClassTests<CompanyViewFactory, BaseViewFactory<CompanyView, Company, CompanyData>>
    {
        [TestMethod] public void CreateTest() { }
        [TestMethod]
        public void CreateViewTest()
        {
            var d = GetRandom.Value<CompanyData>();
            var e = new Company(d);
            var v = new CompanyViewFactory().Create(e);
            isNotNull(v);
            areEqual(v.RegisterCode, e.RegisterCode);
            areEqual(v.Id, e.Id);
            areEqual(v.CompanyName, e.CompanyName);
            areEqual(v.Participants, e.Participants);
            areEqual(v.Payment, e.Payment);
            areEqual(v.Information, e.Information);
            areEqual(v.FullName, e.ToString());
        }
        [TestMethod]
        public void CreateEntityTest()
        {
            var v = GetRandom.Value<CompanyView>() as CompanyView;
            var e = new CompanyViewFactory().Create(v);
            isNotNull(e);
            isNotNull(v);
            arePropertiesEqual(e, v);
            areNotEqual(e.ToString(), v.FullName);
        }

    }
}
