namespace RegisterSystem.Infra.Initializers {
    public static class RegisterDbInitializer {
        public static void Init(RegisterDb? db) {
            new EventsInitializer(db).Init();
            new CiviliansInitializer(db).Init();
            new CompaniesInitializer(db).Init();
        }
    }
}
