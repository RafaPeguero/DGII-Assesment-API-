using Infrastructure.interfaces.repository;
using Infrastructure.interfaces.Services;
using Infrastructure.Services;
using NSubstitute;

namespace DGII_Assesment_API_Test.Services;
[TestClass]
public class TaxReceiptServiceTest
{
    private  ITaxReceiptRepository _repository = null!;
    private ITaxReceiptService _service = null!;
    
    [TestInitialize]
    public void Setup()
    {
        _repository = Substitute.For<ITaxReceiptRepository>();
        _service = new TaxReceiptService(_repository);
    }
    [TestMethod]
    public async Task Should_Get_All_TaxReceipts()
    {
        //Act
        await _service.GetAllTaxReceipts();
        //Assert
        await _repository.Received(1).GetAll();
    }
    
    [TestMethod]
    public async Task Should_Get_All_TaxReceiptsByTaxpayerId()
    {
        //Act
        await _service.GetAllTaxReceiptsByTaxpayerId(11111);
        //Assert
        await _repository.Received(1).GetTaxReceiptsByTaxPayerId(11111);
    }
}