namespace mlt.api.Extensions;

public static class WebApplicationExtension
{
    public static WebApplication DefineCustomersEndpoints(this WebApplication app)
    {
        // var servides = app.Services.GetServices(Type);
        // var services = app.Services.GetService<IServiceCollection>();
        //  
        //
        // foreach (var service in services)
        // {
        //     //     _logger.LogDebug($"Service: {service.ServiceType.FullName}
        //     // \nLifetime: {service.Lifetime}
        //     // \nInstance: {service.ImplementationType?.FullName}");
        // }


        var tst = app.Services.GetService<BaseEndpoints<Customer>>();
        tst.GetEndpoints(app);
        // CustomersEndpoints.GetEndpoints(app);

        return app;
    }

    public static WebApplication DefineSwaggerEndpoints(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mlt api v1"));

        return app;
    }
}