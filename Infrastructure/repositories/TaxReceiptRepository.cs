using System.Data;
using Domain.Models;
using Infrastructure.interfaces.repository;
using RepoDb;

namespace Infrastructure.repositories;

public class TaxReceiptRepository: ITaxReceiptRepository
{
    public IDbConnection Connection { get; }
    
    public TaxReceiptRepository(IDbConnection connection)
    {
        Connection = connection;
    }


    public async Task<IEnumerable<TaxReceipt>> GetTaxReceiptsByTaxPayerId(long taxPayerId)
    {
        return await Connection.QueryAsync<TaxReceipt>(t => t.TaxPayerId == taxPayerId);
    }
}