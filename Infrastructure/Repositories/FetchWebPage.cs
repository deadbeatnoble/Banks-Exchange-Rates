using BanksExchangeRates.Domain.Interfaces;

namespace BanksExchangeRates.Infrastructure.Repositories
{
    public class FetchWebPage : IFetchWebPage
    {
        public async Task<string> FecthWebPage(string url)
        {
            using (var _httpClient = new HttpClient())
            {
                HttpResponseMessage response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}
