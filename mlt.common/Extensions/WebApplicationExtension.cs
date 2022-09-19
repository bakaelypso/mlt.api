namespace mlt.common.Extensions;

public static class WebApplicationExtension
{
    public static void UseEndpointDefinitions(this WebApplication app)
    {
        var definitions = app.Services.GetRequiredService<IReadOnlyCollection<IEndpointDefinition>>();

        foreach (var endpointDefinition in definitions)
            endpointDefinition.DefineEndpoints(app);
    }
}