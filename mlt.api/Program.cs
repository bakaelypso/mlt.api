var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointDefinitions(typeof(Customer));
builder.Services.Configure<MltStationDbSettings>(builder.Configuration.GetSection("MltDatabase"));
builder.Services.Configure<RssConfig>(builder.Configuration.GetSection("RssConfig"));

var app = builder.Build();
app.UseEndpointDefinitions();

app.Run();