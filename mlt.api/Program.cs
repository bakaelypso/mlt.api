var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointDefinitions(typeof(Customer));

var app = builder.Build();
app.UseEndpointDefinitions();

app.Run();