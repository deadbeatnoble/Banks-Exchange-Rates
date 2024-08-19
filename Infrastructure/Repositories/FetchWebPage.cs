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

            var _driver = new ChromeDriver(options);

            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromMinutes(5); // Adjust as needed
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            _driver.Navigate().GoToUrl(url);

            return _driver.PageSource;
        }
    }
}
