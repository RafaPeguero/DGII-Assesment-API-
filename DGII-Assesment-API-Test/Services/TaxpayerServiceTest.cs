using Infrastructure.interfaces.repository;
using Infrastructure.interfaces.Services;
using Infrastructure.Services;
using NSubstitute;

namespace DGII_Assesment_API_Test.Services;
[TestClass]
public class TaxpayerServiceTest
{
    private  ITaxpayerRepository _repository = null!;
    private ITaxpayerService _service = null!;
    
    [TestInitialize]
    public void Setup()
    {
        _repository = Substitute.For<ITaxpayerRepository>();
        _service = new TaxpayerService(_repository);
    }
    
    [TestMethod]
    public async Task Should_Get_All_Taxpayers()
    {
        await _service.GetAllTaxpayers();
        await _repository.Received(1).GetAll();
    }
}