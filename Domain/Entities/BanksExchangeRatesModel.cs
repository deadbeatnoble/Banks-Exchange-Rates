namespace BanksExchangeRates.Domain.Entities
{
    public class BanksExchangeRatesModel
    {
        public string BankName { get; set; }
        public List<CurrencyExchangeRate> CurrencyExchangeRates { get; set; }
    }
}
