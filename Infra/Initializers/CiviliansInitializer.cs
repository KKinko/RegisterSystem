using RegisterSystem.Data.Party;

namespace RegisterSystem.Infra.Initializers
{
    public sealed class CiviliansInitializer : BaseInitializer<CivilianData>
    {
        public CiviliansInitializer(RegisterDb? db) : base(db, db?.Civilians) { }
        protected override IEnumerable<CivilianData> getEntities => new[] {
            createCivlian("Joonas", "Kadak", "37605030299", PaymentMethod.Transfer, "ASASASAS"),
            createCivlian("Anna", "Kukk", "67605030212", PaymentMethod.Cash, "AAsass asa sasa"),
            createCivlian("Tom", "Karus", "57605030212", PaymentMethod.Cash, "adadsa ad asda"),
            createCivlian("Richard", "Ploom", "17605030212", PaymentMethod.Transfer, "adsada adaa dasda  asdadad aa da sd"),
        };
        internal static CivilianData createCivlian(string firstName, string lastName, string idCode, PaymentMethod payment, string information)
        {
            var address = new CivilianData
            {
                Id = idCode,
                FirstName = firstName,
                LastName = lastName,
                IdCode = idCode,
                Payment = payment,
                Information = information
            };
            return address;
        }
    }
}