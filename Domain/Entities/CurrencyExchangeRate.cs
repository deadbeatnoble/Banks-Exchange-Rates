namespace BanksExchangeRates.Domain.Entities
{
    public class CurrencyExchangeRate
    {
        public string CurrencyCode { get; set; }
        public string CurrencyName { get; set; }
        public decimal CurrencyBuying { get; set; }
        public decimal CurrencySelling { get; set; }
    }
}
