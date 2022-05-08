using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegisterSystem.Aids;
using RegisterSystem.Data.Party;
using RegisterSystem.Domain.IRepos;
using RegisterSystem.Domain.Party;
using RegisterSystem.Infra;
using RegisterSystem.Infra.AbstractRepos;
using System;
using System.Threading.Tasks;

namespace RegisterSystem.Tests.Infra.AbstractRepos
{
    [TestClass]
    public class CrudRepoTests
        : AbstractClassTests<CrudRepo<Company, CompanyData>, BaseRepo<Company, CompanyData>>
    {
        private RegisterDb? db;
        private DbSet<CompanyData>? set;
        private CompanyData? d;
        private Company? a;
        private int cnt;

        private class testClass : CrudRepo<Company, CompanyData>
        {
            public testClass(DbContext? c, DbSet<CompanyData>? s) : base(c, s) { }
            protected internal override Company toDomain(CompanyData d) => new(d);
        }
        protected override CrudRepo<Company, CompanyData> createObj()
        {
            db = GetRepo.Instance<RegisterDb>();
            set = db?.Companies;
            isNotNull(set);
            return new testClass(db, set);
        }
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            initSet();
            initAdr();
        }
        private void initSet()
        {
            cnt = GetRandom.Int32(5, 15);
            for (var i = 0; i < cnt; i++) set?.Add(GetRandom.Value<CompanyData>());
            _ = db?.SaveChanges();
        }
        private void initAdr()
        {
            d = GetRandom.Value<CompanyData>();
            isNotNull(d);
            a = new Company(d);
            var x = obj.Get(d.Id);
            isNotNull(x);
            areNotEqual(d.Id, x.Id);
        }
        [TestMethod]
        public async Task AddTest()
        {
            isNotNull(a);
            isNotNull(set);
            _ = obj?.Add(a);
            areEqual(cnt + 1, await set.CountAsync());
        }
        [TestMethod]
        public async Task AddAsyncTest()
        {
            isNotNull(a);
            isNotNull(set);
            _ = await obj.AddAsync(a);
            areEqual(cnt + 1, await set.CountAsync());
        }
        [TestMethod]
        public async Task DeleteTest()
        {
            isNotNull(d);
            await GetTest();
            _ = obj.Delete(d.Id);
            var x = obj.Get(d.Id);
            isNotNull(x);
            areNotEqual(d.Id, x.Id);
        }
        [TestMethod]
        public async Task DeleteAsyncTest()
        {
            isNotNull(d);
            await GetTest();
            _ = await obj.DeleteAsync(d.Id);
            var x = obj.Get(d.Id);
            isNotNull(x);
            areNotEqual(d.Id, x.Id);
        }
        [TestMethod]
        public async Task GetTest()
        {
            isNotNull(d);
            await AddTest();
            var x = obj.Get(d.Id);
            arePropertiesEqual(d, x.Data);
        }
        [DataRow(nameof(Company.Id))]
        [DataRow(nameof(Company.CompanyName))]
        [DataRow(nameof(Company.RegisterCode))]
        [DataRow(nameof(Company.Participants))]
        [DataRow(nameof(Company.Information))]
        [DataRow(nameof(Company.ToString))]
        [DataRow(null)]
        [TestMethod]
        public void GetAllTest(string s)
        {
            Func<Company, dynamic>? orderBy = null;
            if (s is nameof(Company.Id)) orderBy = x => x.Id;
            else if (s is nameof(Company.CompanyName)) orderBy = x => x.CompanyName;
            else if (s is nameof(Company.RegisterCode)) orderBy = x => x.RegisterCode;
            else if (s is nameof(Company.Participants)) orderBy = x => x.Participants;
            else if (s is nameof(Company.Information)) orderBy = x => x.Information;
            else if (s is nameof(Company.ToString)) orderBy = x => x.ToString();
            var l = obj.GetAll(orderBy);
            areEqual(cnt, l.Count);
            if (orderBy is null) return;
            for (var i = 0; i < l.Count - 1; i++)
            {
                var a = l[i];
                var b = l[i + 1];
                var aX = orderBy(a) as IComparable;
                var bX = orderBy(b) as IComparable;
                isNotNull(aX);
                isNotNull(bX);
                var r = aX.CompareTo(bX);
                isTrue(r <= 0);
            }
        }
        [TestMethod]
        public void GetListTest()
        {
            var l = obj.Get();
            areEqual(cnt, l.Count);
        }
        [TestMethod]
        public async Task GetAsyncTest()
        {
            isNotNull(d);
            await AddTest();
            var x = await obj.GetAsync(d.Id);
            arePropertiesEqual(d, x.Data);
        }
        [TestMethod]
        public async Task GetListAsyncTest()
        {
            var l = await obj.GetAsync();
            areEqual(cnt, l.Count);
        }
        [TestMethod]
        public async Task UpdateTest()
        {
            await GetTest();
            var dX = GetRandom.Value<CompanyData>() as CompanyData;
            isNotNull(d);
            isNotNull(dX);
            dX.Id = d.Id;
            var aX = new Company(dX);
            _ = obj.Update(aX);
            var x = obj.Get(d.Id);
            areEqualProperties(dX, x.Data);
        }
        [TestMethod]
        public async Task UpdateAsyncTest()
        {
            await GetTest();
            var dX = GetRandom.Value<CompanyData>() as CompanyData;
            isNotNull(d);
            isNotNull(dX);
            dX.Id = d.Id;
            var aX = new Company(dX);
            _ = await obj.UpdateAsync(aX);
            var x = obj.Get(d.Id);
            areEqualProperties(dX, x.Data);
        }
    }
}

