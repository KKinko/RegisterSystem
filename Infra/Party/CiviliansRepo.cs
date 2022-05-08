using RegisterSystem.Data.Party;
using RegisterSystem.Domain.Party;
using RegisterSystem.Infra.AbstractRepos;

namespace RegisterSystem.Infra.Party
{
    public sealed class CiviliansRepo : Repo<Civilian, CivilianData>, ICiviliansRepo
    {
        public CiviliansRepo(RegisterDb? db) : base(db, db?.Civilians) { }
        protected internal override Civilian toDomain(CivilianData d) => new(d);
    }
}
