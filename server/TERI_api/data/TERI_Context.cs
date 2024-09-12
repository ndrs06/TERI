using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using TERI_api.Model.DataModel;

namespace TERI_api.Data;

public class TERI_Context : IdentityDbContext<IdentityUser, IdentityRole, string>
{
    public DbSet<User> Users { get; set; }
    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<RecipeCategory> RecipeCategories { get; set; }
    public DbSet<Inventory> Inventories { get; set; }
    public DbSet<InventoryFoodSlot> InventoryFoodSlot { get; set; }
    public DbSet<InventoryIngredientSlot> InventoryIngredientSlot { get; set; }
    public DbSet<Meal> Meals { get; set; }
    public DbSet<Food> Foods { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<IngredientCategory> IngredientCategories { get; set; }

    public TERI_Context(DbContextOptions<TERI_Context> options) : base(options)
    {
        if (Database.GetService<IDatabaseCreator>() is RelationalDatabaseCreator databaseCreator)
        {
            if (!databaseCreator.CanConnect()) databaseCreator.Create();
            if (!databaseCreator.HasTables()) databaseCreator.CreateTables();
        }
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<User>()
            .HasOne(u => u.IdentityUser)
            .WithMany()
            .HasForeignKey(u => u.IdentityEmail)
            .HasPrincipalKey(iu => iu.Email);
    }
}