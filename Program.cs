using BanksExchangeRates.Domain.Entities;
using BanksExchangeRates.Domain.Interfaces;
using BanksExchangeRates.Infrastructure.Repositories;
using BanksExchangeRates.Util;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<List<XPathModel>>(builder.Configuration.GetSection("BanksExchangeRates"));

// Add services to the container.
builder.Services.AddSignalR();
builder.Services.AddScoped<IDataService, DataServiceRepository>();
builder.Services.AddScoped<DataUpdateService>();
builder.Services.AddHostedService<DataUpdateService>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapHub<MyHub>("/myhub");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=ExchangeRate}/{action=Index}/{id?}");

app.Run();
