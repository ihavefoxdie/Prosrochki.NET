using Microsoft.AspNetCore.Mvc;
using Prosrochki.NET.Models;
using Prosrochki.NET.Services;

namespace Prosrochki.NET.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
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

        public IActionResult Create(ProductModel product)
        {
            ProductDAO productDAO = new ProductDAO();
            productDAO.Insert(product);
            return View("Index", productDAO.GetAllProducts());
        }

        public IActionResult CreateForm()
        {
            return View();
        }

        public IActionResult ShowDetails(int Id)
        {
            ProductDAO productsDAO = new ProductDAO();
            ProductModel foundProduct = productsDAO.GetProductById(Id); 
            return View(foundProduct);
        }

        public IActionResult Delete(int Id)
        {
            ProductDAO productsDAO = new ProductDAO();
            productsDAO.Delete(Id);
            return RedirectToAction("Index");
        }

        public IActionResult EditForm(int Id)
        {
            ProductDAO productsDAO = new ProductDAO();
            ProductModel foundProduct = productsDAO.GetProductById(Id);
            return View("EditForm", foundProduct);
        }

        public IActionResult ProcessEdit(ProductModel product)
        {
            ProductDAO productDAO = new ProductDAO();
            productDAO.Update(product);
            return RedirectToAction("Index");
        }
    }
}
