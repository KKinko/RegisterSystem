
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegisterSystem.Data.AbstractData;
using RegisterSystem.Data.Party;
using System;

namespace RegisterSystem.Tests.Data.Party
{
    [TestClass]
    public class EventDataTests : SealedClassTests<EventData, AdditionalData>
    {
        [TestMethod] public void EventNameTest() => isProperty<string>();
        [TestMethod] public void TimeTest() => isProperty<DateTime?>();
        [TestMethod] public void PlaceTest() => isProperty<string?>();    }
}
