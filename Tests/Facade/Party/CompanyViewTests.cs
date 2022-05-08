using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegisterSystem.Facade.AbstractViews;
using RegisterSystem.Facade.Party;

namespace RegisterSystem.Tests.Facade.Party
{
    [TestClass] public class CompanyViewTests : SealedClassTests<CompanyView, PaymentView> 
    {
            [TestMethod] public void CompanyNameTest() => isRequired<string>("Ettevõtte juriidiline nimi");
            [TestMethod] public void RegisterCodeTest() => isRequired<string?>("Ettevõtte registrikood");
            [TestMethod] public void ParticipantsTest() => isRequired<int?>("Ettevõttest tulevate osavõtjate arv");
            [TestMethod] public void InformationTest() => isDisplayNamed<string?>("LisaInfo");
            [TestMethod] public void FullNameTest() => isDisplayNamed<string?>("Ettevõte");
        
    }
}
