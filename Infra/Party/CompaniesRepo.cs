using RegisterSystem.Data.Party;
using RegisterSystem.Domain.Party;
using RegisterSystem.Infra.AbstractRepos;

namespace RegisterSystem.Infra.Party
{
    public sealed class CompaniesRepo : Repo<Company, CompanyData>, ICompaniesRepo
    {
        public CompaniesRepo(RegisterDb? db) : base(db, db?.Companies) { }
        protected internal override Company toDomain(CompanyData d) => new(d);
    }
}
