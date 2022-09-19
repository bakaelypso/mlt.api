namespace mlt.common.Repositories;

public interface IBaseRepository<T> where T : class
{
    Task<List<T>> GetAsync();
    Task<T?> GetAsync(Guid id);
    Task CreateAsync(T createdModel);
    Task UpdateAsync(Guid id, T updatedModel);
    Task RemoveAsync(Guid id);
}