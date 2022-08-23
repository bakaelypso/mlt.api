using Microsoft.AspNetCore.Builder;

namespace worker.mongo.Extensions;

public static class WebApplicationExtension
{
    public static WebApplication DefineSwaggerEndpoints(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mlt api v1"));

        return app;
    }
}