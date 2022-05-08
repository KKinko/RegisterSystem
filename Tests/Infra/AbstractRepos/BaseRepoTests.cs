using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegisterSystem.Aids;
using RegisterSystem.Data.Party;
using RegisterSystem.Domain.IRepos;
using RegisterSystem.Domain.Party;
using RegisterSystem.Infra;
using RegisterSystem.Infra.AbstractRepos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RegisterSystem.Tests.Infra.AbstractRepos
{
    [TestClass]
    public class BaseRepoTests
        : AbstractClassTests<BaseRepo<Event, EventData>, object>
    {
        private class testClass : BaseRepo<Event, EventData>
        {
            public testClass(DbContext? c, DbSet<EventData>? s) : base(c, s) { }
            public override bool Add(Event obj) => throw new NotImplementedException();
            public override Task<bool> AddAsync(Event obj) => throw new NotImplementedException();
            public override bool Delete(string id) => throw new NotImplementedException();
            public override Task<bool> DeleteAsync(string id) => throw new NotImplementedException();
            public override List<Event> Get() => throw new NotImplementedException();
            public override Event Get(string id) => throw new NotImplementedException();
            public override List<Event> GetAll(Func<Event, dynamic>? orderBy = null)
                => throw new NotImplementedException();
            public override Task<List<Event>> GetAsync() => throw new NotImplementedException();
            public override Task<Event> GetAsync(string id) => throw new NotImplementedException();
            public override bool Update(Event obj) => throw new NotImplementedException();
            public override Task<bool> UpdateAsync(Event obj) => throw new NotImplementedException();
        }
        protected override BaseRepo<Event, EventData> createObj() => new testClass(null, null);
        [TestMethod] public void dbTest() => isReadOnly<DbContext?>();
        [TestMethod] public void setTest() => isReadOnly<DbSet<EventData>?>();
        [TestMethod]
        public void BaseRepoTest()
        {
            var db = GetRepo.Instance<RegisterDb>();
            var set = db?.Events;
            isNotNull(set);
            obj = new testClass(db, set);
            areEqual(db, obj.db);
            areEqual(set, obj.set);
        }
        [TestMethod]
        public async Task ClearTest()
        {
            BaseRepoTest();
            var cnt = GetRandom.Int32(5, 30);
            var db = obj.db;
            isNotNull(db);
            var set = obj.set;
            isNotNull(set);
            for (var i = 0; i < cnt; i++) set.Add(GetRandom.Value<EventData>());
            areEqual(0, await set.CountAsync());
            db.SaveChanges();
            areEqual(cnt, await set.CountAsync());
            obj.clear();
            areEqual(0, await set.CountAsync());
        }
        [TestMethod] public void AddTest() => isAbstractMethod(nameof(obj.Add), typeof(Event));
        [TestMethod] public void AddAsyncTest() => isAbstractMethod(nameof(obj.AddAsync), typeof(Event));
        [TestMethod] public void DeleteTest() => isAbstractMethod(nameof(obj.Delete), typeof(string));
        [TestMethod] public void DeleteAsyncTest() => isAbstractMethod(nameof(obj.DeleteAsync), typeof(string));
        [TestMethod] public void GetTest() => isAbstractMethod(nameof(obj.Get), typeof(string));
        [TestMethod] public void GetAllTest() => isAbstractMethod(nameof(obj.GetAll), typeof(Func<Event, dynamic>));
        [TestMethod] public void GetListTest() => isAbstractMethod(nameof(obj.Get));
        [TestMethod] public void GetAsyncTest() => isAbstractMethod(nameof(obj.GetAsync), typeof(string));
        [TestMethod] public void GetListAsyncTest() => isAbstractMethod(nameof(obj.GetAsync));
        [TestMethod] public void UpdateTest() => isAbstractMethod(nameof(obj.Update), typeof(Event));
        [TestMethod] public void UpdateAsyncTest() => isAbstractMethod(nameof(obj.UpdateAsync), typeof(Event));
    }
}

