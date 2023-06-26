using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json.Serialization;
using TestStGenentics.Api.Data;
using TestStGenentics.Api.Domain.Implametations;
using TestStGenentics.Api.Domain.Interfaces;
using TestStGenentics.Api.Services.Implementations;
using TestStGenentics.Api.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles); 
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IAnimalDomain, AnimalDomain>();
builder.Services.AddScoped<IAnimalDbService, AnimalDbService>();
builder.Services.AddScoped<ISexDbService, SexDbService>();
builder.Services.AddScoped<IStatusRowService, StatusRowDbService>();
builder.Services.AddScoped<IBreedDbService, BreedDbService>();
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddDbContext<DataContext>(x=>x.UseSqlServer("name=LocalConnection"));
builder.Services.AddTransient<SeedDb>();
var app = builder.Build();
SeedData(app);

void SeedData(WebApplication app)
{
    IServiceScopeFactory? scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (IServiceScope? scope = scopedFactory!.CreateScope())
    {
        SeedDb? service = scope.ServiceProvider.GetService<SeedDb>();
        service!.SeedAsync().Wait();
    }
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true)
    .AllowCredentials());

app.Run();
