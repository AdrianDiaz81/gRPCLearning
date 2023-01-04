using gRPCAvengers.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddGrpc();
var app = builder.Build();

app.MapGet("/", () => "Hello Avengers Dev!!");
app.MapGrpcService<AvengerService>();
app.Run();
