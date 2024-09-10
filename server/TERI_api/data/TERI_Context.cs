using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using TERI_api.Model.DataModel;

namespace TERI_api.Data;

public class TERI_Context : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<Inventory> Inventories { get; set; }
    public DbSet<InventoryFoodSlot> InventoryFoodSlot { get; set; }
    public DbSet<InventoryIngredientSlot> InventoryIngredientSlot { get; set; }
    public DbSet<Food> Foods { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }

    public TERI_Context(DbContextOptions<TERI_Context> options) : base(options)
    {
        if (Database.GetService<IDatabaseCreator>() is RelationalDatabaseCreator databaseCreator)
        {
            if (!databaseCreator.CanConnect()) databaseCreator.Create();
            if (!databaseCreator.HasTables()) databaseCreator.CreateTables();
        }
    }
}