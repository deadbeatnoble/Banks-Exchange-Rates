using BanksExchangeRates.Domain.Interfaces;
using OpenQA.Selenium.Chrome;

namespace BanksExchangeRates.Infrastructure.Repositories
{
    public class FetchWebPage : IFetchWebPage
    {
        public async Task<string> FecthWebPage(string url)
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--headless");

            var web = new ChromeDriver(options);
            web.Navigate().GoToUrl(url);

            return web.PageSource;
        }
    }
}
