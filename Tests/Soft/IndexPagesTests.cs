using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegisterSystem.Data.Party;
using RegisterSystem.Domain.Party;
using System.Net;
using System.Threading.Tasks;

namespace RegisterSystem.Tests.Soft;


[TestClass] public class IndexPagesTests : HostTests
{

    [TestMethod]
    public async Task GetEventsIndexPageTest()
    {
        int cnt;
        var d = addRandomItems<IEventsRepo, Event, EventData>(out cnt, x => new Event(x));
        var page = await client.GetAsync("/Events?handler=Index");
        areEqual(HttpStatusCode.OK, page.StatusCode);
        var html = await page.Content.ReadAsStringAsync();
        isTrue(html.Contains("<h3>Avaleht</h3>"));
    }
}
