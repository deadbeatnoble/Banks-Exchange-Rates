using BanksExchangeRates.Domain.Interfaces;
using BanksExchangeRates.Util;
using Microsoft.AspNetCore.SignalR;
using System.Text.Json;

namespace BanksExchangeRates.Infrastructure.Repositories
{
    public class DataUpdateService : BackgroundService
    {
        private readonly IHubContext<MyHub> _hubContext;
        private readonly IServiceProvider _serviceProvider;

        public DataUpdateService(IHubContext<MyHub> hubContext, IServiceProvider serviceProvider)
        {
            _hubContext = hubContext;
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested) 
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var dataService = scope.ServiceProvider.GetService<IDataService>();
                    var data = await dataService.GetUpdatedDataAsync();
                    await _hubContext.Clients.All.SendAsync("ReceiveUpdatedData", JsonSerializer.Serialize(data));
                }
                await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);
            }
        }
    }
}
