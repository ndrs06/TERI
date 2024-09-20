using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using TERI_api.Data;
using TERI_api.Model.DataModel;

namespace TERI_integrationtest;

public class TERI_WebAppFactory : WebApplicationFactory<Program>
{
    private readonly string _dbTERI = Guid.NewGuid().ToString();

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(s =>
        {
            var teriDbContextDescription = s.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<TERI_Context>));

            if (teriDbContextDescription != null)
            {
                s.Remove(teriDbContextDescription);
            }

            s.AddDbContext<TERI_Context>(o =>
            {
                o.UseInMemoryDatabase(_dbTERI);
            });

            using var scope = s.BuildServiceProvider().CreateScope();
            
            var teriContext = scope.ServiceProvider.GetRequiredService<TERI_Context>();
            teriContext.Database.EnsureDeleted();
            teriContext.Database.EnsureCreated();

            // SeedData(teriContext);
        });
    }
    
    private void SeedData(TERI_Context context)
    {
        #region Users

        var user1 = new User
        {
            Id = 0,
            RegistrationDate = DateTime.Today,
            Name = "user1",
            Inventory = new Inventory
            {
                Id = 0,
                UserId = 0,
                IngredientSlots = new List<InventoryIngredientSlot>()
                {new ()
                    {
                        Id = 0,
                        Name = "0_IngredientSlot"
                    }
                },
                FoodSlots = new List<InventoryFoodSlot>()
            }
        };
        

        #endregion
        
        context.Users.AddRange();
        context.Recipes.AddRange();
        
        context.SaveChanges();
    }
}