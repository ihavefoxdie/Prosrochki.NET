using Prosrochki.NET.Models;
using System.Data.SqlClient;

namespace Prosrochki.NET.Services
{
    public class ProductDAO : IProductDataService
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Test;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        
        public int Delete(ProductModel product)
        {
            throw new NotImplementedException();
        }

        public List<ProductModel> GetAllProducts()
        {
            List<ProductModel> products = new List<ProductModel>();
            string sqlStatement = "SELECT * FROM dbo.Products";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(sqlStatement, connection);

                try
                {
                    connection.Open();

                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        products.Add(new ProductModel
                        {
                            Id = (int)reader[0],
                            Name = (string)reader[1],
                            Amount = (int)reader[2],
                            DateProduced = (DateTime)reader[3],
                            ExpirationDate = (DateTime)reader[4],
                            Weight = (decimal)reader[5],
                            Description = (string)reader[6]
                        });
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
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
            List<ProductModel> products = new List<ProductModel>();
            string sqlStatement = "SELECT * FROM dbo.Products WHERE Name LIKE @Name";
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(sqlStatement, connection);
                sqlCommand.Parameters.AddWithValue("@Name", '%' + searchTerm + '%');

                try
                {
                    connection.Open();

                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while(reader.Read())
                    {
                        products.Add(new ProductModel
                        {
                            Id = (int)reader[0],
                            Name = (string)reader[1],
                            Amount = (int)reader[2],
                            DateProduced = (DateTime)reader[3],
                            ExpirationDate = (DateTime)reader[4],
                            Weight = (decimal)reader[5],
                            Description = (string)reader[6]
                        });
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return products;
        }

        public int Update(ProductModel product)
        {
            throw new NotImplementedException();
        }
    }
}
