using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace RecettesAPI.Models;

public class CategoriePutDto
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Name {get;set;}
    public string? Photourl {get;set;}
}