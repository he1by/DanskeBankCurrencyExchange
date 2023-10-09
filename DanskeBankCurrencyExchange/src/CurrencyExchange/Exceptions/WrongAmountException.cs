namespace CurrencyExchange.Exceptions;

public class WrongAmountException: Exception
{
    public WrongAmountException(string message): base(message)
    {
    }
}
