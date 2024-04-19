using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;
using RecettesAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace RecettesAPI.Controllers;
[ApiController]
[Route("categories")]
public class CategoriesController : ControllerBase
{
    private readonly ILogger<CategoriesController> _logger;
    private readonly IMongoDatabase _mongoDatabase;

    public CategoriesController(ILogger<CategoriesController> logger, IMongoDatabase mongoDatabase)
        {
            _logger = logger;
            _mongoDatabase = mongoDatabase;
        }
    [HttpGet]
    public IEnumerable<Categories> Get()
    {
        var categoriesCollection = _mongoDatabase.GetCollection<Categories>(nameof(Categories));
        var categories = categoriesCollection.Find(new BsonDocument()).ToList();
        System.Console.WriteLine(categories);
        return categories;
    }
    
    
    [HttpGet("{id}")]
    public IEnumerable<Categories> GetById(string id)
    {
        FilterDefinition<Categories> filter = Builders<Categories>.Filter.Eq("Id_categorie", id);
        var categoriesCollection = _mongoDatabase.GetCollection<Categories>(nameof(Categories));
        var categories = categoriesCollection.Find(filter).ToList();
        return categories;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Categories categories)
    {
        await _mongoDatabase.GetCollection<Categories>(nameof(Categories)).InsertOneAsync(categories);
        return CreatedAtAction(nameof(Get), new { id = categories.Id_categorie }, categories);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> ModifyCategorie(string id, [FromBody] CategoriePutDto categoriePutDto)
    {
        FilterDefinition<Categories> filter = Builders<Categories>.Filter.Eq("Id_categorie", id);
        UpdateDefinition<Categories> update= Builders<Categories>.Update.Set(c => c.Name, categoriePutDto.Name).Set(c => c.Photourl, categoriePutDto.Photourl);
        var result = await _mongoDatabase.GetCollection<Categories>(nameof(Categories)).UpdateOneAsync(filter, update);
        if (result.ModifiedCount <= 0)
        {
            return NotFound();
        }
        else
        {
            return Ok();
        }

    }

    [HttpDelete("{id}")]
    public IActionResult Delete(string id)
    {
        FilterDefinition<Categories> filter = Builders<Categories>.Filter.Eq("Id_categorie", id);
        var result = _mongoDatabase.GetCollection<Categories>(nameof(Categories)).DeleteOne(filter);
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