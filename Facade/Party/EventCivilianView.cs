using RegisterSystem.Data.Party;
using RegisterSystem.Domain.Party;
using RegisterSystem.Facade.AbstractViews;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RegisterSystem.Facade.Party
{
    public sealed class EventCivilianView : UniqueView
    {
        [Required][DisplayName("Üritus")] public string EventId { get; set; } = string.Empty;
        [Required][DisplayName("Eraisik")] public string CivilianId { get; set; } = string.Empty;
    }
    public sealed class EventCivilianViewFactory :
        BaseViewFactory<EventCivilianView, EventCivilian, EventCivilianData>
    {
        protected override EventCivilian toEntity(EventCivilianData d) => new(d);
    }

}


