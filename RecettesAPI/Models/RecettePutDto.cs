using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace RecettesAPI.Models;

public class RecettePutDto
{
   [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
   
    public string? Title { get; set; }
    public string? Photo_url { get; set; }
    public string? Time { get; set; }
    public string? Description { get; set; }
    public string[]? PhotosArray { get; set; }
   public List<Ingredients>? Ingredients { get; set; } 
}