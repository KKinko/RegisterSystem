using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegisterSystem.Aids;
using RegisterSystem.Data.Party;
using System;
using System.Collections.Generic;

namespace RegisterSystem.Tests.Aids
{
    [TestClass]
    public class GetRandomTests : TypeTests
    {

        private void test<T>(T min, T max) where T : IComparable<T>
        {
            var x = GetRandom.Value(min, max);
            var y = GetRandom.Value(min, max);
            var i = 0;
            while (x == y)
            {
                y = GetRandom.Value(min, max);
                if (i == 2) areNotEqual(x, y);
                i++;
            }
            isInstanceOfType(x, typeof(T));
            isInstanceOfType(y, typeof(T));
            isTrue(x >= (min.CompareTo(max) < 0 ? min : max));
            isTrue(y >= (min.CompareTo(max) < 0 ? min : max));
            isTrue(x <= (min.CompareTo(max) < 0 ? max : min));
            isTrue(y <= (min.CompareTo(max) < 0 ? max : min));
            areNotEqual(x, y);
        }

        [DataRow(-1000, 1000)]
        [DataRow(-1000, 0)]
        [DataRow(0, 1000)]
        [DataRow(int.MaxValue - 100, int.MaxValue)]
        [DataRow(int.MinValue, int.MinValue + 100)]
        [DataRow(1000, -1000)]
        [TestMethod] public void Int32Test(int min, int max) => test(min, max);

        [DataRow(-1000L, 1000L)]
        [DataRow(-1000L, 0L)]
        [DataRow(0L, 1000L)]
        [DataRow(long.MaxValue - 1000L, long.MaxValue)]
        [DataRow(long.MinValue, long.MinValue + 1000L)]
        [DataRow(1000L, -1000L)]
        [TestMethod] public void Int64Test(long min, long max) => test(min, max);

        [DataRow(-1000.0, 1000.0)]
        [DataRow(-1000.0, 0.0)]
        [DataRow(0.0, 1000.0)]
        [DataRow(double.MaxValue - 1.0E+308, double.MaxValue)]
        [DataRow(double.MinValue, double.MinValue + 1.0E+308)]
        [DataRow(1000.0, -1000.0)]
        [TestMethod] public void DoubleTest(double min, double max) => test(min, max);

        [DataRow(char.MinValue, char.MaxValue)]
        [DataRow('a', 'z')]
        [DataRow('1', 'P')]
        [DataRow('A', 'z')]
        [TestMethod] public void CharTest(char min, char max) => test(min, max);
        [TestMethod] public void BoolTest() => test(() => GetRandom.Bool());

        [DynamicData(nameof(DateTimeValues), DynamicDataSourceType.Property)]
        [TestMethod] public void DateTimeTest(DateTime min, DateTime max) => test(min, max);
        private static IEnumerable<object[]> DateTimeValues => new List<object[]>()
            {
                 new object[]{ DateTime.Now.AddYears(-100), DateTime.Now.AddYears(100) },
                 new object[]{ DateTime.Now.AddYears(100), DateTime.Now.AddYears(-100) },
                 new object[]{ DateTime.MaxValue.AddYears(-100), DateTime.MaxValue },
                 new object[]{ DateTime.MinValue, DateTime.MinValue.AddYears(100) }
            };
        [TestMethod]
        public void StringTest()
        {
            var x = GetRandom.Value<string>();
            var y = GetRandom.Value<string>();
            isInstanceOfType(x, typeof(string));
            isInstanceOfType(y, typeof(string));
            areNotEqual(x, y);
        }
        [TestMethod]
        public void ValueTest()
        {
            var x = GetRandom.Value<CivilianData>() as CivilianData;
            var y = GetRandom.Value<CivilianData>() as CivilianData;
            isNotNull(x);
            isNotNull(y);
            areNotEqual(x.Id, y.Id, nameof(x.Id));
            areNotEqual(x.FirstName, y.FirstName, nameof(x.FirstName));
            areNotEqual(x.LastName, y.LastName, nameof(x.LastName));
            areNotEqual(x.IdCode, y.IdCode, nameof(x.IdCode));
        }
        [TestMethod] public void EnumOfGenericTest() => test(() => GetRandom.EnumOf<PaymentMethod>());
        [DataRow(typeof(PaymentMethod))]
        [TestMethod] public void EnumOfTest(Type t) => test(() => GetRandom.EnumOf(t));
        private void test<T>(Func<T> f, int count = 5)
        {
            var x = f();
            var y = f();
            var i = 0;
            while (x.Equals(y))
            {
                y = f();
                if (i == count) areNotEqual(x, y);
                i++;
            }
        }
        [DataRow(typeof(bool?), false)]
        [DataRow(typeof(int), false)]
        [DataRow(typeof(decimal?), false)]
        [DataRow(typeof(string), false)]
        [DataRow(typeof(PaymentMethod?), false)]
        [DataRow(typeof(PaymentMethod), true)]
        [DataRow(typeof(DateTime), false)]
        [TestMethod]
        public void IsEnumTest(Type t, bool expected)
            => areEqual(expected, GetRandom.isEnum(t));

        [DataRow(typeof(bool?), typeof(bool))]
        [DataRow(typeof(int?), typeof(int))]
        [DataRow(typeof(decimal?), typeof(decimal))]
        [DataRow(typeof(string), typeof(string))]
        [DataRow(typeof(PaymentMethod?), typeof(PaymentMethod))]
        [DataRow(typeof(DateTime?), typeof(DateTime))]
        [TestMethod]
        public void GetUnderlyingTypeTest(Type nullable, Type expected)
            => areEqual(expected, GetRandom.getUnderlyingType(nullable));
    }
}
