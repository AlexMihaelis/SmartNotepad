using SmartNotepad.Data.Context;
using SmartNotepad.Data.Repositories.Repositories;
using SmartNotepad.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartNotepad.Domain.Services.Services.Implementation
{
    public class RecipesService : IRecipesService
    {
        private readonly AppDbContext _context;
        private readonly IRecipesRepository _recipeRepository;

        public RecipesService(IRecipesRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }

        // Получение (чтение)
        public async Task<IEnumerable<Recipe>> GetRecipesAsync()
        {
            return await _recipeRepository.GetRecipesAsync();
        }

        // Добавление
        public async Task AddRecipesAsync(Recipe recipe)
        {
            recipe.CreationDate = DateTime.Now; // Установка даты создания
            await _recipeRepository.AddRecipesAsync(recipe);
        }

        // Удаление
        public async Task DeleteRecipesAsync(int id)
        {
            var recipe = await _context.Recipes.FindAsync(id);
            if (recipe != null)
            {
                await _recipeRepository.DeleteRecipesAsync(id);
            }
        }

        // Редактирование
        public async Task UpdateRecipesAsync(Recipe recipe)
        {
            await _recipeRepository.UpdateRecipesAsync(recipe);
        }
    }
}
