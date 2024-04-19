using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;
using RecettesAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


[ApiController]
[Route("api/[controller]")]
public class IngredientsController : ControllerBase
{
    private readonly ILogger<IngredientsController> _logger;
    private readonly IMongoDatabase _mongoDatabase;

    public IngredientsController(ILogger<IngredientsController> logger, IMongoDatabase mongoDatabase)
    {
        _logger = logger;
        _mongoDatabase = mongoDatabase;
    }

    [HttpGet]
    public IEnumerable<Ingredients> Get()
    {
        try
        {
            var ingredientCollection = _mongoDatabase.GetCollection<Ingredients>(nameof(Ingredients));
            var ingredients = ingredientCollection.Find(new BsonDocument()).ToList();
            _logger.LogInformation($"Number of items returned: {ingredients.Count}");
            System.Console.WriteLine(ingredients);
            return ingredients;
        }
        catch (Exception ex)
        {
            _logger.LogError($"An error occurred: {ex.Message}");
            throw; // Rethrow the exception for now; modify as needed
        }
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        FilterDefinition<Ingredients> filter = Builders<Ingredients>.Filter.Eq("IngredientId", id);
        var ingredientCollection = _mongoDatabase.GetCollection<Ingredients>(nameof(Ingredients));
        var ingredients = await ingredientCollection.Find(filter).FirstOrDefaultAsync();
        if (ingredients == null)
        {
            return NotFound();
        }
        else
        {
            return Ok(ingredients);
        }
    }


    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Ingredients ingredientses)
    {
        await _mongoDatabase.GetCollection<Ingredients>(nameof(Ingredients)).InsertOneAsync(ingredientses);
        return CreatedAtAction(nameof(Get), new { id = ingredientses.IngredientId }, ingredientses);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> ModifyIngredient(string id, [FromBody] IngredientPUTDto IngredientPUTDto)
    {
        FilterDefinition<Ingredients> filter = Builders<Ingredients>.Filter.Eq("IngredientId", id);
        UpdateDefinition<Ingredients> update = Builders<Ingredients>.Update.Set(c => c.Name, IngredientPUTDto.Name)
            .Set(c => c.Photo_url, IngredientPUTDto.Photo_url)
            .Set(c => c.Quantite, IngredientPUTDto.Quantite);
        var result = await _mongoDatabase.GetCollection<Ingredients>(nameof(Ingredients))
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

    [HttpDelete("{id}")]
    public IActionResult Delete(string id)
    {
        FilterDefinition<Ingredients> filter = Builders<Ingredients>.Filter.Eq("IngredientId", id);
        var result = _mongoDatabase.GetCollection<Ingredients>(nameof(Ingredients)).DeleteOne(filter);
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