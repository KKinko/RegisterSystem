using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegisterSystem.Aids;
using RegisterSystem.Data.Party;
using RegisterSystem.Domain.AbstractEntities;
using RegisterSystem.Domain.Party;

namespace RegisterSystem.Tests.Domain.Party
{
    [TestClass]
    
    public class CivilianTests : SealedClassTests<Civilian, PaymentEntity<CivilianData>>
    {
        protected override Civilian createObj() => new(GetRandom.Value<CivilianData>());
        [TestMethod] public void FirstNameTest() => isReadOnly(obj.Data.FirstName);
        [TestMethod] public void LastNameTest() => isReadOnly(obj.Data.LastName);
        [TestMethod] public void IdCodeTest() => isReadOnly(obj.Data.IdCode);
        [TestMethod]
        public void ToStringTest()
        {
            var expected = $"{obj.FirstName} {obj.LastName} {obj.IdCode}";
            areEqual(expected, obj.ToString());
        }
    }
}
