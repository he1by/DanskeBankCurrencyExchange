using CurrencyExchange.Application.Interfaces;
using CurrencyExchange.Exceptions;
using CurrencyExchange.Interfaces;

namespace CurrencyExchange.Services
{
    public class CurrencyExchangeRateService : ICurrencyExchangeRateService
    {
        private readonly ICurrencyDataService _currencyDataService;
        public CurrencyExchangeRateService(ICurrencyDataService currencyDataService)
        {
            _currencyDataService = currencyDataService;
        }

        public decimal GetExchange(string fromISOCurrency, string toISOCurrency, string amount)
        {
            //TODO: should be care with string and convert to decimal
            //TODO: move to validator
            if (!decimal.TryParse(amount, out var amountAsDecemail)) throw new WrongAmountException("Unsupported amount");
            if (fromISOCurrency.Equals(toISOCurrency)) return amountAsDecemail;

            var fromCurrency = _currencyDataService.GetCurrencyByISO(fromISOCurrency);
            var toCurrency = _currencyDataService.GetCurrencyByISO(toISOCurrency);

            //TODO: move to validator
            if (fromCurrency == null || toCurrency == null) throw new UnsupportedISOException("Unsupported currency ISO");

            var exchangeRate = fromCurrency.Amount / toCurrency.Amount;
            return exchangeRate * amountAsDecemail;
        }
    }
}
