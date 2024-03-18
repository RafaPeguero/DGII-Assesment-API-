using Domain.Models;
using FluentAssertions;
using Infrastructure.interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using Web.API.Controllers;

namespace DGII_Assesment_API_Test.Controllers;
[TestClass]
public class TaxReceiptControllerTest
{
    private ITaxReceiptService _service = null!;
    private TaxReceiptController _controller = null!;
    private readonly List<TaxReceipt> _taxReceipts =
    [
        new TaxReceipt
        {
            Id = 1,
            TaxPayerId = 111111111,
            Ncf = "E1",
            Amount = 100.00,
            Itbis18 = 180.00
        },

        new TaxReceipt
        {
            Id = 2,
            TaxPayerId = 111111111,
            Ncf = "E3",
            Amount = 100.00,
            Itbis18 = 180.00
        },

        new TaxReceipt
        {
            Id = 3,
            TaxPayerId = 222222,
            Ncf = "E2",
            Amount = 350.00,
            Itbis18 = 25.00
        }

    ];

    [TestInitialize]
    public void Setup()
    {
        _service = Substitute.For<ITaxReceiptService>();
        _controller = new TaxReceiptController(_service);
    }
    
    [TestMethod]
    public async Task GetAllTaxReceipts_ReturnsOkResultWithTaxReceipts_WhenServiceReturnsData()
    {
        // Arrange

        _service.GetAllTaxReceipts().Returns(_taxReceipts);

        // Act
        var result = await _controller.GetAllTaxReceipts();

        // Assert
        result.Should().BeOfType<OkObjectResult>();
        var okResult = (OkObjectResult)result;
        var actualTaxReceipts = (List<TaxReceipt>)okResult.Value!;
        actualTaxReceipts.Should().BeEquivalentTo(_taxReceipts);
    }

    [TestMethod]
    public async Task GetAllTaxpReceipts_ReturnsBadRequestResult_WhenServiceThrowsException()
    {
        // Arrange
        var exceptionMessage = "An error occurred.";
        _service.GetAllTaxReceipts().ThrowsAsync(new Exception(exceptionMessage));

        // Act
        var result = await _controller.GetAllTaxReceipts();

        // Assert
        result.Should().BeOfType<BadRequestObjectResult>();
        var badRequestResult = (BadRequestObjectResult)result;
        badRequestResult.Value.Should().BeEquivalentTo(exceptionMessage);
    }

    [TestMethod]
    public async Task GetAllTaxReceiptsByTaxpayer_ReturnsOkResultWithTaxReceipts_WhenServiceReturnsData()
    {
        // Arrange
        long taxpayerId = 111111111;
        _service.GetAllTaxReceiptsByTaxpayerId(taxpayerId).Returns(_taxReceipts);

        // Act
        var result = await _controller.GetAllTaxReceiptsByTaxpayer(taxpayerId);

        // Assert
        result.Should().BeOfType<OkObjectResult>();
        var okResult = (OkObjectResult)result;
        var actualTaxReceipts = (List<TaxReceipt>)okResult.Value!;
        actualTaxReceipts.Should().BeEquivalentTo(_taxReceipts);
    }
    
    [TestMethod]
    public async Task GetAllTaxpReceiptsByTaxPayerId_ReturnsBadRequestResult_WhenServiceThrowsException()
    {
        // Arrange
        long taxpayerId = 111111111;
        var exceptionMessage = "An error occurred.";
        _service.GetAllTaxReceiptsByTaxpayerId(taxpayerId).ThrowsAsync(new Exception(exceptionMessage));

        // Act
        var result = await _controller.GetAllTaxReceiptsByTaxpayer(taxpayerId);

        // Assert
        result.Should().BeOfType<BadRequestObjectResult>();
        var badRequestResult = (BadRequestObjectResult)result;
        badRequestResult.Value.Should().BeEquivalentTo(exceptionMessage);
    }
}