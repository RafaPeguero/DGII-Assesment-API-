using System.Data;

namespace Infrastructure.interfaces.Factories;

public interface IConnectionFactory
{
    IDbConnection CreateConnection(string connectionStringName);
}