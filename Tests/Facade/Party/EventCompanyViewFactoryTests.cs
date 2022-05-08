using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegisterSystem.Data.Party;
using RegisterSystem.Domain.Party;
using RegisterSystem.Facade.Party;

namespace RegisterSystem.Tests.Facade.Party
{
    [TestClass]
    public class EventCompanyViewFactoryTests
        : ViewFactoryTests<EventCompanyViewFactory, EventCompanyView, EventCompany, EventCompanyData>
    {
        protected override EventCompany toObject(EventCompanyData d) => new(d);
    }
}
