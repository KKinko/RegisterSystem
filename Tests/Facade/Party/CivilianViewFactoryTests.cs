using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegisterSystem.Aids;
using RegisterSystem.Data.Party;
using RegisterSystem.Domain.Party;
using RegisterSystem.Facade;
using RegisterSystem.Facade.Party;

namespace RegisterSystem.Tests.Facade.Party
{
    [TestClass] public class CivilianViewFactoryTests
        : SealedClassTests<CivilianViewFactory, BaseViewFactory<CivilianView, Civilian, CivilianData>>
    {
        [TestMethod] public void CreateTest() { }
        [TestMethod]
        public void CreateViewTest()
        {
            var d = GetRandom.Value<CivilianData>();
            var e = new Civilian(d);
            var v = new CivilianViewFactory().Create(e);
            isNotNull(v);
            areEqual(v.IdCode, e.IdCode);
            areEqual(v.Id, e.Id);
            areEqual(v.FirstName, e.FirstName);
            areEqual(v.LastName, e.LastName);
            areEqual(v.Payment, e.Payment);
            areEqual(v.Information, e.Information);
            areEqual(v.FullName, e.ToString());
        }
        [TestMethod]
        public void CreateEntityTest()
        {
            var v = GetRandom.Value<CivilianView>() as CivilianView;
            var e = new CivilianViewFactory().Create(v);
            isNotNull(e);
            isNotNull(v);
            arePropertiesEqual(e, v);
            areNotEqual(e.ToString(), v.FullName);
        }

    }
}
