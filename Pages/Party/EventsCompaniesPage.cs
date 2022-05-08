using Microsoft.AspNetCore.Mvc.Rendering;
using RegisterSystem.Domain.Party;
using RegisterSystem.Facade.Party;
using RegisterSystem.Pages.AbstractPages;

namespace RegisterSystem.Pages.Party
{
    public class EventsCompaniesPage : CrudPage<EventCompanyView, EventCompany, IEventsCompaniesRepo>
    {
        private readonly IEventsRepo events;
        private readonly ICompaniesRepo companies;
        public EventsCompaniesPage(IEventsCompaniesRepo r, IEventsRepo ev, ICompaniesRepo co ) : base(r) 
        {
            events = ev;
            companies = co;
        }
        protected override EventCompany toObject(EventCompanyView? item) => new EventCompanyViewFactory().Create(item);
        protected override EventCompanyView toView(EventCompany? entity) => new EventCompanyViewFactory().Create(entity);
        public override string[] IndexColumns { get; } = new[] {
            nameof(EventCompanyView.EventId),
            nameof(EventCompanyView.CompanyId)
        };
        public IEnumerable<SelectListItem> Events
           => events?.GetAll(x => x.ToString())?
           .Select(x => new SelectListItem(x.ToString(), x.Id))
           ?? new List<SelectListItem>();
        public IEnumerable<SelectListItem> Companies
           => companies?.GetAll(x => x.ToString())?
           .Select(x => new SelectListItem(x.ToString(), x.Id))
           ?? new List<SelectListItem>();
        public string EventName(string? eventId = null)
            => Events?.FirstOrDefault(x => x.Value == (eventId ?? string.Empty))?.Text ?? "Unspecified";
        public string CompanyName(string? companyId = null)
            => Companies?.FirstOrDefault(x => x.Value == (companyId ?? string.Empty))?.Text ?? "Unspecified";
        public override object? GetValue(string name, EventCompanyView v)
        {
            var r = base.GetValue(name, v);
            return name == nameof(EventCompanyView.EventId) ? EventName(r as string)
                : name == nameof(EventCompanyView.CompanyId) ? CompanyName(r as string)
                : r;
        }
    }
}

