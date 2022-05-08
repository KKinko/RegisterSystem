using Microsoft.EntityFrameworkCore;
using RegisterSystem.Data.Party;

namespace RegisterSystem.Infra
{
    public sealed class RegisterDb : DbContext
    {
        public RegisterDb(DbContextOptions<RegisterDb> options) : base(options) { }
        public DbSet<EventData>? Events { get; internal set; }
        public DbSet<CompanyData>? Companies { get; internal set; }
        public DbSet<CivilianData>? Civilians { get; internal set; }
        public DbSet<EventCivilianData>? EventsCivilians { get; internal set; }
        public DbSet<EventCompanyData>? EventsCompanies { get; internal set; }

        protected override void OnModelCreating(ModelBuilder b)
        {
            base.OnModelCreating(b);
            InitializeTables(b);
        }
        public static void InitializeTables(ModelBuilder b)
        {
            var s = nameof(RegisterDb)[0..^2];
            _ = (b?.Entity<EventData>()?.ToTable(nameof(Events), s));
            _ = (b?.Entity<CompanyData>()?.ToTable(nameof(Companies), s));
            _ = (b?.Entity<CivilianData>()?.ToTable(nameof(Civilians), s));
            _ = (b?.Entity<EventCivilianData>()?.ToTable(nameof(EventsCivilians), s));
            _ = (b?.Entity<EventCompanyData>()?.ToTable(nameof(EventsCompanies), s));
        }
    }
}
