using Microsoft.AspNetCore.Mvc;
using RecettesAPI.Models;
using RecettesAPI.Data;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace RecettesAPI.Controllers;

[ApiController]
[Route("recipes")]
public class RecettesController : ControllerBase
{
    private readonly ILogger<RecettesController> _logger;
    private readonly IMongoDatabase _mongoDatabase;

    public RecettesController(ILogger<RecettesController> logger, IMongoDatabase mongoDatabase)
    {
        _logger = logger;
        _mongoDatabase = mongoDatabase;
    }

    [HttpGet]
    public IEnumerable<Recette> Get()
    {
        var recettesCollection = _mongoDatabase.GetCollection<Recette>(nameof(Recette));
        var recettes = recettesCollection.Find(new BsonDocument()).ToList();
        System.Console.WriteLine(recettes);
        return recettes;
    }

    [HttpGet("count")]
    public IActionResult GetRecipeCount(string categoryId)
    {
        var recipesCollection = _mongoDatabase.GetCollection<Recette>(nameof(Recette));

        var filter = Builders<Recette>.Filter.Eq("CategoryId", categoryId);
        var count = recipesCollection.CountDocuments(filter);

        return Ok(new { CategoryId = categoryId, RecipeCount = count });
    }

    [HttpGet("{id}")]
    public IEnumerable<Recette> GetById(string id)
    {
        FilterDefinition<Recette> filter = Builders<Recette>.Filter.Eq("RecipeId", id);
        var recettesCollection = _mongoDatabase.GetCollection<Recette>(nameof(Recette));
        var recettes = recettesCollection.Find(filter).ToList();
        return recettes;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Recette recettes)
    {
        await _mongoDatabase.GetCollection<Recette>(nameof(Recette)).InsertOneAsync(recettes);
        return CreatedAtAction(nameof(Get), new { id = recettes.Id_categorie }, recettes);
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> ModifyRecette(string id, [FromBody] RecettePutDto RecettePutDto)
    {
        FilterDefinition<Recette> filter = Builders<Recette>.Filter.Eq("RecipeId", id);
        UpdateDefinition<Recette> update = Builders<Recette>.Update.Set(c => c.Title, RecettePutDto.Title)
            .Set(c => c.Photo_url, RecettePutDto.Photo_url)
            .Set(c => c.Time, RecettePutDto.Time)
            .Set(c => c.Time, RecettePutDto.Description);

        var result = await _mongoDatabase.GetCollection<Recette>(nameof(Recette))
            .UpdateOneAsync(filter, update);
        if (result.ModifiedCount <= 0)
        {
            return NotFound();
        }
        else
        {
            return Ok();
        }
    }
    
    [HttpGet("category/{categoryId}")]
    public IEnumerable<Recette> GetRecipesByCategory(string categoryId)
    {
        var recettesCollection = _mongoDatabase.GetCollection<Recette>(nameof(Recette));

        var filter = Builders<Recette>.Filter.Eq("Id_categorie", categoryId);
        var recettes = recettesCollection.Find(filter).ToList();

        return recettes;
    }


    [HttpDelete("{id}")]
    public IActionResult Delete(string id)
    {
        FilterDefinition<Recette> filter = Builders<Recette>.Filter.Eq("RecipeId", id);
        var result = _mongoDatabase.GetCollection<Recette>(nameof(Recette)).DeleteOne(filter);
        if (result.DeletedCount <= 0)
        {
            return NotFound();
        }
        else
        {
            return Ok();
        }
    }
}