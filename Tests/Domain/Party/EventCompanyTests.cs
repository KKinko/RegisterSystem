using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegisterSystem.Aids;
using RegisterSystem.Data.Party;
using RegisterSystem.Domain.AbstractEntities;
using RegisterSystem.Domain.Party;

namespace RegisterSystem.Tests.Domain.Party
{

    [TestClass]
    public class EventCompanyTests : SealedClassTests<EventCompany, UniqueEntity<EventCompanyData>>
    {
        protected override EventCompany createObj() => new(GetRandom.Value<EventCompanyData>());
        [TestMethod] public void EventIdTest() => isReadOnly(obj.Data.EventId);
        [TestMethod]public void EventTest() => itemTest<IEventsRepo, Event, EventData>(
            obj.EventId, d => new Event(d), () => obj.Event);
        [TestMethod] public void CompanyIdTest() => isReadOnly(obj.Data.CompanyId);
        [TestMethod] public void CompanyTest() => itemTest<ICompaniesRepo, Company, CompanyData>(
            obj.CompanyId, d => new Company(d), () => obj.Company);
    }
}
