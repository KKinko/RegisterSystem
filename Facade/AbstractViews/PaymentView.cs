using RegisterSystem.Data.Party;
using System.ComponentModel;

namespace RegisterSystem.Facade.AbstractViews
{
    public abstract class PaymentView : AdditionalView
    {
        [DisplayName("Maksmisviis")] public PaymentMethod? Payment { get; set; }
    }
}
