using System.Data;
using RepoDb;
using RepoDb.Enumerations;
using RepoDb.Options;

namespace DGII_Assesment_API_Test.Utilities;

public static class RepositoryTestUtility
{
    public static IDbConnection Setup(string tablePath)
    {
        GlobalConfiguration.Setup(
            new GlobalConfigurationOptions
            {
                ConversionType = ConversionType.Automatic
            }
        ).UseSqlite();
        
        var conn = TestConnectionFactory.CreateMockConnection();
        var table = new StreamReader(tablePath).ReadToEnd();
        conn.ExecuteQuery(table);

        return conn;
    }
}