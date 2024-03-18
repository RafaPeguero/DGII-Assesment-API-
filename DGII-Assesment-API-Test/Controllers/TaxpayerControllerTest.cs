using Domain.Models;
using FluentAssertions;
using Infrastructure.interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using Web.API.Controllers;

namespace DGII_Assesment_API_Test.Controllers;
[TestClass]
public class TaxpayerControllerTest
{
    private ITaxpayerService _service = null!;
    private TaxpayerController _controller = null!;
    
    [TestInitialize]
    public void Setup()
    {
        _service = Substitute.For<ITaxpayerService>();
        _controller = new TaxpayerController(_service);
    }
    [TestMethod]
    public async Task GetAllTaxpayers_ReturnsOkResultWithTaxpayers_WhenServiceReturnsData()
    {
        // Arrange
        var taxpayers = new List<Taxpayer>()
        {
            new ()
            {
                TaxpayerId = 111111111,
                Name = "Juan Perez",
                Status = "Activo",
                Type = "Persona Fisica",
            },
            new ()
            {
                TaxpayerId = 22222,
                Name = "Pedro Sanchez",
                Status = "Activo",
                Type = "Persona Fisica",
            }
        };
        _service.GetAllTaxpayers().Returns(taxpayers);

        // Act
         var result = await _controller.GetAllTaxpayers();

        // Assert
        result.Should().BeOfType<OkObjectResult>();
        var okResult = (OkObjectResult)result;
        var actualTaxpayers = (List<Taxpayer>)okResult.Value!;
        actualTaxpayers.Should().BeEquivalentTo(taxpayers);
    }
    [TestMethod]
    public async Task GetAllTaxpayers_ReturnsBadRequestResult_WhenServiceThrowsException()
    {
        // Arrange
        var exceptionMessage = "An error occurred.";
        _service.GetAllTaxpayers().ThrowsAsync(new Exception(exceptionMessage));

        // Act
        var result = await _controller.GetAllTaxpayers();

        // Assert
        result.Should().BeOfType<BadRequestObjectResult>();
        var badRequestResult = (BadRequestObjectResult)result;
        badRequestResult.Value.Should().BeEquivalentTo(exceptionMessage);
    }
}