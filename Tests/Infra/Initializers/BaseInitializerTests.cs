using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegisterSystem.Data.Party;
using RegisterSystem.Domain.IRepos;
using RegisterSystem.Infra;
using RegisterSystem.Infra.Initializers;
using System.Collections.Generic;

namespace RegisterSystem.Tests.Infra.Initializers
{
    [TestClass]
    public class BaseInitializerTests
        : AbstractClassTests<BaseInitializer<CivilianData>, object>
    {
        private class testClass : BaseInitializer<CivilianData>
        {
            public testClass(DbContext? c, DbSet<CivilianData>? s) : base(c, s) { }
            protected override IEnumerable<CivilianData> getEntities => throw new System.NotImplementedException();
        }
        protected override BaseInitializer<CivilianData> createObj()
        {
            var db = GetRepo.Instance<RegisterDb>();
            var set = db?.Civilians;
            return new testClass(db, set);
        }
    }
}