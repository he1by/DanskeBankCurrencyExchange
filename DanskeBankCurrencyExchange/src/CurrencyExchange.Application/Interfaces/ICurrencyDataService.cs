using CurrencyExchange.Domain.Entities;

namespace CurrencyExchange.Application.Interfaces;
public interface ICurrencyDataService
{
    public Currency GetCurrencyByISO(string ISO);
}
