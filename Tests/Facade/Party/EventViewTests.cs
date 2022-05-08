using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegisterSystem.Facade.AbstractViews;
using RegisterSystem.Facade.Party;
using System;

namespace RegisterSystem.Tests.Facade.Party
{
    [TestClass] public class EventViewTests : SealedClassTests<EventView, AdditionalView> 
    {
        [TestMethod] public void EventNameTest() => isRequired<string>("Ürituse nimi");
        [TestMethod] public void TimeTest() => isRequired<DateTime?>("Kuupäev");
        [TestMethod] public void PlaceTest() => isRequired<string?>("Koht");
        [TestMethod] public void InformationTest() => isDisplayNamed<string?>("LisaInfo");

    }
}
