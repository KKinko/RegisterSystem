using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegisterSystem.Domain.IRepos;
using RegisterSystem.Domain.Party;
using RegisterSystem.Infra.Party;
using System;

namespace RegisterSystem.Tests.Domain.IRepos
{
    [TestClass]
    public class GetRepoTests : TypeTests
    {
        private class testClass : IServiceProvider
        {
            public object? GetService(Type serviceType)
            {
                throw new NotImplementedException();
            }
        }
        [TestMethod]
        public void InstanceTest()
            => Assert.IsInstanceOfType(GetRepo.Instance<IEventsRepo>(), typeof(EventsRepo));
        [TestMethod]
        public void SetServiceTest()
        {
            var s = GetRepo.service;
            var x = new testClass();
            GetRepo.SetService(x);
            areEqual(x, GetRepo.service);
            GetRepo.service = s;
        }
    }
}
