using Microsoft.EntityFrameworkCore;
using SmartNotepad.Data.Context;
using SmartNotepad.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartNotepad.Data.Repositories.Repositories.Implementation
{
    public class RecipesRepository : IRecipesRepository
    {
        private readonly AppDbContext _context;

        public RecipesRepository(AppDbContext context)
        {
            _context = context;
        }

        // Получение (чтение)
        public async Task<IEnumerable<Recipe>> GetRecipesAsync()
        {
            return await _context.Recipes.Include(r => r.User)
                .Include(r => r.RecipeCategories)
                .Include(r => r.RecipeTags)
                .ToListAsync();
        }

        // Добавление
        public async Task AddRecipesAsync(Recipe recipe)
        {
            recipe.CreationDate = DateTime.Now; // Установка даты создания
            _context.Recipes.Add(recipe); // Добавление рецепта в контекст
            await _context.SaveChangesAsync(); // Сохранение в бд
        }

        // Удаление
        public async Task DeleteRecipesAsync(int id)
        {
            var recipe = await _context.Recipes.FindAsync(id);
            if (recipe != null)
            {
                _context.Recipes.Remove(recipe); // Удаление рецепта из контекста
                await _context.SaveChangesAsync(); // Сохр. изменений в бд
            }
        }

        // Редактирование
        public async Task UpdateRecipesAsync(Recipe recipe)
        {
            _context.Recipes.Update(recipe); // Обновление рецепта в контексте
            await _context.SaveChangesAsync(); // Сохр. изменений в бд
        }
    }
}
