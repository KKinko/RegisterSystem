using System.ComponentModel;

namespace RegisterSystem.Data.Party
{
    public enum PaymentMethod
    {
        [Description("Sularaha")] Cash = 0,
        [Description("Pangaülekanne")] Transfer = 1
    }
}
