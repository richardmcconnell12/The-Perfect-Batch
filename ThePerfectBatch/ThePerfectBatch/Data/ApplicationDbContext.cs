using System;
using System.Collections.Generic;
using System.Text;
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
    }
}
