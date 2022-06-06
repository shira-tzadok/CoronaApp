using EpidemiologyReport.Services.Models;
using EpidemiologyReport.Services.Repositorieis;
using EpidemiologyReport.DAL;
using Microsoft.AspNetCore.Diagnostics;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ILocationRepository, LocationRepository>();
builder.Services.AddSingleton<IPatientRepository, PatientRepository>();

//logger
var logger = new LoggerConfiguration()
  .ReadFrom.Configuration(builder.Configuration)
  .Enrich.FromLogContext()
  .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);


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

app.UseRouting();

//middleware
app.UseExceptionHandler(c => c.Run(async context =>
{
    //context.Response.StatusCode = StatusCodes.Status500InternalServerError;
    //context.Response.ContentType = Text.Plain;
    //await context.Response.WriteAsync("exeption was thrown.");
    var code = context.Response.StatusCode > 400 ? 400 : 200;
    var exeption = context.Features
    .Get<IExceptionHandlerPathFeature>().Error;
    var response = new { error = exeption.Message, code = code };
    await context.Response.WriteAsJsonAsync(response);
}));

app.Run();
public partial class Program { }