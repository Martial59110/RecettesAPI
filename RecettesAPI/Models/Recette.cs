using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;



namespace RecettesAPI.Models;

public class Recette
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? RecipeId { get; set; }
    
    [ForeignKey("Id_categorie")]
    public string? Id_categorie { get; set; }
    public string? Title { get; set; }
    public string? Photo_url { get; set; }
    public string? Time { get; set; }
    public string? Description { get; set; }
    public string[]? PhotosArray { get; set; }
   public List<Ingredients>? Ingredients { get; set; } // Modifiez la propriété Ingredients
}
