using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyPizzaRestaurant.Models;

namespace MyPizzaRestaurant.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductIngredient> ProductIngredients { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<ProductIngredient>()
            .HasKey(pi => new { pi.ProductId, pi.IngredientId });

        builder.Entity<ProductIngredient>()
            .HasOne(pi => pi.Product)
            .WithMany(p => p.ProductIngredients)
            .HasForeignKey(pi => pi.ProductId);

        builder.Entity<ProductIngredient>()
            .HasOne(pi => pi.Ingredient)
            .WithMany(i => i.ProductIngredients)
            .HasForeignKey(pi => pi.IngredientId);

        //SEED
        builder.Entity<Category>().HasData(
            new Category { CategoryId = 1, Name = "Appetizer"},
            new Category { CategoryId = 2, Name = "Entree"},
            new Category { CategoryId = 3, Name = "Side Dish"},
            new Category { CategoryId = 4, Name = "Dessert"},
            new Category { CategoryId = 5, Name = "Beverage"});

        builder.Entity<Ingredient>().HasData(
            new Ingredient { IngredientId = 1, Name = "Dough" },
            new Ingredient { IngredientId = 2, Name = "Mozzarella" },
            new Ingredient { IngredientId = 3, Name = "Tomato Sauce" },
            new Ingredient { IngredientId = 4, Name = "Black Forest Ham" },
            new Ingredient { IngredientId = 5, Name = "Prama Ham" },
            new Ingredient { IngredientId = 6, Name = "Bacon" },
            new Ingredient { IngredientId = 7, Name = "Mushroom" },
            new Ingredient { IngredientId = 8, Name = "Onion" },
            new Ingredient { IngredientId = 9, Name = "Seefood" },
            new Ingredient { IngredientId = 10, Name = "Corn" },
            new Ingredient { IngredientId = 11, Name = "Cream" },
            new Ingredient { IngredientId = 12, Name = "Chicken Breast" });

        builder.Entity<Product>().HasData(
            new Product
            {
                ProductId = 1,
                Name = "Margherita",
                Description = "A delicious Margherita pizza",
                Price = 9.99m,
                Stock = 100,
                CategoryId = 2,
            },
            new Product
            {
                ProductId = 2,
                Name = "Four Seasons",
                Description = "A delicious Four Seasons pizza",
                Price = 12.49m,
                Stock = 75,
                CategoryId = 2,
            },
            new Product
            {
                ProductId = 3,
                Name = "Mafia",
                Description = "A delicious Mafia pizza",
                Price = 13.29m,
                Stock = 17,
                CategoryId = 2,
            },
            new Product
            {
                ProductId = 4,
                Name = "Kappan",
                Description = "A delicious Kappan pizza",
                Price = 11.29m,
                Stock = 67,
                CategoryId = 2,
            });

        builder.Entity<ProductIngredient>().HasData(
            new ProductIngredient { ProductId = 1, IngredientId = 1 },
            new ProductIngredient { ProductId = 1, IngredientId = 2 },
            new ProductIngredient { ProductId = 1, IngredientId = 3 },
            new ProductIngredient { ProductId = 2, IngredientId = 1 },
            new ProductIngredient { ProductId = 2, IngredientId = 2 },
            new ProductIngredient { ProductId = 2, IngredientId = 3 },
            new ProductIngredient { ProductId = 2, IngredientId = 5 },
            new ProductIngredient { ProductId = 2, IngredientId = 7 },
            new ProductIngredient { ProductId = 2, IngredientId = 10 },
            new ProductIngredient { ProductId = 3, IngredientId = 1 },
            new ProductIngredient { ProductId = 3, IngredientId = 2 },
            new ProductIngredient { ProductId = 3, IngredientId = 6 },
            new ProductIngredient { ProductId = 3, IngredientId = 10 },
            new ProductIngredient { ProductId = 3, IngredientId = 11 },
            new ProductIngredient { ProductId = 4, IngredientId = 1 },
            new ProductIngredient { ProductId = 4, IngredientId = 2 },
            new ProductIngredient { ProductId = 4, IngredientId = 10 },
            new ProductIngredient { ProductId = 4, IngredientId = 11 },
            new ProductIngredient { ProductId = 4, IngredientId = 12 });
    }

}
