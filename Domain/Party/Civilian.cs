using RegisterSystem.Data.Party;
using RegisterSystem.Domain.AbstractEntities;
using RegisterSystem.Domain.IRepos;

namespace RegisterSystem.Domain.Party
{
    public interface ICiviliansRepo : IRepo<Civilian> { }
    public sealed class Civilian : PaymentEntity<CivilianData>
    {
        public Civilian() : this(new()) { }
        public Civilian(CivilianData d) : base(d) { }
        public string FirstName => getValue(Data?.FirstName);
        public string LastName => getValue(Data?.LastName);
        public string IdCode => getValue(Data?.IdCode);
        public override string ToString() => $"{FirstName} {LastName} {IdCode}";
    }
}
