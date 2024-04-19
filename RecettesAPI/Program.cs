using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;
using RecettesAPI.Data;


var builder = WebApplication.CreateBuilder(args);

// Configuration de la connexion à MongoDB
// builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("ConnectionStrings:MongoDB"));

var Configuration = builder.Configuration;
var mongoDbSettings = Configuration.GetConnectionString("MongoDB");

if (mongoDbSettings == null)
{
    Environment.Exit(0);
}

var client = new MongoClient(mongoDbSettings);


// Configuration des services des contrôleurs
builder.Services.AddControllers();

// Configuration de Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Recettes API", Version = "v1" });
});
var database = client.GetDatabase("recettesAPI");
builder.Services.AddSingleton<IMongoClient>(client);
builder.Services.AddSingleton<IMongoDatabase>(database);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

// Initialiser les données avec SeedData
using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    SeedData.Initialize(database);
    
}

app.Run();