using RegisterSystem.Data.Party;
using RegisterSystem.Domain.AbstractEntities;
using RegisterSystem.Domain.IRepos;

namespace RegisterSystem.Domain.Party
{
    public interface ICompaniesRepo : IRepo<Company> { }
    public sealed class Company : PaymentEntity<CompanyData>
    {
        public Company() : this(new()) { }
        public Company(CompanyData d) : base(d) { }
        public string CompanyName => getValue(Data?.CompanyName);
        public string RegisterCode => getValue(Data?.RegisterCode);
        public int Participants => getValue(Data?.Participants);
        public override string ToString() => $"{CompanyName} {RegisterCode}";
    }

}
