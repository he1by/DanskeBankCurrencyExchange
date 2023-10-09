namespace CurrencyExchange.Domain.Entities;

public class Currency
{
    public required string Name { get; set; }
    public required string ISO { get; set; }
    public decimal Amount { get; set; }
}