namespace CurrencyExchange.Exceptions;

public class UnsupportedISOException: Exception
{
    public UnsupportedISOException(string message): base(message)
    { 
    }
}
