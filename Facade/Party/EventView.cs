using RegisterSystem.Data.Party;
using RegisterSystem.Domain.Party;
using RegisterSystem.Facade.AbstractViews;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RegisterSystem.Facade.Party
{
    public sealed class EventView : AdditionalView
    {
        [Required][DisplayName("Ürituse nimi")] public string? EventName { get; set; }
        [Required][DisplayName("Kuupäev")][FutureDates] public DateTime? Time { get; set; }
        [Required][DisplayName("Koht")]  public string? Place { get; set; }
        [DisplayName("LisaInfo")][StringLength(1000)] public new string? Information { get; set; }
    }

    public sealed class EventViewFactory : BaseViewFactory<EventView, Event, EventData>
    {
        protected override Event toEntity(EventData d) => new(d);
    }
}
