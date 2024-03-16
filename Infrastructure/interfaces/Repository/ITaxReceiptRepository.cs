using Domain.Models;

namespace Infrastructure.interfaces.repository;

public interface ITaxReceiptRepository: IBaseRepository<TaxReceipt, int>
{
    Task<IEnumerable<TaxReceipt>> GetTaxReceiptsByTaxPayerId(int taxPayerId);
}