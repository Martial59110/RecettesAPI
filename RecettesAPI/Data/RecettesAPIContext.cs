
using Microsoft.EntityFrameworkCore;
using RecettesAPI.Models;

namespace RecettesAPI.Data;

    public class ApplicationDbContext : DbContext
    {
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Recette> Recettes { get; set; }
        public DbSet<Ingredients> Ingredients { get; set; }
        public DbSet<RecetteIngredient> RecetteIngredients { get; set; }

       
    }
        