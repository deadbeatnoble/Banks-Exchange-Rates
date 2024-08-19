namespace BanksExchangeRates.Domain.Entities
{
    public class XPathModel
    {
        public string BankName { get; set; }
        public string ExchangeRateWebPageUrl { get; set; }
        public string? TableClassOrId { get; set; }
        public string? TableClassOrIdValue { get; set; }
        public int NumberOfTableRowsToSkipFromTop { get; set; }
        public int NumberOfTableRowsToSkipFromBottom { get; set; }
        public int CurrencyCodeCellNumber { get; set; }
        public string? CurrencyCodeXPath { get; set; }
        public int CurrencyNameCellNumber { get; set; }
        public string? CurrencyNameXPath { get; set; }
        public int CurrencyBuyingCellNumber { get; set; }
        public string? CurrencyBuyingXPath { get; set; }
        public int CurrencySellingCellNumber { get; set; }
        public string? CurrencySellingXPath { get; set; }
    }
}
