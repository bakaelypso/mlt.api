namespace mlt.api.EndpointDefinitions;

// ReSharper disable once UnusedType.Global
public class RssEndpointDefinition : BaseEndpointDefinition<FreshRss>
{
    protected override void WithEndpoints()
    {
        
    }

    public override void DefineServices(IServiceCollection services)
    {
        services.AddSingleton<IBaseRepository<FreshRss>, RssRepository>();
    }
}