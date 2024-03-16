using System.Data;
using RepoDb;

namespace Infrastructure.interfaces;

public interface IBaseRepository<T, in TP> : IDisposable where T : class
{
    IDbConnection Connection { get; }

    public async Task Save(T entity)
    {
        await Connection.MergeAsync(entity);
    }
    
    public async Task SaveAll(IEnumerable<T> entities)
    {
        await Connection.MergeAllAsync(entities);
    }
    
    public async Task Delete(TP primaryKey)
    {
        await Connection.DeleteAsync<T>(primaryKey);
    }
    
    public async Task<T?> Get(TP primaryKey)
    {
        return (await Connection.QueryAsync<T>(primaryKey))?.FirstOrDefault();
    }
    
    public async Task<IEnumerable<T>?> GetAll()
    {
        return await Connection.QueryAllAsync<T>();
    }
    
    void IDisposable.Dispose()
    {
        Connection.Dispose();
    }
}