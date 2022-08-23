namespace mlt.api.EndpointDefinitions;

internal class CustomersEndpoints : BaseEndpoints<Customer>
{
    protected override string BaseEndpoint() => "customers";
}