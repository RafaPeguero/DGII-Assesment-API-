using System.Data;
using Infrastructure.interfaces.Factories;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Factories;

public class ConnectionFactory : IConnectionFactory
{
    private readonly IConfiguration _configuration;

    public ConnectionFactory(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IDbConnection CreateConnection(string connectionStringName)
    {
        return new SqliteConnection(_configuration[connectionStringName]);
    }
}