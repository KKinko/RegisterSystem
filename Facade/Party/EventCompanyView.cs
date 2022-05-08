using RegisterSystem.Data.Party;
using RegisterSystem.Domain.Party;
using RegisterSystem.Facade.AbstractViews;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RegisterSystem.Facade.Party
{
    public sealed class EventCompanyView : UniqueView
    {
        [Required][DisplayName("Üritus")] public string EventId { get; set; } = string.Empty;
        [Required][DisplayName("Äriklient")] public string CompanyId { get; set; } = string.Empty;
    }
    public sealed class EventCompanyViewFactory :
        BaseViewFactory<EventCompanyView, EventCompany, EventCompanyData>
    {
        protected override EventCompany toEntity(EventCompanyData d) => new(d);
    }

}


