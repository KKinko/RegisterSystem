using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegisterSystem.Data.Party;
using RegisterSystem.Domain.IRepos;
using RegisterSystem.Domain.Party;
using RegisterSystem.Infra;
using RegisterSystem.Infra.AbstractRepos;
using RegisterSystem.Infra.Party;

namespace RegisterSystem.Tests.Infra.Party
{

    [TestClass]
    public class CompaniesRepoTests : SealedRepoTests<CompaniesRepo, Repo<Company, CompanyData>, Company, CompanyData>
    {
        protected override CompaniesRepo createObj() => new(GetRepo.Instance<RegisterDb>());
        protected override object? getSet(RegisterDb db) => db.Companies;
    }
}
