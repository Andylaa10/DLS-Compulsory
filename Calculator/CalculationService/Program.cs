using AutoMapper;
using CalculationService.Core.Models;
using CalculationService.Core.Services.DTOs;
using CalculationService.Services;
using Monitoring;
using OpenTelemetry.Trace;
using ResultService.Core.Helper;
using ResultService.Core.Repositories;
using ResultService.Core.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);


/*** START OF IMPORTANT CONFIGURATION ***/
var serviceName = "MyTracer";
var serviceVersion = "1.0.0";

builder.Services.AddOpenTelemetry().Setup();
builder.Services.AddSingleton(TracerProvider.Default.GetTracer(serviceName));
/*** END OF IMPORTANT CONFIGURATION ***/

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var mapperConfig = new MapperConfiguration(config =>
{
    //DTO to entity
    config.CreateMap<AddCalculationDTO, Calculation>();
}).CreateMapper();

builder.Services.AddSingleton(mapperConfig);

builder.Services.AddDbContext<CalculationDbContext>();

builder.Services.AddScoped<ICalculationRepository, CalculationRepository>();
builder.Services.AddScoped<ICalculationService, CalculationService.Core.Services.CalculationService>();


var app = builder.Build();

app.UseCors(options =>
{
    options.SetIsOriginAllowed(origin => true)
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials();
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();