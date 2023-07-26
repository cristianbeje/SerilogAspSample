using Serilog;

//Log.Logger = new LoggerConfiguration()
//    .WriteTo.Console()
//    .WriteTo.Debug()
//    .CreateLogger();

//Log.Information("Starting web application");

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Host.UseSerilog();
builder.Host.UseSerilog((context, services, configuration) => configuration
    //.ReadFrom.Configuration(context.Configuration)
    //.ReadFrom.Services(services)
    .MinimumLevel.Information()
    .Enrich.FromLogContext()
    .WriteTo.Debug());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
