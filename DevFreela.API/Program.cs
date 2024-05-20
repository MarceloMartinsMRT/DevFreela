using DevFreela.API.Models;
using DevFreela.Application.Services.Implementations;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<OpeningTimeOptions>(builder.Configuration.GetSection("OpeningTime"));

//builder.Services.AddSingleton<ExampleClass>(e => new ExampleClass { name = "Initial Stage" });
builder.Services.AddScoped<ExampleClass>(e => new ExampleClass { name = "Initial Stage" });
builder.Services.AddSingleton<DevFreelaDBContext>();
builder.Services.AddScoped<IProjectService, ProjectService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//builder.Services.Configure<OpeningTimeOptions>(builder.Configuration.GetSection("OpeningTime"));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
