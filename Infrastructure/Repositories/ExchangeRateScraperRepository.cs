using BanksExchangeRates.Domain.Entities;
using BanksExchangeRates.Domain.Interfaces;
using HtmlAgilityPack;
using System.Reflection.Metadata;

namespace BanksExchangeRates.Infrastructure.Repositories
{
    public class ExchangeRateScraperRepository : IExchangeRateScraper
    {
        public BanksExchangeRatesModel scrapeExchangeRate(HtmlDocument htmlDocument, XPathModel xPathModel) {

            var currencyExchangeRates = new List<CurrencyExchangeRate>();

            var table = htmlDocument.DocumentNode.Descendants("table")
                .FirstOrDefault(tb => string.IsNullOrEmpty(xPathModel.TableClassOrIdValue) || (tb.Attributes[xPathModel.TableClassOrId] != null && tb.Attributes[xPathModel.TableClassOrId].Value == xPathModel.TableClassOrIdValue));


            if (table != null) {
                foreach (var row in table.SelectNodes(".//tr").Skip(xPathModel.NumberOfTableRowsToSkipFromTop).Take(table.SelectNodes(".//tr").Count - (xPathModel.NumberOfTableRowsToSkipFromTop + xPathModel.NumberOfTableRowsToSkipFromBottom)))
                {
                    var cells = row.SelectNodes(".//td");

                    currencyExchangeRates.Add(
                        new CurrencyExchangeRate {
                            CurrencyCode = string.IsNullOrEmpty(xPathModel.CurrencyCodeXPath) ? cells[xPathModel.CurrencyCodeCellNumber].InnerText.Trim() : cells[xPathModel.CurrencyCodeCellNumber].SelectSingleNode(xPathModel.CurrencyCodeXPath).InnerText.Trim(),
                            CurrencyName = string.IsNullOrEmpty(xPathModel.CurrencyNameXPath) ? cells[xPathModel.CurrencyNameCellNumber].InnerText.Trim() : cells[xPathModel.CurrencyNameCellNumber].SelectSingleNode(xPathModel.CurrencyNameXPath).InnerText.Trim(),
                            CurrencyBuying = decimal.Parse(string.IsNullOrEmpty(xPathModel.CurrencyBuyingXPath) ? cells[xPathModel.CurrencyBuyingCellNumber].InnerText.Trim() : cells[xPathModel.CurrencyBuyingCellNumber].SelectSingleNode(xPathModel.CurrencyBuyingXPath).InnerText.Trim()),
                            CurrencySelling = decimal.Parse(string.IsNullOrEmpty(xPathModel.CurrencySellingXPath) ? cells[xPathModel.CurrencySellingCellNumber].InnerText.Trim() : cells[xPathModel.CurrencySellingCellNumber].SelectSingleNode(xPathModel.CurrencySellingXPath).InnerText.Trim())
                        });
                }
            }

            var banksExchangeRatesModel = new BanksExchangeRatesModel {
                BankName = xPathModel.BankName,
                CurrencyExchangeRates = currencyExchangeRates
            };

            return banksExchangeRatesModel;
        }
    }
}
