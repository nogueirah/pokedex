using PokeApplication;
using PokeInfrastructure;
using PokeInfrastructure.Data;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.MapControllers();

app.Run();