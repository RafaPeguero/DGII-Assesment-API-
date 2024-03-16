using System.Data;
using Infrastructure.interfaces.repository;

namespace Infrastructure.repositories;

public class TaxpayerRepository : ITaxpayerRepository
{
    public TaxpayerRepository(IDbConnection connection)
    {
        Connection = connection;
    }

    public IDbConnection Connection { get; }
}