using Domain.Models;

namespace Infrastructure.interfaces.Services;

public interface ITaxReceiptService
{
    Task<IEnumerable<TaxReceipt>> GetAllTaxReceipts();
    Task<IEnumerable<TaxReceipt>> GetAllTaxReceiptsByTaxpayerId(int taxpayerId);
}