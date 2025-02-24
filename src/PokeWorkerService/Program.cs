using Hangfire;
using PokeApplication;
using PokeInfrastructure;
using PokeWorkerService;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddHangfire(config => 
    config.UseSqlServerStorage(builder.Configuration.GetConnectionString("PokeConnection")));
builder.Services.AddApplicationServices();
builder.Services.AddHangfireServer();

builder.Services.AddHostedService<Worker>();

var host = builder.Build();

host.Services.GetService<IRecurringJobManager>().AddOrUpdate<PokeJobs.Jobs.PokeDataUpsertJob>(
    "upsert-poke-data",
    x => x.ExecuteAsync(),
    Cron.Hourly);

host.Services.GetService<IBackgroundJobClient>().Enqueue<PokeJobs.Jobs.PokeDataUpsertJob>(x => x.ExecuteAsync());

host.Run();