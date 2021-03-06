using Microsoft.EntityFrameworkCore;
using RegisterSystem.Data.AbstractData;

namespace RegisterSystem.Infra.Initializers {
    public abstract class BaseInitializer<TData> where TData : UniqueData {
        internal protected DbContext? db;
        internal protected DbSet<TData>? set;
        protected BaseInitializer(DbContext? c, DbSet<TData>? s) {
            db = c;
            set = s;
        }
        public void Init() {
            if (set?.Any() ?? true) return;
            set.AddRange(getEntities);
            _ = (db?.SaveChanges());
        }
        protected abstract IEnumerable<TData> getEntities { get; }
        internal static bool isCorrectIsoCode(string id) => !string.IsNullOrWhiteSpace(id) && char.IsLetter(id[0]);
    }
}
