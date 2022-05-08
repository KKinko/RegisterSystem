using RegisterSystem.Data.Party;

namespace RegisterSystem.Data.AbstractData
{
    public abstract class PaymentData : AdditionalData
    {
        public PaymentMethod? Payment { get; set; }
    }
}
