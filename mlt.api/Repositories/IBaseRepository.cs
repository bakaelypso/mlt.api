using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace mlt.api.Repositories;

internal interface IBaseRepository<T> where T : IIdentifiableDocument
{
    Task Create(T document);
    Task<T> GetById(Guid id);
    IAsyncEnumerable<T> GetAll();
    Task Update(Guid id, T updatedDocument);
    Task Delete(Guid id);
}