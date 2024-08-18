using BanksExchangeRates.Domain.Entities;

namespace BanksExchangeRates.Domain.Interfaces
{
    public interface IDataService
    {
        Task<List<List<CurrencyExchangeRate>>> GetUpdatedDataAsync();
    }
}
