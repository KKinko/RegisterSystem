
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegisterSystem.Data.AbstractData;
using RegisterSystem.Data.Party;

namespace RegisterSystem.Tests.Data.Party
{
    [TestClass]
    public class EventCompanyDataTests : SealedClassTests<EventCompanyData, UniqueData>
    {
        [TestMethod] public void EventIdTest() => isProperty<string>();
        [TestMethod] public void CompanyIdTest() => isProperty<string>();
    }
}
