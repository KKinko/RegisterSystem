using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegisterSystem.Facade.AbstractViews;
using RegisterSystem.Facade.Party;

namespace RegisterSystem.Tests.Facade.Party
{
    [TestClass]
    public class EventCompanyViewTests : SealedClassTests<EventCompanyView, UniqueView>
    {
        [TestMethod] public void EventIdTest() => isRequired<string>("Üritus");
        [TestMethod] public void CompanyIdTest() => isRequired<string>("Äriklient");
    }
}