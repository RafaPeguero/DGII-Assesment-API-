using System.Data;
using Infrastructure.interfaces.Factories;
using Microsoft.Data.Sqlite;

namespace DGII_Assesment_API_Test.Utilities;

public class TestConnectionFactory : IConnectionFactory
{
    private TestConnectionFactory() { }
    
    public static IDbConnection CreateMockConnection()
    {
        return new TestConnectionFactory()
            .CreateConnection("DataSource=:memory:");
    }
    
    public IDbConnection CreateConnection(string connectionStringName)
    {
        var conn = new SqliteConnection(connectionStringName);
        conn.Open();
        return conn;
    }
}