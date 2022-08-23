﻿namespace worker.mongo.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection InitializeServices(this IServiceCollection services)
    {
        // services.AddSingleton<ICustomerRepository, CustomerRepository>();

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo {Title = "Mlt Web Api", Version = "v1"}); });

        return services;
    }
}