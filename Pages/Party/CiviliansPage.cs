using Microsoft.AspNetCore.Mvc.Rendering;
using RegisterSystem.Aids;
using RegisterSystem.Data.Party;
using RegisterSystem.Domain.Party;
using RegisterSystem.Facade.Party;
using RegisterSystem.Pages.AbstractPages;

namespace RegisterSystem.Pages.Party
{
    public class CiviliansPage : CrudPage<CivilianView, Civilian, ICiviliansRepo>
    {
        public CiviliansPage(ICiviliansRepo r) : base(r) { }
        protected override Civilian toObject(CivilianView? item) => new CivilianViewFactory().Create(item);
        protected override CivilianView toView(Civilian? entity) => new CivilianViewFactory().Create(entity);
        public override string[] IndexColumns { get; } = new[] {
            nameof(CivilianView.FirstName),
            nameof(CivilianView.LastName),
            nameof(CivilianView.IdCode),
            nameof(CivilianView.Payment),
            nameof(CivilianView.Information),
            nameof(CivilianView.FullName)
        };
        public IEnumerable<SelectListItem> Payments
        => Enum.GetValues<PaymentMethod>()?
           .Select(x => new SelectListItem(x.Description(), x.ToString()))
           ?? new List<SelectListItem>();
        public string PaymentDescription(PaymentMethod? x)
            => (x ?? PaymentMethod.Cash).Description();
        public override object? GetValue(string name, CivilianView v)
        {
            var r = base.GetValue(name, v);
            return name == nameof(CivilianView.Payment) ? PaymentDescription((PaymentMethod?)r) : r;
        }

    }
}
