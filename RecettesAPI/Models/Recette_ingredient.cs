using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace RecettesAPI.Models;
public class RecetteIngredient
{
    [Key]
    public int RecetteIngredientId { get; set; }

    public int RecetteId { get; set; }

    [ForeignKey("RecetteId")]
    public Recette? Recette { get; set; }

    public int IngredientId { get; set; }

    [ForeignKey("IngredientId")]
    public Ingredients? Ingredient { get; set; }
}