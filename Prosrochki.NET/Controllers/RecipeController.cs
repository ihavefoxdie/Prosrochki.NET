using Microsoft.AspNetCore.Mvc;
using Prosrochki.NET.Models;
using Prosrochki.NET.Services;
using System.Dynamic;

namespace Prosrochki.NET.Controllers
{
    public class RecipeController : Controller
    {
        public IActionResult Index()
        {
            RecipeDAO recipe = new RecipeDAO();
            return View(recipe.GetAllRecipes());
        }

        public IActionResult Create()
        {
            return View();
        }



        public IActionResult CreateForm()
        {
            ProductDAO productDAO = new ProductDAO();
            dynamic mymodel = new ExpandoObject();
            mymodel.Products = productDAO.GetAllProducts();
            
            return View(mymodel);
        }
    }
}
