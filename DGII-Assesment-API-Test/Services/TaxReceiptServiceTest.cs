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
        await _service.GetAllTaxReceipts();
        await _repository.Received(1).GetAll();
    }
    
    [TestMethod]
    public async Task Should_Get_All_TaxReceiptsByTaxpayerId()
    {
        await _service.GetAllTaxReceiptsByTaxpayerId(11111);
        await _repository.Received(1).GetTaxReceiptsByTaxPayerId(11111);
    }
}