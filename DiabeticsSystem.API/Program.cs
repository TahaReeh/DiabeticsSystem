using DiabeticsSystem.API;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder
       .ConfigureServices()
       .ConfigurePipeline();

//await app.ResetDatabaseAsync();

app.Run();

public partial class Program { }
