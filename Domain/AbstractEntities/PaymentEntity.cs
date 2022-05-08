using RegisterSystem.Data.AbstractData;
using RegisterSystem.Data.Party;

namespace RegisterSystem.Domain.AbstractEntities
{
    public abstract class PaymentEntity<TData> : AdditionalEntity<TData> where TData : PaymentData, new()
    {
        protected PaymentEntity() : this(new TData()) { }
        protected PaymentEntity(TData d) : base(d) { }
        public PaymentMethod Payment => getValue(Data?.Payment);
    }
}
