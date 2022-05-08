using Microsoft.EntityFrameworkCore;
using RegisterSystem.Data.AbstractData;
using RegisterSystem.Domain.AbstractEntities;

namespace RegisterSystem.Infra.AbstractRepos
{
    public abstract class FuturePastRepo<TDomain, TData> : CrudRepo<TDomain, TData>
        where TDomain : UniqueEntity<TData>, new() where TData : UniqueData, new()
    {
        protected FuturePastRepo(DbContext? c, DbSet<TData>? s) : base(c, s) { }

        //public virtual List<TDomain> GetFuture();
        //public virtual List<TDomain> GetPast();
    }

}
