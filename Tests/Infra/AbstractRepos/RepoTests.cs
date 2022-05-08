using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegisterSystem.Data.Party;
using RegisterSystem.Domain.Party;
using RegisterSystem.Infra;
using RegisterSystem.Infra.AbstractRepos;

namespace RegisterSystem.Tests.Infra.AbstractRepos
{
    [TestClass]
    public class RepoTests
        : AbstractClassTests<Repo<Company, CompanyData>, CrudRepo<Company, CompanyData>>
    {
        private class testClass : Repo<Company, CompanyData>
        {
            public testClass(DbContext? c, DbSet<CompanyData>? s) : base(c, s) { }
            protected internal override Company toDomain(CompanyData d) => new(d);
        }
        protected override Repo<Company, CompanyData> createObj() => new testClass(null, null);
    }

    [TestClass]
    public class RegisterDbTests : SealedBaseTests<RegisterDb, DbContext>
    {
        protected override RegisterDb createObj() => null;
        protected override void isSealedTest() => isInconclusive();
    }
}

