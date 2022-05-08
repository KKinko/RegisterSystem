
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegisterSystem.Data.AbstractData;
using RegisterSystem.Data.Party;

namespace RegisterSystem.Tests.Data.Party
{
    [TestClass] public class EventCivilianDataTests : SealedClassTests<EventCivilianData, UniqueData> 
    {
        [TestMethod] public void EventIdTest() => isProperty<string>();
        [TestMethod] public void CivilianIdTest() => isProperty<string>();
    }
}
