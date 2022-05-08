using Microsoft.AspNetCore.Mvc.Rendering;
using RegisterSystem.Domain.Party;
using RegisterSystem.Facade.Party;
using RegisterSystem.Pages.AbstractPages;

namespace RegisterSystem.Pages.Party
{
    public class EventsCiviliansPage : CrudPage<EventCivilianView, EventCivilian, IEventsCiviliansRepo>
    {
        private readonly IEventsRepo events;
        private readonly ICiviliansRepo civilians;
        public EventsCiviliansPage(IEventsCiviliansRepo r, IEventsRepo ev, ICiviliansRepo ci) : base(r)
        {
            events = ev;
            civilians = ci;
        }
        protected override EventCivilian toObject(EventCivilianView? item) => new EventCivilianViewFactory().Create(item);
        protected override EventCivilianView toView(EventCivilian? entity) => new EventCivilianViewFactory().Create(entity);
        public override string[] IndexColumns { get; } = new[] {
            nameof(EventCivilianView.EventId),
            nameof(EventCivilianView.CivilianId)
        };
        public IEnumerable<SelectListItem> Events
           => events?.GetAll(x => x.ToString())?
           .Select(x => new SelectListItem(x.ToString(), x.Id))
           ?? new List<SelectListItem>();
        public IEnumerable<SelectListItem> Civilians
           => civilians?.GetAll(x => x.ToString())?
           .Select(x => new SelectListItem(x.ToString(), x.Id))
           ?? new List<SelectListItem>();
        public string EventName(string? eventId = null)
            => Events?.FirstOrDefault(x => x.Value == (eventId ?? string.Empty))?.Text ?? "Unspecified";
        public string CivilianName(string? civilianId = null)
            => Civilians?.FirstOrDefault(x => x.Value == (civilianId ?? string.Empty))?.Text ?? "Unspecified";
        public override object? GetValue(string name, EventCivilianView v)
        {
            var r = base.GetValue(name, v);
            return name == nameof(EventCivilianView.EventId) ? EventName(r as string)
                : name == nameof(EventCivilianView.CivilianId) ? CivilianName(r as string)
                : r;
        }
    }
}

