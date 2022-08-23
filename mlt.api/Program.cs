using mlt.api.Settings;

var builder = WebApplication.CreateBuilder(args);
builder.Services.InitializeServices();

builder.Services.Configure<CustomersDatabaseSettings>(builder.Configuration.GetSection("MltDatabase"));
builder.Services.AddSingleton<BaseEndpoints<Customer>, CustomersEndpoints>();


var app = builder.Build()
    .DefineCustomersEndpoints()
    .DefineSwaggerEndpoints();

app.Run();