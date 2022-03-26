using Prosrochki.NET.Models;

namespace Prosrochki.NET.Services
{
    public interface IProductDataService
    {
        List<ProductModel> GetAllProducts();

        List<ProductModel> SearchProducts(string searchTerm);

        ProductModel GetProductById(int id);

        void Insert(ProductModel product);
        int Update(ProductModel product);
        int Delete(int Id);
    }
}
