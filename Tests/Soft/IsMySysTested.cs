using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RegisterSystem.Tests.Soft
{
    [TestClass]
    public class IsMySysTested : AssemblyTests
    {
        protected override void isAllTested() => isInconclusive("Namespace has to be changed to \"Register.MySys\"");
    }
}
