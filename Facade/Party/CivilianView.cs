using RegisterSystem.Data.Party;
using RegisterSystem.Domain.Party;
using RegisterSystem.Facade.AbstractViews;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RegisterSystem.Facade.Party
{
    public sealed class CivilianView : PaymentView
    {
        [Required][DisplayName("Eesnimi")] public string? FirstName { get; set; }
        [Required][DisplayName("Perenimi")] public string? LastName { get; set; }
        [Required][DisplayName("Isikukood")] public string? IdCode { get; set; }
        [DisplayName("LisaInfo")] [StringLength(1500)]public new string? Information { get; set; }
        [DisplayName("Isik")] public string? FullName { get; set; }
    }
    
    public sealed class CivilianViewFactory : BaseViewFactory<CivilianView, Civilian, CivilianData>
    {
        protected override Civilian toEntity(CivilianData d) => new(d);
        public override Civilian Create(CivilianView? v)
        {
            v ??= new CivilianView();
            v.Payment ??= PaymentMethod.Cash;
            return base.Create(v);
        }
        public override CivilianView Create(Civilian? e)
        {
            var v = base.Create(e);
            v.FullName = e?.ToString();
            v.Payment = e?.Payment;
            return v;
        }
    }
    
}


