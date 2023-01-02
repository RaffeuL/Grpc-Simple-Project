using GrpcClientAPI.Extensions;
using GrpcClientAPI.Routes;

var builder = WebApplication.CreateBuilder(args);
builder.Services.RegistraAPI();
builder.Services.AddDomainConfig();
var app = builder.Build();

app.RegistraAPI();
app.AddEndPoints(builder.Services.BuildServiceProvider());

app.Run();