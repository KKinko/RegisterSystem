using RegisterSystem.Data.AbstractData;

namespace RegisterSystem.Domain.AbstractEntities
{
    public abstract class AdditionalEntity<TData> : UniqueEntity<TData> where TData : AdditionalData, new()
    {
        protected AdditionalEntity() : this(new TData()) { }
        protected AdditionalEntity(TData d) : base(d) { }
        public string Information => getValue(Data?.Information);
    }
}
