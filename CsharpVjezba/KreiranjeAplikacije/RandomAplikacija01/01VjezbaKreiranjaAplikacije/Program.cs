using _01VjezbaKreiranjaAplikacije.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dodavanje baze podataka
builder.Services.AddDbContext<EdunovaContext>(o =>
    o.UseSqlServer(
    builder.Configuration.
    GetConnectionString(name: "EdunovaContext")
        )
    );

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(opcije =>
    {
        opcije.SerializeAsV2 = true;
    });
    app.UseSwaggerUI(opcije =>
    {
        opcije.ConfigObject.AdditionalItems.Add("requestSnippetsEnabled", true);
    });
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
