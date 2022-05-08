using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegisterSystem.Aids;
using RegisterSystem.Data.AbstractData;
using RegisterSystem.Domain.AbstractEntities;
using RegisterSystem.Domain.IRepos;
using RegisterSystem.Domain.Party;
using RegisterSystem.Infra.Party;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace RegisterSystem.Tests
{
    public abstract class HostTests : TestAsserts
    {
        internal static readonly TestHost<Program> host;
        internal static readonly HttpClient client;
        [TestInitialize]
        public virtual void TestInitialize()
        {
            (GetRepo.Instance<IEventsRepo>() as EventsRepo)?.clear();
            (GetRepo.Instance<ICompaniesRepo>() as CompaniesRepo)?.clear();
            (GetRepo.Instance<IEventsCompaniesRepo>() as EventsCompaniesRepo)?.clear();
            (GetRepo.Instance<ICiviliansRepo>() as CiviliansRepo)?.clear();
            (GetRepo.Instance<IEventsCiviliansRepo>() as EventsCiviliansRepo)?.clear();
        }
        static HostTests()
        {
            host = new TestHost<Program>();
            client = host.CreateClient();
        }
        protected virtual object? isReadOnly<T>(string? callingMethod = null) => null;
        protected virtual void arePropertiesEqual(object? x, object? y, params string[] excluded) { isInconclusive(); }
        protected void itemTest<TRepo, TObj, TData>(string id, Func<TData, TObj> toObj, Func<TObj?> getObj)
            where TRepo : class, IRepo<TObj> where TObj : UniqueEntity
        {
            var c = isReadOnly<TObj>(nameof(itemTest));
            isNotNull(c);
            isInstanceOfType(c, typeof(TObj));
            var r = GetRepo.Instance<TRepo>();
            var d = addRandomItems(out int cnt, toObj, id, r);

            areEqual(cnt, r.Get().Count);
        }

        internal static TData? addRandomItems<TRepo, TObj, TData>(out int cnt, Func<TData, TObj> toObj, string? id = null, TRepo? r = null)
            where TRepo : class, IRepo<TObj>
            where TObj : UniqueEntity
        {
            r ??= GetRepo.Instance<TRepo>();
            var d = GetRandom.Value<TData>();
            if (id is not null && d is not null) d.Id = id;
            cnt = GetRandom.Int32(5, 30);
            var idx = GetRandom.Int32(0, cnt);
            for (var i = 0; i < cnt; i++)
            {
                var x = i == idx ? d : GetRandom.Value<TData>();
                isNotNull(x);
                r?.Add(toObj(x));
            }
            return d;
        }

        protected void itemsTest<TRepo, TObj, TData>(Action<TData> setId, Func<TData, TObj> toObj, Func<List<TObj>> getList)
            where TRepo : class, IRepo<TObj> where TObj : UniqueEntity<TData> where TData : UniqueData, new()
        {
            var o = isReadOnly<List<TObj>>(nameof(itemsTest));

            isNotNull(o);
            if (o.GetType().Name.Contains("Lazy")) isInstanceOfType(o, typeof(Lazy<List<TObj>>));
            else isInstanceOfType(o, typeof(List<TObj>));

            var r = GetRepo.Instance<TRepo>();
            isNotNull(r);

            var list = new List<TData>();
            var cnt = GetRandom.Int32(5, 30);
            for (var i = 0; i < cnt; i++)
            {
                var x = GetRandom.Value<TData>();
                if (GetRandom.Bool())
                {
                    setId(x);
                    list.Add(x);
                }
                r.Add(toObj(x));
            }
            areEqual(cnt, r.Get().Count);

            var l = getList();
            areEqual(list.Count, l.Count);
            foreach (var d in list)
            {
                var y = l.Find(z => z.Id == d.Id);
                isNotNull(y);
                areEqualProperties(d, y);
            }
        }

        protected void relatedItemsTest<TRepo, TRelatedItem, TItem, TData>
            (Action relatedTest,
            Func<List<TRelatedItem>> relatedItems,
            Func<List<TItem?>> items,
            Func<TRelatedItem, string> detailId,
            Func<TData, TItem> toObj,
            Func<TItem?, TData?> toData,
            Func<TRelatedItem?, TData?> relatedToData)
           where TRepo : class, IRepo<TItem>
           where TItem : UniqueEntity
           where TRelatedItem : UniqueEntity
        {
            relatedTest();
            var l = relatedItems();
            var r = GetRepo.Instance<TRepo>();
            foreach (var e in l)
            {
                var x = GetRandom.Value<TData>();
                if (x is not null) x.Id = detailId(e);
                r?.Add(toObj(x));
            }
            var c = items();
            areEqual(l.Count, c.Count);
            foreach (var e in l)
            {
                var a = c.Find(x => x?.Id == detailId(e));
                arePropertiesEqual(toData(a), relatedToData(e));
            }
        }
    }
}
