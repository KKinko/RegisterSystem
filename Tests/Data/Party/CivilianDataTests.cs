using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegisterSystem.Data.AbstractData;
using RegisterSystem.Data.Party;

namespace RegisterSystem.Tests.Data.Party
{
    [TestClass]
    public class CivilianDataTests : SealedClassTests<CivilianData, PaymentData>
    {
        [TestMethod] public void FirstNameTest() => isProperty<string?>();
        [TestMethod] public void LastNameTest() => isProperty<string?>();
        [TestMethod] public void IdCodeTest() => isProperty<string?>();
    }
}
