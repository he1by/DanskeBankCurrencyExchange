using CurrencyExchange.Application.Interfaces;
using CurrencyExchange.Domain.Entities;

namespace CurrencyExchange.Infrastructure.Data;

public class CurrencyDataService : ICurrencyDataService
{
    //TODO: HARDCODED dataset should be replaced in database with context and etc.
    private readonly List<Currency> _exchangeRates = new()
    {
        new Currency()
        {
            ISO = "DKK",
            Name = "Danish kroner",
            Amount = 1M
        },
        new Currency()
        {
            ISO = "EUR",
            Name = "Euro",
            Amount = 743.94M
        },
        new Currency()
        {
            ISO = "USD",
            Name = "Amerikanske dollar",
            Amount = 663.11M
        },
        new Currency()
        {
            ISO = "GBP",
            Name = "Britiske pund",
            Amount = 852.85M
        },
        new Currency()
        {
            ISO = "SEK",
            Name = "Svenske kroner",
            Amount = 76.10M
        },
        new Currency()
        {
            ISO = "NOK",
            Name = "Norske kroner",
            Amount = 78.40M
        },
        new Currency()
        {
            ISO = "CHF",
            Name = "Schweiziske franc",
            Amount = 683.58M
        },
        new Currency()
        {
            ISO = "JPY",
            Name = "Japanske yen",
            Amount =  5.9740M
        }
    };

    public Currency GetCurrencyByISO(string ISO)
    {
        var currency = _exchangeRates.FirstOrDefault(c => c.ISO.Equals(ISO));
        return currency;
    }
}