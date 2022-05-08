using Microsoft.EntityFrameworkCore;
using RegisterSystem.Data.AbstractData;
using RegisterSystem.Domain.AbstractEntities;

namespace RegisterSystem.Infra.AbstractRepos
{
    public abstract class Repo<TDomain, TData> : FuturePastRepo<TDomain, TData>
        where TDomain : UniqueEntity<TData>, new() where TData : UniqueData, new()
    {
        protected Repo(DbContext? c, DbSet<TData>? s) : base(c, s) { }
    }
}
