var builder = WebApplication.CreateBuilder(args);

builder.Services
    .InitializeServices()
    .Configure<MltStationDatabaseSettings>(builder.Configuration.GetSection("MltDatabase"))
    .AddSingleton<RssService>();

var app = builder
    .Build()
    .DefineSwaggerEndpoints();

// app.MapGet("/rss", GetAllDocuments);
// app.MapGet("/rss/{id:guid}", GetDocumentById);
// app.MapPost("/rss/", CreateDocument);
// app.MapPut("/rss/{id:guid}", UpdateDocument);
// app.MapDelete("/rss/{id:guid}", DeleteDocument);

app.Run();