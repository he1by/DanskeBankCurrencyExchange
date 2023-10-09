using CurrencyExchange.Application.Interfaces;
using CurrencyExchange.Infrastructure.Data;
using CurrencyExchange.Interfaces;
using CurrencyExchange.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services => {
        services.AddTransient<ICurrencyDataService, CurrencyDataService>();
        services.AddTransient<ICurrencyExchangeRateService, CurrencyExchangeRateService>();
    }).Build();

var currencyExchangeRateService = host.Services.GetService<ICurrencyExchangeRateService>();
Console.Write("Enter from currency (e.g., EUR): ");
var fromCurrencyInput = Console.ReadLine();

Console.Write("Enter to currency (e.g., EUR): ");
var toCurrencyInput = Console.ReadLine();

Console.Write("Enter amount: ");
var amount = Console.ReadLine();

try
{
    var result = currencyExchangeRateService.GetExchange(fromCurrencyInput, toCurrencyInput, amount);
    Console.WriteLine($"Exchanged amount: {result}");
}
catch (Exception ex)
{
    //TODO: should rewrite validation
    Console.WriteLine(ex.Message);
}
