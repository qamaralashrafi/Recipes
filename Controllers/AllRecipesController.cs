using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RecipeBook.Models;
using RecipeBook.Models.Data;

namespace RecipeBook.Controllers
{
    public class AllRecipesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AllRecipesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AllRecipes
        
        public async Task<IActionResult> Index()
        {
              return _context.allrecipes != null ? 
                          View(await _context.allrecipes.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.allrecipes'  is null.");
        }

        // GET: AllRecipes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.allrecipes == null)
            {
                return NotFound();
            }

            var allRecipes = await _context.allrecipes
                .FirstOrDefaultAsync(m => m.ID == id);
            if (allRecipes == null)
            {
                return NotFound();
            }

            return View(allRecipes);
        }

        // GET: AllRecipes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AllRecipes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,RecipeName,RecipeIngredients,RecipeSteps,RecipeTime,RecipeDate,RecipeImage")] AllRecipes allRecipes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(allRecipes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(allRecipes);
        }

        // GET: AllRecipes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.allrecipes == null)
            {
                return NotFound();
            }

            var allRecipes = await _context.allrecipes.FindAsync(id);
            if (allRecipes == null)
            {
                return NotFound();
            }
            return View(allRecipes);
        }

        // POST: AllRecipes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ID,RecipeName,RecipeIngredients,RecipeSteps,RecipeTime,RecipeDate,RecipeImage")] AllRecipes allRecipes)
        {
            if (id != allRecipes.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(allRecipes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AllRecipesExists(allRecipes.ID))
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
            return View(allRecipes);
        }

        // GET: AllRecipes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.allrecipes == null)
            {
                return NotFound();
            }

            var allRecipes = await _context.allrecipes
                .FirstOrDefaultAsync(m => m.ID == id);
            if (allRecipes == null)
            {
                return NotFound();
            }

            return View(allRecipes);
        }

        // POST: AllRecipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.allrecipes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.allrecipes'  is null.");
            }
            var allRecipes = await _context.allrecipes.FindAsync(id);
            if (allRecipes != null)
            {
                _context.allrecipes.Remove(allRecipes);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AllRecipesExists(string id)
        {
          return (_context.allrecipes?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
