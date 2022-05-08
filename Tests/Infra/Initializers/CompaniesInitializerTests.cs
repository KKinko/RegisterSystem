using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegisterSystem.Data.Party;
using RegisterSystem.Domain.IRepos;
using RegisterSystem.Infra;
using RegisterSystem.Infra.Initializers;

namespace RegisterSystem.Tests.Infra.Initializers
{

    [TestClass]
    public class CompaniesInitializerTests
        : SealedBaseTests<CompaniesInitializer, BaseInitializer<CompanyData>>
    {
        protected override CompaniesInitializer createObj()
        {
            var db = GetRepo.Instance<RegisterDb>();
            return new CompaniesInitializer(db);
        }
    }
}