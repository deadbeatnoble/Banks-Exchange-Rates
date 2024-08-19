using BanksExchangeRates.Domain.Entities;
using HtmlAgilityPack;
using System.Reflection.Metadata;

namespace BanksExchangeRates.Domain.Interfaces
{
    public interface IExchangeRateScraper
    {
        BanksExchangeRatesModel scrapeExchangeRate(HtmlDocument html, XPathModel xPathModel);

    }
}