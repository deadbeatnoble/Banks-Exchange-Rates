namespace BanksExchangeRates.Domain.Entities
{
    public class XPathModel
    {
        public string BankName { get; set; }
        public string ExchangeRateWebPageUrl { get; set; }
        public string TableClassOrId { get; set; }
        public string TableClassOrIdValue { get; set; }
        public string NumberOfTableRowsToSkipFromTop { get; set; }
        public string NumberOfTableRowsToSkipFromBottom { get; set; }
        public string CurrencyCodeCellNumber { get; set; }
        public string CurrencyCodeXPath { get; set; }
        public string CurrencyNameCellNumber { get; set; }
        public string CurrencyNameXPath { get; set; }
        public string CurrencyBuyingCellNumber { get; set; }
        public string CurrencyBuyingXPath { get; set; }
        public string CurrencySellingCellNumber { get; set; }
        public string CurrencySellingXPath { get; set; }
    }
}
