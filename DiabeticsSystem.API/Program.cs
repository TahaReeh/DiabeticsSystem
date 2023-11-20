using DiabeticsSystem.API;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

Log.Information("Diabetics API Started");

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Host.UseSerilog((context, loggerConfiguration) => loggerConfiguration
.WriteTo.Console()
.ReadFrom.Configuration(context.Configuration));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder
       .ConfigureServices()
       .ConfigurePipeline();

app.UseSerilogRequestLogging();
//await app.ResetDatabaseAsync();
await app.SeedDatabase();

app.Run();
