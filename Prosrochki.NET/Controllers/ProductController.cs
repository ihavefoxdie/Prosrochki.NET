using Microsoft.AspNetCore.Mvc;
using Prosrochki.NET.Models;
using Prosrochki.NET.Services;

namespace Prosrochki.NET.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            HardCodedDataRepository hardCodedDataRepository = new HardCodedDataRepository();
            ProductDAO productDAO = new ProductDAO();
            return View(productDAO.GetAllProducts());
        }

        public IActionResult SearchResults(string searchTerm)
        {
            ProductDAO productDAO = new ProductDAO();
            List<ProductModel> products = productDAO.SearchProducts(searchTerm);
            return View("Index", products);
        }

        public IActionResult SearchForm()
        {
            return View();
        }
    }
}
