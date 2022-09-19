namespace mlt.api.EndpointDefinitions;

// ReSharper disable once UnusedType.Global
public class CustomerEndpointDefinition : BaseEndpointDefinition<Customer>
{
    // protected override string GetControllerName => "Machin";

    protected override void WithEndpoints()
    {
        MapGet(TrucPourGet, "Truc");
        MapDelete(TrucPourDelete, "Truc");
    }

    private static Task<Customer> TrucPourGet(IBaseRepository<Customer> arg)
    {
        throw new NotImplementedException();
    }

    private static Task<IResult> TrucPourDelete(IBaseRepository<Customer> repo, Guid id)
    {
        throw new NotImplementedException();
    }

    public override void DefineServices(IServiceCollection services)
    {
        services.AddSingleton<IBaseRepository<Customer>, CustomerBddRepository>();
    }
}