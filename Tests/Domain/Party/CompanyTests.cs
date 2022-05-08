using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegisterSystem.Aids;
using RegisterSystem.Data.Party;
using RegisterSystem.Domain.AbstractEntities;
using RegisterSystem.Domain.Party;

namespace RegisterSystem.Tests.Domain.Party
{
    [TestClass]
    public class CompanyTests : SealedClassTests<Company, PaymentEntity<CompanyData>>
    {
        protected override Company createObj() => new(GetRandom.Value<CompanyData>());
        [TestMethod] public void CompanyNameTest() => isReadOnly(obj.Data.CompanyName);
        [TestMethod] public void RegisterCodeTest() => isReadOnly(obj.Data.RegisterCode);
        [TestMethod] public void ParticipantsTest() => isReadOnly(obj.Data.Participants);
        [TestMethod]
        public void ToStringTest()
        {
            var expected = $"{obj.CompanyName} {obj.RegisterCode}";
            areEqual(expected, obj.ToString());
        }
    }
}
