using Microsoft.AspNetCore.Mvc.Rendering;
using RegisterSystem.Aids;
using RegisterSystem.Data.Party;
using RegisterSystem.Domain.Party;
using RegisterSystem.Facade.Party;
using RegisterSystem.Pages.AbstractPages;

namespace RegisterSystem.Pages.Party
{
    public class CompaniesPage : CrudPage<CompanyView, Company, ICompaniesRepo>
    {
        public CompaniesPage(ICompaniesRepo r) : base(r) { }
        protected override Company toObject(CompanyView? item) => new CompanyViewFactory().Create(item);
        protected override CompanyView toView(Company? entity) => new CompanyViewFactory().Create(entity);
        public override string[] IndexColumns { get; } = new[] {
            nameof(CompanyView.CompanyName),
            nameof(CompanyView.Participants),
            nameof(CompanyView.RegisterCode),
            nameof(CompanyView.Payment),
            nameof(CompanyView.Information),
            nameof(CivilianView.FullName)
        };
        public static IEnumerable<SelectListItem> Payments
        => Enum.GetValues<PaymentMethod>()?
           .Select(x => new SelectListItem(x.Description(), x.ToString()))
           ?? new List<SelectListItem>();
        public static string PaymentDescription(PaymentMethod? x)
            => (x ?? PaymentMethod.Cash).Description();
        public override object? GetValue(string name, CompanyView v)
        {
            var r = base.GetValue(name, v);
            return name == nameof(CompanyView.Payment) ? PaymentDescription((PaymentMethod?)r) : r;
        }
    }
}
