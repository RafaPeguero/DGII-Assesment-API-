using Domain.Models;
using Infrastructure.interfaces.repository;
using Infrastructure.interfaces.Services;

namespace Infrastructure.Services;

public class TaxReceiptService: ITaxReceiptService
{
    private readonly ITaxReceiptRepository _receiptRepository;

    public TaxReceiptService(ITaxReceiptRepository receiptRepository)
    {
        _receiptRepository = receiptRepository;
    }

    public async Task<IEnumerable<TaxReceipt>> GetAllTaxReceipts()
    {
        return await _receiptRepository.GetAll() ?? throw new InvalidOperationException();
    }

    public async Task<IEnumerable<TaxReceipt>> GetAllTaxReceiptsByTaxpayerId(int taxpayerId)
    {
        return await _receiptRepository.GetTaxReceiptsByTaxPayerId(taxpayerId);
    }
}