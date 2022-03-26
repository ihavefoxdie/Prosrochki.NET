using Prosrochki.NET.Models;
using System.Data.SqlClient;

namespace Prosrochki.NET.Services
{
    public class ProductDAO : IProductDataService
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Test;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        
        public int Delete(int Id)
        {
            string sqlStatement = "DELETE FROM dbo.Products WHERE ID = @Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(sqlStatement, connection);
                sqlCommand.Parameters.AddWithValue("@Id", Id);

                try
                {
                    connection.Open();

                    sqlCommand.ExecuteNonQuery();
                    return Id;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return -1;
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

        public ProductModel GetProductById(int id)
        {
            ProductModel productDetails = null;
            string sqlStatement = "SELECT * FROM dbo.Products WHERE ID = @Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(sqlStatement, connection);
                sqlCommand.Parameters.AddWithValue("@Id", id);

                try
                {
                    connection.Open();

                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        productDetails = new ProductModel
                        {
                            Id = (int)reader[0],
                            Name = (string)reader[1],
                            Amount = (int)reader[2],
                            DateProduced = (DateTime)reader[3],
                            ExpirationDate = (DateTime)reader[4],
                            Weight = (decimal)reader[5],
                            Description = (string)reader[6]
                        };
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return productDetails;

            /*throw new NotImplementedException();*/
        }

        public void Insert(ProductModel product)
        {
            string sqlStatement = "INSERT INTO dbo.Products (Name, Amount, DateProduced, ExpirationDate, Weight, Description) VALUES (@Name, @Amount, @DateProduced, @ExpirationDate, @Weight, @Description)";
            string scopeId = "SELECT dbo.Products SCOPE_IDENTITY()";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(sqlStatement, connection);
                sqlCommand.Parameters.Add("@Name", System.Data.SqlDbType.VarChar, 40).Value = product.Name;
                sqlCommand.Parameters.Add("@Amount", System.Data.SqlDbType.Int).Value = product.Amount;
                sqlCommand.Parameters.Add("@DateProduced", System.Data.SqlDbType.DateTime2, 7).Value = product.DateProduced;
                sqlCommand.Parameters.Add("@ExpirationDate", System.Data.SqlDbType.DateTime2, 7).Value = product.ExpirationDate;
                sqlCommand.Parameters.Add("@Weight", System.Data.SqlDbType.Decimal).Value = product.Weight;
                sqlCommand.Parameters.Add("@Description", System.Data.SqlDbType.VarChar, 500).Value = product.Description;


                try
                {
                    connection.Open();
                    sqlCommand.ExecuteNonQuery();
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

               /* throw new NotImplementedException();*/
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
            int idNumber = -1;

            string sqlStatement = "UPDATE dbo.Products SET Name = @Name, Amount = @Amount, DateProduced = @DateProduced, " +
                "ExpirationDate = @ExpirationDate, Weight = @Weight, Description = @Description WHERE Id = @Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(sqlStatement, connection);
                sqlCommand.Parameters.AddWithValue("@Id", product.Id);
                sqlCommand.Parameters.Add("@Name", System.Data.SqlDbType.VarChar, 40).Value = product.Name;
                sqlCommand.Parameters.Add("@Amount", System.Data.SqlDbType.Int).Value = product.Amount;
                sqlCommand.Parameters.Add("@DateProduced", System.Data.SqlDbType.DateTime2, 7).Value = product.DateProduced;
                sqlCommand.Parameters.Add("@ExpirationDate", System.Data.SqlDbType.DateTime2, 7).Value = product.ExpirationDate;
                sqlCommand.Parameters.Add("@Weight", System.Data.SqlDbType.Decimal).Value = product.Weight;
                sqlCommand.Parameters.Add("@Description", System.Data.SqlDbType.VarChar, 500).Value = product.Description;

                try
                {
                    connection.Open();
                    sqlCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return idNumber;
            /*throw new NotImplementedException();*/
        }
    }
}
