﻿using Microsoft.AspNetCore.Mvc;
using MyPizzaRestaurant.Data;
using MyPizzaRestaurant.Models;
using System.Runtime.CompilerServices;

namespace MyPizzaRestaurant.Controllers
{
    public class IngredientController : Controller
    {
        private Repository<Ingredient> ingedients;

        public IngredientController(ApplicationDbContext context)
        {
            ingedients = new(context);
        }

        public async Task<IActionResult> Index()
        {
            return View(await ingedients.GetAllAsync());
        }

        public async Task<IActionResult> Details(int id)
        {
            return View(await ingedients.GetByIdAsync(id, new() { Includes = "ProductIngredients.Product" }));
        }
    }
}
