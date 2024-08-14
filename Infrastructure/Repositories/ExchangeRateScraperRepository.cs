using BanksExchangeRates.Domain.Entities;
using BanksExchangeRates.Domain.Interfaces;
using HtmlAgilityPack;
using System.Reflection.Metadata;

namespace BanksExchangeRates.Infrastructure.Repositories
{
    public class ExchangeRateScraperRepository : IExchangeRateScraper
    {
        public List<CurrencyExchangeRate> scrapeExchangeRate(HtmlDocument htmlDocument, XPathModel xPathModel) {
            var currencyExchangeRates = new List<CurrencyExchangeRate>();

            var table = htmlDocument.DocumentNode.Descendants("table")
                .Where(tb => xPathModel.TableClassOrIdValue == "" ? true : tb.Attributes[xPathModel.TableClassOrId].Value == xPathModel.TableClassOrIdValue)
                .FirstOrDefault();

            if (table != null) {
                foreach (var row in table.SelectNodes(".//tr").Skip(int.Parse(xPathModel.NumberOfTableRowsToSkip)))
                {
                    var cells = row.SelectNodes(".//td");

                    currencyExchangeRates.Add(
                        new CurrencyExchangeRate {
                            CurrencyCode = cells[int.Parse(xPathModel.CurrencyCodeCellNumber)].InnerText.Trim(),
                            CurrencyName = cells[int.Parse(xPathModel.CurrencyNameCellNumber)].InnerText.Trim(),
                            CurrencyBuying = decimal.Parse(cells[int.Parse(xPathModel.CurrencyBuyingCellNumber)].InnerText.Trim()),
                            CurrencySelling = decimal.Parse(cells[int.Parse(xPathModel.CurrencySellingCellNumber)].InnerText.Trim())
                        });
                }
            }

            return currencyExchangeRates;
        }
    }
}
