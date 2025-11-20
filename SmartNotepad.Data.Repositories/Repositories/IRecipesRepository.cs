using SmartNotepad.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartNotepad.Data.Repositories.Repositories
{
    public interface IRecipesRepository
    {
        // Метод для асинхронного получения списка рецептов
        Task<IEnumerable<Recipe>> GetRecipesAsync();

        // Метод для асинхронного добавления рецепта
        Task AddRecipesAsync(Recipe recipe);

        // Метод для асинхронного удаления рецепта
        Task DeleteRecipesAsync(int id);

        // Метод для асинхронного редактирования рецепта
        Task UpdateRecipesAsync(Recipe recipe);
    }
}
