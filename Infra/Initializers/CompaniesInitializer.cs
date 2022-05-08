using RegisterSystem.Data.Party;

namespace RegisterSystem.Infra.Initializers
{
    public sealed class CompaniesInitializer : BaseInitializer<CompanyData>
    {
        public CompaniesInitializer(RegisterDb? db) : base(db, db?.Companies) { }
        protected override IEnumerable<CompanyData> getEntities => new[] {
            createCompany("AS Puu", "70001123", 32, PaymentMethod.Transfer, "ASASASAS"),
            createCompany("Anna", "702301123", 12, PaymentMethod.Cash, "AAsass asa sasa"),
            createCompany("Tom", "70421123", 23, PaymentMethod.Cash, "adadsa ad asda"),
            createCompany("Richard", "70123123", 123, PaymentMethod.Transfer, "adsada adaa dasda  asdadad aa da sd"),
        };
        internal static CompanyData createCompany(string companyName, string registerCode, int participants, PaymentMethod payment, string information)
        {
            var address = new CompanyData
            {
                Id = registerCode,
                CompanyName = companyName,
                RegisterCode = registerCode,
                Participants = participants,
                Payment = payment,
                Information = information
            };
            return address;
        }
    }
}