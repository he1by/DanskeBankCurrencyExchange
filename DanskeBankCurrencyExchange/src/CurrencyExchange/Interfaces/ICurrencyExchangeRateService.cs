namespace CurrencyExchange.Interfaces
{
    public interface ICurrencyExchangeRateService
    {
        public decimal GetExchange(string fromISOCurrency, string toISOCurrency, string amount);
    }
}
