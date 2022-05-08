using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegisterSystem.Facade.AbstractViews;
using RegisterSystem.Facade.Party;

namespace RegisterSystem.Tests.Facade.Party
{
    [TestClass]
    public class CivilianViewTests : SealedClassTests<CivilianView, PaymentView>
    {
        [TestMethod] public void FirstNameTest() => isRequired<string>("Eesnimi");
        [TestMethod] public void LastNameTest() => isRequired<string?>("Perenimi");
        [TestMethod] public void IdCodeTest() => isRequired<string?>("Isikukood");
        [TestMethod] public void InformationTest() => isDisplayNamed<string?>("LisaInfo");
        [TestMethod] public void FullNameTest() => isDisplayNamed<string?>("Isik");
    }
}