using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;


namespace RecettesAPI.Models;

public class Categories
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id_categorie {get;set;}
    public string? Name {get;set;}
    public string? Photourl {get;set;}
}
