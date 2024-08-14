using BanksExchangeRates.Domain.Entities;
using HtmlAgilityPack;
using System.Reflection.Metadata;

namespace BanksExchangeRates.Domain.Interfaces
{
    public interface IExchangeRateScraper
    {
        List<CurrencyExchangeRate> scrapeExchangeRate(HtmlDocument html, XPathModel xPathModel);

    }
}