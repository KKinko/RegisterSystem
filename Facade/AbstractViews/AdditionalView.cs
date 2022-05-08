using System.ComponentModel;

namespace RegisterSystem.Facade.AbstractViews
{
    public abstract class AdditionalView : UniqueView
    {
        [DisplayName("LisaInfo")] public string? Information { get; set; }
    }
}
