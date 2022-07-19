using Microsoft.AspNetCore.Builder;
using mlt.api.EndpointDefinitions;

namespace mlt.api.Extensions;

public static class WebApplicationExtension
{
    public static WebApplication DefineCustomersEndpoints(this WebApplication app)
    {
        CustomersEndpoints.GetEndpoints(app);

        return app;
    }

    public static WebApplication DefineSwaggerEndpoints(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mlt api v1"));

        return app;
    }
}