using BanksExchangeRates.Domain.Entities;
using BanksExchangeRates.Models;
using BanksExchangeRates.Util;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Options;
using OpenQA.Selenium.Chrome;
using System.Text.Json;

namespace BanksExchangeRates.Controllers
{
    public class ExchangeRateController : Controller
    {
        private readonly IOptions<List<XPathModel>> _options;
        private readonly IHubContext<MyHub> _hubContext;
        public ExchangeRateController(IOptions<List<XPathModel>> options, IHubContext<MyHub> hubContext)
        {
            _options = options;
            _hubContext = hubContext;
        }
        public async Task<IActionResult> Index()
        {
            return View("Index");
        }
    }
}
