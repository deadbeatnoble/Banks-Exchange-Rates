using BanksExchangeRates.Domain.Interfaces;

namespace BanksExchangeRates.Infrastructure.Repositories
{
    public class FetchWebPage : IFetchWebPage
    {
        public async Task<string> FecthWebPage(string url)
        {
            using (var _httpClient = new HttpClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                request.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("text/html"));

                HttpResponseMessage response = await _httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}
