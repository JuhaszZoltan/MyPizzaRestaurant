using Microsoft.AspNetCore.Mvc;
using MyPizzaRestaurant.Data;
using MyPizzaRestaurant.Models;

namespace MyPizzaRestaurant.Controllers
{
    public class ProductController : Controller
    {
        private Repository<Product> products;
        private QueryOptiopns<Product> options;

        public ProductController(ApplicationDbContext context)
        {
            products = new(context);
            options = null; //:::TODO:::
        }

        public async Task<IActionResult> Index()
        {
            return View(await products.GetAllAsync());
        }

        public async Task<IActionResult> Details(int id)
        {
            return View(await products.GetByIdAsync(id, options));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind(/*TODO*/)] Product product)
        {
            if (ModelState.IsValid)
            {
                await products.AddAsync(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            return View(await products.GetByIdAsync(id, options));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Product product)
        {
            await products.DeleteAsync(product.ProductId);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            return View(await products.GetByIdAsync(id, options));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                await products.UpdateAsync(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }
    }
}
