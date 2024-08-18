using BanksExchangeRates.Domain.Entities;
using BanksExchangeRates.Domain.Interfaces;
using BanksExchangeRates.Util;
using HtmlAgilityPack;
using Microsoft.Extensions.Options;

namespace BanksExchangeRates.Infrastructure.Repositories
{
    public class DataServiceRepository : IDataService
    {
        private readonly List<XPathModel> _xPathModels;

        public DataServiceRepository(IOptions<List<XPathModel>> xPathModels) 
        {
            _xPathModels = xPathModels.Value;
        }

        public async Task<List<List<CurrencyExchangeRate>>> GetUpdatedDataAsync()
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

            foreach (var (xPathModel, index) in _xPathModels.Select((value, index) => (value, index)))
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

            return await Task.FromResult(BanksExchangeRates);
        }
    }
}
