using BanksExchangeRates.Domain.Interfaces;
using BanksExchangeRates.Models;
using Microsoft.AspNetCore.SignalR;

namespace BanksExchangeRates.Domain
{
    public sealed class MyHub : Hub
    {
        public async Task SendUpdatedData(string data) 
        {
            await Clients.All.SendAsync("ReceiveUpdatedData", data);
        }
    }
}
