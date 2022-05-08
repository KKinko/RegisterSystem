using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegisterSystem.Aids;
using RegisterSystem.Data.Party;
using RegisterSystem.Domain.AbstractEntities;
using RegisterSystem.Domain.Party;

namespace RegisterSystem.Tests.Domain.Party
{
    [TestClass]
    public class EventTests : SealedClassTests<Event, AdditionalEntity<EventData>>
    {

        protected override Event createObj() => new(GetRandom.Value<EventData>());
        [TestMethod] public void EventsCiviliansTest()
            => itemsTest<IEventsCiviliansRepo, EventCivilian, EventCivilianData>(
                d => d.EventId = obj.Id, d => new EventCivilian(d), () => obj.EventsCivilians.Value);
        [TestMethod] public void CiviliansTest() => relatedItemsTest<ICiviliansRepo, EventCivilian, Civilian, CivilianData>
            (EventsCiviliansTest, () => obj.EventsCivilians.Value, () => obj.Civilians.Value,
              x => x.CivilianId, d => new Civilian(d), c => c?.Data, x => x?.Civilian?.Data);

        [TestMethod]
        public void EventsCompaniesTest()
            => itemsTest<IEventsCompaniesRepo, EventCompany, EventCompanyData>(
                d => d.EventId = obj.Id, d => new EventCompany(d), () => obj.EventsCompanies.Value);
        [TestMethod]
        public void CompaniesTest() => relatedItemsTest<ICompaniesRepo, EventCompany, Company, CompanyData>
            (EventsCompaniesTest, () => obj.EventsCompanies.Value, () => obj.Companies.Value,
              x => x.CompanyId, d => new Company(d), c => c?.Data, x => x?.Company?.Data);

        
    }
}
