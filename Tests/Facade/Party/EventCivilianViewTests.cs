using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegisterSystem.Facade.AbstractViews;
using RegisterSystem.Facade.Party;

namespace RegisterSystem.Tests.Facade.Party
{
    [TestClass]
    public class EventCivilianViewTests : SealedClassTests<EventCivilianView, UniqueView>
    {
        [TestMethod] public void EventIdTest() => isRequired<string>("Üritus");
        [TestMethod] public void CivilianIdTest() => isRequired<string>("Eraisik");
    }
}