using RegisterSystem.Data.AbstractData;
using RegisterSystem.Data.Party;

namespace RegisterSystem.Domain.AbstractEntities
{
    public abstract class UniqueEntity
    {
        public static string DefaultStr => "Undefined";
        private static int DefaultInt => 0;
        private static DateTime defaultDate => DateTime.MinValue;
        protected static string getValue(string? v) => v ?? DefaultStr;
        protected static int getValue(int? v) => v ?? DefaultInt;
        protected static PaymentMethod getValue(PaymentMethod? v) => v ?? PaymentMethod.Cash;
        protected static DateTime getValue(DateTime? v) => v ?? defaultDate;
        public abstract string Id { get; }
    }
    public abstract class UniqueEntity<TData> : UniqueEntity where TData : UniqueData, new()
    {
        public TData Data { get; }
        public UniqueEntity() : this(new TData()) { }
        public UniqueEntity(TData d) => Data = d;
        public override string Id => getValue(Data?.Id);
    }
}
