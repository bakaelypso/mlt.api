namespace mlt.api.EndpointDefinitions;

internal class CustomersEndpointDefinition : IEndpointDefinition
{
    public void DefineEndpoints(WebApplication app)
    {
        app.MapGet("/customers", GetAllDocuments);
        app.MapGet("/customers/{{id:guid}}", GetDocumentById);
        app.MapPost("/customers/", CreateDocument);
        app.MapPut("/customers/{{id:guid}}", UpdateDocument);
        app.MapDelete("/customers/{{id:guid}}", DeleteDocument);
    }

    public void DefineServices(IServiceCollection services) { services.AddSingleton<CustomerRepository>(); }

    private IAsyncEnumerable<Customer> GetAllDocuments(CustomerRepository repo) => repo.GetAll();

    private IResult CreateDocument(CustomerRepository repo, Customer customer)
    {
        repo.Create(customer);
        return Results.Created($"/customers/{customer.Id}", customer);
    }

    private IResult UpdateDocument(CustomerRepository repo, Guid id, T updatedCustomer)
    {
        if (repo.GetById(id) is null)
            return Results.NotFound();

        repo.Update(id, updatedCustomer);
        return Results.Ok(updatedCustomer);
    }

    private IResult DeleteDocument(CustomerRepository repo, Guid id)
    {
        repo.Delete(id);
        return Results.Ok();
    }

    private async Task<IResult> GetDocumentById(CustomerRepository repo, Guid id) => await repo.GetById(id) is { } customer ? Results.Ok(customer) : Results.NotFound();
}

internal interface IEndpointDefinition
{
    void DefineEndpoints(WebApplication app);
    void DefineServices(IServiceCollection services);
}