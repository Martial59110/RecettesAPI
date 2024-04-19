using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace RecettesAPI.Models;

public class IngredientPUTDto
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Name { get; set; }
    public string? Photo_url { get; set; }
    public string? Quantite {get; set;}
}