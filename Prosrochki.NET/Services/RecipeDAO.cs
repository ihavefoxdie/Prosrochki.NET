using Prosrochki.NET.Models;
using System.Data.SqlClient;

namespace Prosrochki.NET.Services
{
    public class RecipeDAO : IRecipeDataService
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Test;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public int Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public List<RecipeModel> GetAllRecipes()
        {
            List<RecipeModel> recipes = new List<RecipeModel>();
            string sqlStatement = "SELECT * FROM dbo.Recipes";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(sqlStatement, connection);

                try
                {
                    connection.Open();

                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        recipes.Add(new RecipeModel
                        {
                            Id = (int)reader[0],
                            Name = (string)reader[1],
                            Ingredients = (string)reader[2],
                            Description = (string)reader[3]
                        });
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return recipes;
        }

        public RecipeModel GetRecipesById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(RecipeModel recipe)
        {
            string sqlStatement = "INSERT INTO dbo.Recipes (Name, Ingredients, Description) VALUES (@Name, @Ingredients, @Description)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(sqlStatement, connection);
                sqlCommand.Parameters.Add("@Name", System.Data.SqlDbType.NChar, 40).Value = recipe.Name;
                sqlCommand.Parameters.Add("@Ingredients", System.Data.SqlDbType.NChar, 500).Value = recipe.Ingredients;
                sqlCommand.Parameters.Add("@Description", System.Data.SqlDbType.NChar, 500).Value = recipe.Description;

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
        }

        public List<RecipeModel> SearchRecipes(string searchTerm)
        {
            throw new NotImplementedException();
        }

        public int Update(RecipeModel recipe)
        {
            throw new NotImplementedException();
        }
    }
}
