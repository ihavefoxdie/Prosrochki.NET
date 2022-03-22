using Prosrochki.NET.Models;

namespace Prosrochki.NET.Services
{
    public interface IProductDataService
    {
        List<ProductModel> GetAllProducts();

        List<ProductModel> SearchProducts(string searchTerm);

        List<ProductModel> GetProductById(int id);

        int Insert(ProductModel product);
        int Update(ProductModel product);
        int Delete(ProductModel product);
    }
}
