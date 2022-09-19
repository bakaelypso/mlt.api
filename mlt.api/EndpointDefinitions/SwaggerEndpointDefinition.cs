namespace mlt.api.EndpointDefinitions;

// ReSharper disable once UnusedType.Global
public class SwaggerEndpointDefinition : IEndpointDefinition
{
    public void DefineEndpoints(WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Version 1"));
    }

    public void DefineServices(IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            var actionsSortingOrder = new Dictionary<string, int>
            {
                { "GET", 0 },
                { "POST", 1 },
                { "PUT", 2 },
                { "DELETE", 3 },
            };

            var actionsDefaultOrder = actionsSortingOrder.Max(m => m.Value) + 1;
            var actionOrderCollector = new Dictionary<string, int>();

            c.OrderActionsBy((oa =>
            {
                var method = oa.HttpMethod?.ToUpperInvariant();
                string res;

                if (actionsSortingOrder.ContainsKey(method!))
                {
                    if (!actionOrderCollector.ContainsKey(method!))
                    {
                        actionOrderCollector[method!] = 0;
                    }

                    res = $"{actionsSortingOrder[method!]}.{actionOrderCollector[method!]++}";
                }
                else
                {
                    res = actionsDefaultOrder.ToString();
                }

                return res;
            }));


            c.SwaggerDoc("v1", new OpenApiInfo { Title = "MLT Station", Version = "v1" });
            // c.OrderActionsBy((apiDesc) => $"{(apiDesc.HttpMethod.ToUpper() == "GET" ? 0 : 1 )}");
            // c.OrderActionsBy((apiDesc) => $"{apiDesc.RelativePath}{apiDesc.HttpMethod}");
        });
    }
}