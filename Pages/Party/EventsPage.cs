using Microsoft.AspNetCore.Mvc;
using RegisterSystem.Domain.Party;
using RegisterSystem.Facade.Party;
using RegisterSystem.Pages.AbstractPages;

namespace RegisterSystem.Pages.Party
{
    public class EventsPage : CrudPage<EventView, Event, IEventsRepo>
    {
        public List<EventView> FutureEvents { get; set; }
        public List<EventView> PastEvents { get; set; }
        public EventsPage(IEventsRepo r) : base(r) {
            FutureEvents = new List<EventView>();
            PastEvents = new List<EventView>(); 
        }
        protected override Event toObject(EventView? item) => new EventViewFactory().Create(item);
        protected override EventView toView(Event? entity) => new EventViewFactory().Create(entity);
        public override string[] IndexColumns { get; } = new[] {
            nameof(EventView.EventName),
            nameof(EventView.Time),
            nameof(EventView.Place),
            nameof(EventView.Information)
        };
        public Lazy<List<Civilian?>> Civilians => toObject(Item).Civilians;
        public Lazy<List<Company?>> Companies => toObject(Item).Companies;

        protected override async Task<IActionResult> getIndexAsync()
        {
            var pastList = repo.GetPast();
            var futureList = repo.GetFuture();
            foreach (var obj in pastList)
            {
                var v = toView(obj);
                PastEvents.Add(v);
            }
            foreach (var obj in futureList)
            {
                var v = toView(obj);
                FutureEvents.Add(v);
            }
            return Page();
        }
       
    }
}
