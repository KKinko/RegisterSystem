using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegisterSystem.Aids;
using RegisterSystem.Data.Party;

namespace RegisterSystem.Tests.Aids
{
    [TestClass]
    public class GetNamespaceTests : TypeTests
    {
        [TestMethod]
        public void OfTypeTest()
        {
            var obj = new CompanyData();
            var name = obj.GetType().Namespace;
            var n = GetNamespace.OfType(obj);
            areEqual(name, n);
        }
        [TestMethod]
        public void OfTypeNullTest()
        {
            CompanyData? obj = null;
            var n = GetNamespace.OfType(obj);
            areEqual(string.Empty, n);
        }
    }
}
