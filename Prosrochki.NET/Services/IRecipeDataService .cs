using Prosrochki.NET.Models;

namespace Prosrochki.NET.Services
{
    public interface IRecipeDataService
    {
        List<RecipeModel> GetAllRecipes();

        List<RecipeModel> SearchRecipes(string searchTerm);

        RecipeModel GetRecipesById(int id);

        void Insert(RecipeModel recipe);
        int Update(RecipeModel recipe);
        int Delete(int Id);
    }
}
