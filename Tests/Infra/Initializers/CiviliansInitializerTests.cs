using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegisterSystem.Data.Party;
using RegisterSystem.Domain.IRepos;
using RegisterSystem.Infra;
using RegisterSystem.Infra.Initializers;

namespace RegisterSystem.Tests.Infra.Initializers
{
    [TestClass]
    public class CiviliansInitializerTests
        : SealedBaseTests<CiviliansInitializer, BaseInitializer<CivilianData>>
    {
        protected override CiviliansInitializer createObj()
        {
            var db = GetRepo.Instance<RegisterDb>();
            return new CiviliansInitializer(db);
        }
    }
}