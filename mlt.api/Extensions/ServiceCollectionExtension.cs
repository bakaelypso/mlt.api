using Microsoft.Extensions.DependencyInjection;
using mlt.api.Repositories;

namespace mlt.api.Extentions;

public static class ServiceCollectionExtension
{
    public static void DefineServices(this ServiceCollection services)
    {
        services.AddSingleton<ICustomerRepository, CustomerRepository>();
    }
}