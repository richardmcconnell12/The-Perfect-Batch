using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ThePerfectBatch.Data;
using ThePerfectBatch.Models;

namespace ThePerfectBatch.Controllers
{
    public class RecipesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public RecipesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        // GET: Recipes
        public async Task<IActionResult> Index(string recipe)
        {
                var RecipeWithIngredients = _context.Recipe
                    .Include(r => r.Ingredients)
                    .Include(u => u.User).ToList();

            if (!String.IsNullOrEmpty(recipe))
            {
                RecipeWithIngredients =  RecipeWithIngredients.Where(r => r.Name.Contains(recipe)).ToList();
            }
                return View(RecipeWithIngredients);
        }

        // GET: Recipes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var RecipeWithIngredients = await _context.Recipe
                .Include(r => r.Ingredients)
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.RecipeId == id);
            if (RecipeWithIngredients == null)
            {
                return NotFound();
            }

            return View(RecipeWithIngredients);
        }
        [Authorize]
        // GET: Recipes/Create
        public IActionResult Create()
        {
            ViewData["RecipeTypeId"] = new SelectList(_context.RecipeType, "RecipeTypeId", "Name");
            var recipe = new Recipe();
            var ingredient1 = new Ingredient();
            var ingredient2 = new Ingredient();

            var ingredientsList = new List<Ingredient>();
     
            ingredientsList.Add(ingredient1);
            ingredientsList.Add(ingredient2);

            recipe.Ingredients = ingredientsList; 
            return View(recipe);
        }

        // POST: Recipes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [RequestSizeLimit(5 * 1024 * 1024)]
        public async Task<IActionResult> Create([Bind("RecipeId,RecipeTypeId,Name,DateCreated,Quantity,Image,Ingredients,Instructions")] Recipe recipe, IFormFile file)
        {
            var path = Path.Combine(
                Directory.GetCurrentDirectory(), "wwwroot",
                "images", file.FileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            ApplicationUser user = await GetCurrentUserAsync();
            recipe.UserId = user.Id;
            recipe.Image = "images/" + file.FileName;

            ModelState.Remove("User");
            ModelState.Remove("UserId");
            if (ModelState.IsValid)
            {
                _context.Add(recipe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RecipeTypeId"] = new SelectList(_context.RecipeType, "RecipeTypeId", "Label", recipe.RecipeTypeId);
            return View(recipe);
        }
        [Authorize]
        // GET: Recipes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var user = await GetUserAsync();
            var recipeWithIngredients = await _context.Recipe
                .Include(r => r.Ingredients)
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.RecipeId == id);

            if (recipeWithIngredients == null || user.Id != recipeWithIngredients.UserId)
            {
                return NotFound();
            }
            return View(recipeWithIngredients);
        }

        // POST: Recipes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RecipeId,RecipeTypeId,Name,DateCreated,Quantity,Image,Ingredients,Instructions")] Recipe recipe)
        {
            if (id != recipe.RecipeId)
            {
                return NotFound();
            }
            ModelState.Remove("User");
            ModelState.Remove("UserId");
            if (ModelState.IsValid)
            {
                ApplicationUser user = await GetUserAsync();
                recipe.UserId = user.Id;
                try
                {
                    _context.Update(recipe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecipeExists(recipe.RecipeId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Ingredients"] = new SelectList(_context.Ingredients, "IngredientId", "Label", recipe.Ingredients);
            return View(recipe);
        }
        [Authorize]
        // GET: Recipes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var user = await GetCurrentUserAsync();
            var recipe = await _context.Recipe
                .Include(r => r.RecipeType)
                .FirstOrDefaultAsync(m => m.RecipeId == id);

            if (recipe == null || user.Id != recipe.UserId)
            {
                return NotFound();
            }

            return View(recipe);
        }

        // POST: Recipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recipe = await _context.Recipe.FindAsync(id);
            _context.Recipe.Remove(recipe);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private Task<ApplicationUser> GetUserAsync()
        {
            return _userManager.GetUserAsync(HttpContext.User);
        }

        private async Task<bool> WasCreatedByUser(Recipe recipe)
        {
            var user = await GetUserAsync();
            return recipe.UserId == user.Id;
        }

        private bool RecipeExists(int? id)
        {
            return _context.Recipe.Any(e => e.RecipeId == id);
        }
    }
}
