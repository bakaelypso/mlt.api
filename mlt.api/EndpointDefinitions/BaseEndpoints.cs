using System.Reflection;

namespace mlt.api.EndpointDefinitions;

internal abstract class BaseEndpoints<T> : IBaseRepository<T> where T : IIdentifiableDocument
{
    protected abstract string BaseEndpoint();
    
    // private string EndpointBaseName => $"/{BaseEndpoint()}";
    
    public void GetEndpoints(WebApplication app)
    {
        app.MapGet($"/{BaseEndpoint()}", GetAllDocuments);
        app.MapGet($"/{BaseEndpoint()}/{{id:guid}}", GetDocumentById);
        app.MapPost($"/{BaseEndpoint()}/", CreateDocument);
        app.MapPut($"/{BaseEndpoint()}/{{id:guid}}", UpdateDocument);
        app.MapDelete($"/{BaseEndpoint()}/{{id:guid}}", DeleteDocument);
    }
    
    private IAsyncEnumerable<T> GetAllDocuments(IBaseRepository<T> repo) => repo.GetAll();
    private IResult CreateDocument(IBaseRepository<T> repo, T customer)
    {
        repo.Create(customer);
        return Results.Created($"/{BaseEndpoint()}/{customer.Id}", customer);
    }

    private IResult UpdateDocument(IBaseRepository<T> repo, Guid id, T updatedCustomer)
    {
        if (repo.GetById(id) is null)
            return Results.NotFound();

        repo.Update(id, updatedCustomer);
        return Results.Ok(updatedCustomer);
    }

    private IResult DeleteDocument(IBaseRepository<T> repo, Guid id)
    {
        repo.Delete(id);
        return Results.Ok();
    }

    private async Task<IResult> GetDocumentById(IBaseRepository<T> repo, Guid id) => await repo.GetById(id) is { } customer ? Results.Ok(customer) : Results.NotFound();
    
    
    public Task Create(T document) => throw new NotImplementedException();
    public Task<T> GetById(Guid id) => throw new NotImplementedException();
    public IAsyncEnumerable<T> GetAll() => throw new NotImplementedException();
    public Task Update(Guid id, T updatedDocument) => throw new NotImplementedException();
    public Task Delete(Guid id) => throw new NotImplementedException();
}