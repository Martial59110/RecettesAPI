using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace RecettesAPI.Models;

public class Ingredients
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? IngredientId { get; set; }
    public string? Name { get; set; }
    public string? Photo_url { get; set; }
    public string? Quantite {get; set;}
}
