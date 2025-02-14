using Microsoft.AspNetCore.Mvc;
using MyPizzaRestaurant.Data;
using MyPizzaRestaurant.Models;
using System.Runtime.CompilerServices;

namespace MyPizzaRestaurant.Controllers
{
    public class IngredientController : Controller
    {
        private Repository<Ingredient> ingredients;

        private QueryOptiopns<Ingredient> options;

        public IngredientController(ApplicationDbContext context)
        {
            ingredients = new(context);
            options = new()
            {
                Includes = "ProductIngredients.Product"
            };

        }

        public async Task<IActionResult> Index()
        {
            return View(await ingredients.GetAllAsync());
        }

        public async Task<IActionResult> Details(int id)
        {
            return View(await ingredients.GetByIdAsync(id, options));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IngredientId, Name")]Ingredient ingredient)
        {
            if (ModelState.IsValid)
            {
                await ingredients.AddAsync(ingredient);
                return RedirectToAction("Index");
            }
            return View(ingredient);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            return View(await ingredients.GetByIdAsync(id, options));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Ingredient ingredient)
        {
            await ingredients.DeleteAsync(ingredient.IngredientId);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            return View(await ingredients.GetByIdAsync(id, options));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Ingredient ingredient)
        {
            if(ModelState.IsValid)
            {
                await ingredients.UpdateAsync(ingredient);
                return RedirectToAction("Index");
            }
            return View(ingredient);
        }
    }
}
