using BanksExchangeRates.Domain.Entities;

namespace BanksExchangeRates.Models
{
    public class ExchangeRateViewModel
    {
        public List<List<CurrencyExchangeRate>> BanksExchangeRates = new List<List<CurrencyExchangeRate>>();
    }
}
