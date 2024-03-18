using FluentAssertions;
using Infrastructure.Factories;
using NSubstitute;
using Microsoft.Extensions.Configuration;

namespace DGII_Assesment_API_Test.Factories;
[TestClass]
public class ConnectionFactoryTest
{
    private ConnectionFactory _connectionFactory = null!;
    private IConfiguration _mockConfig = null!;
    
    [TestInitialize]
    public void Setup()
    {
        _mockConfig = Substitute.For<IConfiguration>();
        _connectionFactory = new ConnectionFactory(_mockConfig);
    }

    [TestMethod]
    public void ShouldCreateConnection()
    {
        var sut = _connectionFactory.CreateConnection("dgii-db");
        var _ = _mockConfig.Received(1)["dgii-db"];
        sut.Should().NotBeNull();
    }
}