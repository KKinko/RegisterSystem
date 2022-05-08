using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegisterSystem.Data.AbstractData;
using RegisterSystem.Data.Party;

namespace RegisterSystem.Tests.Data.Party
{
    [TestClass] public class CompanyDataTests : SealedClassTests<CompanyData, PaymentData> 
    {
        [TestMethod] public void CompanyNameTest() => isProperty<string?>();
        [TestMethod] public void RegisterCodeTest() => isProperty<string?>();
        [TestMethod] public void ParticipantsTest() => isProperty<int?>();
    }
}
