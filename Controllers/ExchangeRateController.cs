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
        private readonly IOptions<List<XPathModel>> _options;
        public ExchangeRateController(IOptions<List<XPathModel>> options)
        {
            _options = options;
        }
        public async Task<IActionResult> Index()
        {
            var samplePages = new List<string> {
                new SamplePage().CBE_EXCHANGE_RATE_PAGE,
                new SamplePage().OROMIA_EXCHANGE_RATE_PAGE,
                new SamplePage().BUNA_EXCHANGE_RATE_PAGE,
                new SamplePage().DASHEN_EXCHANGE_RATE_PAGE,
                new SamplePage().ZEMEN_EXCHANGE_RATE_PAGE,
                new SamplePage().AMHARA_EXCHANGE_RATE_PAGE,
                new SamplePage().COOP_EXCHANGE_RATE_PAGE,
                new SamplePage().NIB_EXCHANGE_RATE_PAGE,
                new SamplePage().ADDIS_EXCHANGE_RATE_PAGE,
                new SamplePage().GLOBAL_EXCHANGE_RATE_PAGE,
                new SamplePage().AWASH_EXCHANGE_RATE_PAGE,
                new SamplePage().HIBRET_EXCHANGE_RATE_PAGE,
                new SamplePage().TSEHAY_EXCHANGE_RATE_PAGE
                };
            var BanksExchangeRates = new List<List<CurrencyExchangeRate>>();
            foreach (var (xPathModel, index) in _options.Value.Select((value, index) => (value, index)))
            {
                /*ChromeOptions options = new ChromeOptions();
                options.AddArgument("--headless");

                var web = new ChromeDriver(options);
                web.Navigate().GoToUrl(xPathModel.ExchangeRateWebPageUrl);
                var document = web.PageSource;*/


                var exchangeRateScraperRepository = new ExchangeRateScraperRepository();
                var x = new HtmlDocument();
                x.LoadHtml(samplePages[index]);
                var currencyExchangeRates = exchangeRateScraperRepository.scrapeExchangeRate(x, xPathModel);
                BanksExchangeRates.Add(currencyExchangeRates);
            }
            

            var exchangeRateViewModel = new ExchangeRateViewModel {
                BanksExchangeRates = BanksExchangeRates
            };

            return View("Index", exchangeRateViewModel);
        }
    }
}
