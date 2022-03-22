using Prosrochki.NET.Models;

namespace Prosrochki.NET.Services
{
    public class HardCodedDataRepository : IProductDataService
    {
        List<ProductModel> products = new List<ProductModel>();

        public int Delete(ProductModel product)
        {
            throw new NotImplementedException();
        }

        public List<ProductModel> GetAllProducts()
        {
            products.Add(new ProductModel { Id = 1, Name = "Pilk", Amount = 2, Weight = 2.5m, DateProduced = DateTime.Now });

            return products;
        }

        public List<ProductModel> GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(ProductModel product)
        {
            throw new NotImplementedException();
        }

        public List<ProductModel> SearchProducts(string searchTerm)
        {
            throw new NotImplementedException();
        }

        public int Update(ProductModel product)
        {
            throw new NotImplementedException();
        }
    }
}
