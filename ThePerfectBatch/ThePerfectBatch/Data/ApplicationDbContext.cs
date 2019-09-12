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
                    DateCreated = DateTime.Now,
                    Instructions = "1. Beat egg, vanilla and cinnamon in shallow dish. Stir in milk. 2. Dip bread in egg mixture, turning to coat both sides evenly. 3. Cook bread slices on lightly greased nonstick griddle or skillet on medium heat until browned on both sides."
                },
                new Recipe()
                {
                    RecipeId = 2,
                    RecipeTypeId = 2,
                    UserId = user.Id,
                    Name = "Crepes",
                    Image = "images/ChickpeaCrepe.jpg",
                    DateCreated = DateTime.Now,
                    Instructions = "1. In a blender, combine the garbanzo bean flour, water, salt and garlic powder. Blend on high until smooth. Allow to sit while you heat the skillet. " +
                    "2. Lightly grease a large non-stick skillet and warm over medium-high heat. Pour in 1/4th of the batter at a time and cook until the edges start to bubble, about 3 minutes. Carefully flip and cook the opposite side until firm. Continue this step until you have 4 crepes. 3. Top each crepe with hummus, avocado, carrots, and 50/50 mixed greens. Serve with ranch dressing and enjoy!"
                },
                new Recipe()
                {
                    RecipeId = 3,
                    RecipeTypeId = 3,
                    UserId = user.Id,
                    Name = "Grilled Cheese",
                    Image = "images/GrilledCheese.jpg",
                    DateCreated = DateTime.Now,
                    Instructions = "Preheat skillet over medium heat. Generously butter one side of a slice of bread. Place bread butter-side-down onto skillet bottom and add 1 slice of cheese. Butter a second slice of bread on one side and place butter-side-up on top of sandwich. Grill until lightly browned and flip over; continue grilling until cheese is melted. Repeat with remaining 2 slices of bread, butter and slice of cheese."
                },
                new Recipe()
                {
                    RecipeId = 4,
                    RecipeTypeId = 4,
                    UserId = user.Id,
                    Name = "Chicken Parmesean",
                    Image = "images/ChickenParm.jpg",
                    DateCreated = DateTime.Now,
                    Instructions = "1. Preheat an oven to 450 degrees F (230 degrees C). 2. Place chicken breasts between two sheets of heavy plastic (resealable freezer bags work well) on a solid, level surface. Firmly pound chicken with the smooth side of a meat mallet to a thickness of 1/2-inch. Season chicken thoroughly with salt and pepper. 3. Beat eggs in a shallow bowl and set aside. 4. Mix bread crumbs and 1/2 cup Parmesan cheese in a separate bowl, set aside. 5. Place flour in a sifter or strainer; sprinkle over chicken breasts, evenly coating both sides. 6. Dip flour coated chicken breast in beaten eggs. Transfer breast to breadcrumb mixture, pressing the crumbs into both sides. Repeat for each breast. Set aside breaded chicken breasts for about 15 minutes. 7. Heat 1 cup olive oil in a large skillet on medium-high heat until it begins to shimmer. Cook chicken until golden, about 2 minutes on each side. The chicken will finish cooking in the oven. 8. Place chicken in a baking dish and top each breast with about 1/3 cup of tomato sauce. Layer each chicken breast with equal amounts of mozzarella cheese, fresh basil, and provolone cheese. Sprinkle 1 to 2 tablespoons of Parmesan cheese on top and drizzle with 1 tablespoon olive oil. 9. Bake in the preheated oven until cheese is browned and bubbly, and chicken breasts are no longer pink in the center, 15 to 20 minutes. An instant-read thermometer inserted into the center should read at least 165 degrees F (74 degrees C)."
                },
                new Recipe()
                {
                    RecipeId = 5,
                    RecipeTypeId = 5,
                    UserId = user.Id,
                    Name = "Chocolate Chip Cookies",
                    Image = "images/ChocolateChipCookie.jpg",
                    DateCreated = DateTime.Now,
                    Instructions = "1. Preheat oven to 350 degrees F (175 degrees C). 2. Cream together the butter, white sugar, and brown sugar until smooth. Beat in the eggs one at a time, then stir in the vanilla. Dissolve baking soda in hot water. Add to batter along with salt. Stir in flour, chocolate chips, and nuts. Drop by large spoonfuls onto ungreased pans. 3. Bake for about 10 minutes in the preheated oven, or until edges are nicely browned."
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
