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
    public class RecipeService : IRecipeService
    {
        private readonly AppDbContext _context;
        private readonly IRecipeRepository _recipeRepository;

        public RecipeService(IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }

        // Получение (чтение)
        public async Task<IEnumerable<Recipe>> GetRecipesAsync()
        {
            return await _recipeRepository.GetRecipesAsync();
        }

        // Добавление
        public async Task AddRecipeAsync(Recipe recipe)
        {
            recipe.CreationDate = DateOnly.FromDateTime(DateTime.Now); // Установка даты создания
            await _recipeRepository.AddRecipeAsync(recipe);
        }

        // Удаление
        public async Task DeleteRecipeAsync(int id)
        {
            var recipe = await _context.Recipes.FindAsync(id);
            if (recipe != null)
            {
                await _recipeRepository.DeleteRecipeAsync(id);
            }
        }

        // Редактирование
        public async Task UpdateRecipeAsync(Recipe recipe)
        {
            await _recipeRepository.UpdateRecipeAsync(recipe);
        }
    }
}
