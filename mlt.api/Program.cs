using Microsoft.AspNetCore.Builder;
using mlt.api.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.InitializeServices();

var app = builder
    .Build()
    .DefineCustomersEndpoints()
    .DefineSwaggerEndpoints();

app.Run();