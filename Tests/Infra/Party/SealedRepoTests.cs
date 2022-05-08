using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegisterSystem.Aids;
using RegisterSystem.Data.AbstractData;
using RegisterSystem.Domain.AbstractEntities;
using RegisterSystem.Infra;
using RegisterSystem.Infra.AbstractRepos;
using System;

namespace RegisterSystem.Tests.Infra.Party
{
    public abstract class SealedRepoTests<TClass, TBaseClass, TDomain, TData>
        : SealedBaseTests<TClass, TBaseClass>
        where TClass : CrudRepo<TDomain, TData>
        where TBaseClass : class
        where TDomain : UniqueEntity<TData>, new()
        where TData : UniqueData, new()
    {
        private static Type registerType => typeof(RegisterDb);
        private static Type setType => typeof(DbSet<TData>);
        private RegisterDb registerDb
        {
            get
            {
                var o = obj.db;
                isNotNull(o);
                var db = o as RegisterDb;
                isNotNull(db);
                return db;
            }
        }
        protected void instanceTest(object? o, Type t)
        {
            isNotNull(o);
            isInstanceOfType(o, t);
        }
        protected void instanceTest(object? o, Type t, object? expected)
        {
            instanceTest(o, t);
            instanceTest(expected, t);
            areEqual(expected, o);
        }
        [TestMethod] public void DbContextTest() => instanceTest(obj.db, registerType);
        [TestMethod] public void DbSetTest() => instanceTest(obj.set, setType, getSet(registerDb));
        [TestMethod]
        public void ToDomainTest()
        {
            var d = GetRandom.Value<TData>();
            var o = obj.toDomain(d);
            isNotNull(o);
            isInstanceOfType(o, typeof(TDomain));
            areEqualProperties(d, o.Data);
        }
        protected abstract object? getSet(RegisterDb db);
    }
}
