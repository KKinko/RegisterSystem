using RegisterSystem.Data.Party;
using RegisterSystem.Domain.Party;
using RegisterSystem.Facade.AbstractViews;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RegisterSystem.Facade.Party
{
    public sealed class CompanyView : PaymentView
    {
        [Required][DisplayName("Ettevõtte juriidiline nimi")] public string? CompanyName { get; set; }
        [Required][DisplayName("Ettevõtte registrikood")] public string? RegisterCode { get; set; }
        [Required][DisplayName("Ettevõttest tulevate osavõtjate arv")] public int? Participants { get; set; }
        [DisplayName("LisaInfo")][StringLength(5000)] public new string? Information { get; set; }
        [DisplayName("Ettevõte")] public string? FullName { get; set; }
    }

    public sealed class CompanyViewFactory : BaseViewFactory<CompanyView, Company, CompanyData>
    {
        protected override Company toEntity(CompanyData d) => new(d);

        public override Company Create(CompanyView? v)
        {
            v ??= new CompanyView();
            v.Payment ??= PaymentMethod.Cash;
            return base.Create(v);
        }
        public override CompanyView Create(Company? e)
        {
            var v = base.Create(e);
            v.FullName = e?.ToString();
            v.Payment = e?.Payment;
            return v;
        }
    }
}

