using System.Reflection;
using EdunovaWP1.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(sgo =>
{
    var o = new Microsoft.OpenApi.Models.OpenApiInfo()
    {
        Title = "Edunova API",
        Version = "v1",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact()
        {
            Email="dljubicic2@gmail.com",
            Name="Domagoj Ljubičić"
        },
        Description = "Ovo je dokumentacija za Edunova API",
        License = new Microsoft.OpenApi.Models.OpenApiLicense()
        {
            Name="Edukacijaska licenca"
        }
    };
    sgo.SwaggerDoc("v1", o);
    var xmlFile=$"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    sgo.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);
});

// Loš način
builder.Services.AddCors(opcije =>
{
    opcije.AddPolicy("CorsPolicy", 
        builder => 
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

// Dodavanje baze podataka
builder.Services.AddDbContext<EdunovaContext>(o =>
    o.UseSqlServer(
    builder.Configuration.
    GetConnectionString(name: "EdunovaContext")
        )
    );

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Enviroment.IsDevelopment())
//{
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger(opcije =>
    {
        opcije.SerializeAsV2 = true;
    });
    app.UseSwaggerUI(opcije =>
    {
        opcije.ConfigObject.AdditionalItems.Add("requestSnippetsEnabled", true);
    });
//}
//}

//app.UseHttpsRedirection();

app.MapControllers();
app.UseStaticFiles();

app.UseDefaultFiles();
app.UseDeveloperExceptionPage();
app.MapFallbackToFile("index.html");

app.UseCors("CorsPolicy");

app.Run();
