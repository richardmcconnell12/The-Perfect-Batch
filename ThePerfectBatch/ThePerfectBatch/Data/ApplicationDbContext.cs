using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ThePerfectBatch.Models;

namespace ThePerfectBatch.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ThePerfectBatch.Models.Recipe> Recipe { get; set; }
        public DbSet<ThePerfectBatch.Models.RecipeType> RecipeType { get; set; }
        public DbSet<ThePerfectBatch.Models.Ingredients> Ingredients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Intitial user seeding 

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
                    DateCreated = DateTime.Now
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

            //modelBuilder.Entity<Ingredients>().HasData(
            //    new Ingredients()
            //    {

            //    }
            //);
        }
    }
}
