using CurrencyExchange.Application.Interfaces;
using CurrencyExchange.Services;
using CurrencyExchange.Exceptions;
using CurrencyExchange.Domain.Entities;

namespace CurrencyExchange.UnitTests;
public class CurrencyExchangeRateServiceTests
{
    [Fact]
    public void GetExchange_SameCurrency_ReturnsOriginalAmount()
    {
        // Arrange
        var currencyDataServiceMock = new Mock<ICurrencyDataService>();
        var service = new CurrencyExchangeRateService(currencyDataServiceMock.Object);
        var fromCurrency = "USD";
        var toCurrency = "USD";
        var amount = "95";

        // Act
        var exchangedAmount = service.GetExchange(fromCurrency, toCurrency, amount);

        // Assert
        Assert.Equal(95.00M, exchangedAmount);
    }

    [Fact]
    public void GetExchange_InvalidAmount_ThrowsException()
    {
        // Arrange
        var currencyDataServiceMock = new Mock<ICurrencyDataService>();
        var service = new CurrencyExchangeRateService(currencyDataServiceMock.Object);
        var fromCurrency = "DKK";
        var toCurrency = "EUR";
        var invalidAmount = "InvalidAmount";

        // Act & Assert
        Assert.Throws<WrongAmountException>(() => service.GetExchange(fromCurrency, toCurrency, invalidAmount));
    }

    [Fact]
    public void GetExchange_UnknownCurrency_ThrowsException()
    {
        // Arrange
        var currencyDataServiceMock = new Mock<ICurrencyDataService>();
        currencyDataServiceMock.Setup(cd => cd.GetCurrencyByISO(It.IsAny<string>())).Returns((Currency)null);
        var service = new CurrencyExchangeRateService(currencyDataServiceMock.Object);
        var fromCurrency = "Long_string_value";
        var toCurrency = "EUR";
        var amount = "10";

        // Act & Assert
        Assert.Throws<UnsupportedISOException>(() => service.GetExchange(fromCurrency, toCurrency, amount));
    }

    [Fact]
    public void GetExchange_ValidExchange_ReturnsCorrectAmount()
    {
        // Arrange
        var currencyDataServiceMock = new Mock<ICurrencyDataService>();
        currencyDataServiceMock.Setup(cd => cd.GetCurrencyByISO("USD")).Returns(new Currency { Name = string.Empty, ISO = "USD", Amount = 1.0M });
        currencyDataServiceMock.Setup(cd => cd.GetCurrencyByISO("EUR")).Returns(new Currency { Name = string.Empty, ISO = "EUR", Amount = 1.0M });
        
        var service = new CurrencyExchangeRateService(currencyDataServiceMock.Object);
        var fromCurrency = "USD";
        var toCurrency = "EUR";
        var amount = "1";

        // Act
        var exchangedAmount = service.GetExchange(fromCurrency, toCurrency, amount);

        // Assert
        Assert.Equal(1, exchangedAmount);
    }
}