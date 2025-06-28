using SmartNotepad.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartNotepad.Data.Repositories.Repositories
{
    public interface IRecipeRepository
    {
        // Метод для асинхронного получения списка рецептов
        Task<IEnumerable<Recipe>> GetRecipesAsync();

        // Метод для асинхронного добавления рецепта
        Task AddRecipeAsync(Recipe recipe);

        // Метод для асинхронного удаления рецепта
        Task DeleteRecipeAsync(int id);

        // Метод для асинхронного редактирования рецепта
        Task UpdateRecipeAsync(Recipe recipe);
    }
}
