using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ThePerfectBatch.Models;

namespace ThePerfectBatch.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ThePerfectBatch.Models.Recipe> Recipe { get; set; }
        public DbSet<ThePerfectBatch.Models.RecipeType> RecipeType { get; set; }
        public DbSet<ThePerfectBatch.Models.Ingredient> Ingredients { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Intitial user seeding 
            modelBuilder.Entity<Recipe>()
                .Property(d => d.DateCreated)
                .HasDefaultValueSql("getdate()");

            ApplicationUser user = new ApplicationUser
            {
                FirstName = "Ricky",
                LastName = "McConnell",
                Email = "mr.mcconnell@internet.com",
                NormalizedEmail = "MR.MCCONNELL@INTERNET.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = "7f434309-a4d9-48e9-9ebb-8803db794577",
                Id = "00000000-ffff-ffff-ffff-ffffffffffff"
            };
            var passwordHash = new PasswordHasher<ApplicationUser>();
            user.PasswordHash = passwordHash.HashPassword(user, "Abc123!");
            modelBuilder.Entity<ApplicationUser>().HasData(user);

            modelBuilder.Entity<RecipeType>().HasData(
                new RecipeType()
                {
                    RecipeTypeId = 1,
                    Name = "Breakfast"
                },
                new RecipeType()
                {
                    RecipeTypeId = 2,
                    Name = "Brunch"
                },
                new RecipeType()
                {
                    RecipeTypeId = 3,
                    Name = "Lunch"
                },
                new RecipeType()
                {
                    RecipeTypeId = 4,
                    Name = "Dinner"
                },
                new RecipeType()
                {
                    RecipeTypeId = 5,
                    Name = "Desert"
                }
            );

            // Initial Recipe Seeding
            modelBuilder.Entity<Recipe>().HasData(
                new Recipe()
                {
                    RecipeId = 1,
                    RecipeTypeId = 1,
                    UserId = user.Id,
                    Name = "French Toast",
                    Image = "images/FrenchToast.jpg",
                    DateCreated = DateTime.Now
                },
                new Recipe()
                {
                    RecipeId = 2,
                    RecipeTypeId = 2,
                    UserId = user.Id,
                    Name = "Crepes",
                    Image = "images/ChickpeaCrepe.jpg",
                    DateCreated = DateTime.Now,

                },
                new Recipe()
                {
                    RecipeId = 3,
                    RecipeTypeId = 3,
                    UserId = user.Id,
                    Name = "Grilled Cheese",
                    Image = "images/GrilledCheese.jpg",
                    DateCreated = DateTime.Now
                },
                new Recipe()
                {
                    RecipeId = 4,
                    RecipeTypeId = 4,
                    UserId = user.Id,
                    Name = "Chicken Parmesean",
                    Image = "images/ChickenParm.jpg",
                    DateCreated = DateTime.Now
                },
                new Recipe()
                {
                    RecipeId = 5,
                    RecipeTypeId = 5,
                    UserId = user.Id,
                    Name = "Chocolate Chip Cookies",
                    Image = "images/ChocolateChipCookie.jpg",
                    DateCreated = DateTime.Now
                }
            );

            modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient()
                {
                    IngredientId = 1,
                    RecipeId = 1,
                    Name = "Egg",
                    Quantity = "1"
                },
                new Ingredient()
                {
                    IngredientId = 2,
                    RecipeId = 1,
                    Name = "Vanilla Extract",
                    Quantity = "1 Tsp"
                },
                new Ingredient()
                {
                    IngredientId = 3,
                    RecipeId = 1,
                    Name = "Cinnimon Grounds",
                    Quantity = "1/2 Tsp"
                },
                new Ingredient()
                {
                    IngredientId = 4, 
                    RecipeId = 1,
                    Name = "Milk",
                    Quantity = "1/4 Cup of Milk"
                },
                new Ingredient()
                {
                    IngredientId = 5,
                    RecipeId = 1,
                    Name = "Bread",
                    Quantity = "4 Slices"
                },
                new Ingredient()
                {
                    IngredientId = 6,
                    RecipeId = 2,
                    Name = "Chickpea Flour",
                    Quantity = "1 Cup"
                }, 
                new Ingredient()
                {
                    IngredientId = 7,
                    RecipeId = 2,
                    Name = "Water",
                    Quantity = "1 and 1/4 Cups"
                }, 
                new Ingredient()
                {
                    IngredientId = 8,
                    RecipeId = 2,
                    Name = "Lemon Juice",
                    Quantity = "1 Tbsp"
                },
                new Ingredient()
                {
                    IngredientId = 9,
                    RecipeId = 2,
                    Name = "Salt",
                    Quantity = "1/2 Tsp"
                },
                new Ingredient()
                {
                    IngredientId = 10,
                    RecipeId = 3,
                    Name = "Bread",
                    Quantity = "2 Slices"
                },
                new Ingredient()
                {
                    IngredientId = 11,
                    RecipeId = 3,
                    Name = "Butter",
                    Quantity = "1 Tbsp"
                },
                new Ingredient()
                {
                    IngredientId = 12,
                    RecipeId = 3,
                    Name = "Cheese of Choice",
                    Quantity = "2 Slices"
                },
                new Ingredient()
                {
                    IngredientId = 13,
                    RecipeId = 4,
                    Name = "Skinless Chicken Breast",
                    Quantity = "4"
                },
                new Ingredient()
                {
                    IngredientId = 14,
                    RecipeId = 4,
                    Name = "Salt and Pepper",
                    Quantity = "To Taste"
                },
                new Ingredient()
                {
                    IngredientId = 15,
                    RecipeId = 4,
                    Name = "Eggs",
                    Quantity = "2"
                },
                new Ingredient()
                {
                    IngredientId = 16,
                    RecipeId = 4,
                    Name = "Bread Crumbs",
                    Quantity = "1 and 1/4 Cup"
                },
                new Ingredient()
                {
                    IngredientId = 17,
                    RecipeId = 4,
                    Name = "Grated Parmesean Cheese",
                    Quantity = "1/2 Cup"
                },
                new Ingredient()
                {
                    IngredientId = 18,
                    RecipeId = 4,
                    Name = "Flour",
                    Quantity = "2 Tbsp"
                },
                new Ingredient()
                {
                    IngredientId = 19,
                    RecipeId = 4,
                    Name = "Olive Oil for Frying",
                    Quantity = "1 Cup"
                },
                new Ingredient()
                {
                    IngredientId = 20,
                    RecipeId = 4,
                    Name = "Tomato Sauce",
                    Quantity = "1/2 Cup"
                },
                new Ingredient()
                {
                    IngredientId = 21,
                    RecipeId = 4,
                    Name = "Cubed Mozzarella",
                    Quantity = "1/4 Cup"
                },
                new Ingredient()
                {
                    IngredientId = 22,
                    RecipeId = 4,
                    Name = "Basil",
                    Quantity = "1/4 Cup"
                },
                new Ingredient()
                {
                    IngredientId = 23,
                    RecipeId = 4,
                    Name = "Provolone Cheese",
                    Quantity = "1/2 Cup"
                },
                new Ingredient()
                {
                    IngredientId = 24,
                    RecipeId = 4,
                    Name = "Grated Parmesean Cheese",
                    Quantity = "1/2 Cup"
                },
                new Ingredient()
                {
                    IngredientId = 25,
                    RecipeId = 4,
                    Name = "Olive Oil",
                    Quantity = "1 Tbsp"
                },
                new Ingredient()
                {
                    IngredientId = 26,
                    RecipeId = 5,
                    Name = "Butter",
                    Quantity = "1 Cup"
                },
                new Ingredient()
                {
                    IngredientId = 27,
                    RecipeId = 5,
                    Name = "White Sugar",
                    Quantity = "1 Cup"
                },
                new Ingredient()
                {
                    IngredientId = 28,
                    RecipeId = 5,
                    Name = "Brown Sugar",
                    Quantity = "1 Cup"
                },
                new Ingredient()
                {
                    IngredientId = 29,
                    RecipeId = 5,
                    Name = "Egg",
                    Quantity = "2"
                },
                new Ingredient()
                {
                    IngredientId = 30,
                    RecipeId = 5,
                    Name = "Vanilla extract",
                    Quantity = "2 Tsp"
                },
                new Ingredient()
                {
                    IngredientId = 31,
                    RecipeId = 5,
                    Name = "Baking Soda",
                    Quantity = "1 Tsp"
                },
                new Ingredient()
                {
                    IngredientId = 32,
                    RecipeId = 5,
                    Name = "Hot Water",
                    Quantity = "1 Tsp"
                },
                new Ingredient()
                {
                    IngredientId = 33,
                    RecipeId = 5,
                    Name = "Salt",
                    Quantity = "1/2 Tsp"
                },
                new Ingredient()
                {
                    IngredientId = 34,
                    RecipeId = 5,
                    Name = "Flour",
                    Quantity = "3 Cups"
                },
                new Ingredient()
                {
                    IngredientId = 35,
                    RecipeId = 5,
                    Name = "Chocolate Chips",
                    Quantity = "2 Cups"
                },
                new Ingredient()
                {
                    IngredientId = 36,
                    RecipeId = 5,
                    Name = "Chopped Walnuts",
                    Quantity = "1 Cup"
                }
            );
        }
    }
}
