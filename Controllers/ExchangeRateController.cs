using BanksExchangeRates.Domain.Entities;
using BanksExchangeRates.Infrastructure.Repositories;
using BanksExchangeRates.Models;
using BanksExchangeRates.Util;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using OpenQA.Selenium.Chrome;

namespace BanksExchangeRates.Controllers
{
    public class ExchangeRateController : Controller
    {
        private readonly IOptions<XPathModel> _options;
        public ExchangeRateController(IOptions<XPathModel> options)
        {
            _options = options;
        }
        public async Task<IActionResult> Index()
        {
            /*var web = new ChromeDriver(new ChromeOptions());
            web.Navigate().GoToUrl("https://www.combanketh.et/en/exchange-rate/");
            var document = web.PageSource;*/

            var exchangeRateScraperRepository = new ExchangeRateScraperRepository();
            var x = new HtmlDocument();
            x.LoadHtml(new SamplePage().CBE_EXCHANGE_RATE_PAGE);
            var currencyExchangeRates = exchangeRateScraperRepository.scrapeExchangeRate(x, _options.Value);

            var exchangeRateViewModel = new ExchangeRateViewModel { 
                CurrencyExchangeRates = currencyExchangeRates
            };

            return View("Index", exchangeRateViewModel);
        }
    }
}
