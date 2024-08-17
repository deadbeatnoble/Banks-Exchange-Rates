using BanksExchangeRates.Models;

namespace BanksExchangeRates.Domain.Interfaces
{
    public interface IMyHubClient
    {
        Task SendUpdatedData(ExchangeRateViewModel data);
    }
}
