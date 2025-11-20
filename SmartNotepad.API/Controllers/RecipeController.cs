using Microsoft.AspNetCore.Mvc;
using SmartNotepad.Application.DTOs;
using SmartNotepad.Data.Repositories.Repositories;
using SmartNotepad.Domain.Models;
using SmartNotepad.Data.Context;
using SmartNotepad.Domain.Services.Services;
using SmartNotepad.Domain.Services.Services.Implementation;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.AspNetCore.Cors;

namespace SmartNotepad.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("MyPolicy")]
    public class RecipeController : Controller
    {
        private readonly IRecipesService _recipeService;
        private readonly AppDbContext _context;

        public RecipeController(IRecipesService recipeService, AppDbContext context)
        {
            _recipeService = recipeService;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetRecipesAsync([FromQuery] int pageSize = 8, [FromQuery] int page = 1)
        {
            //var result = await _recipeService.GetRecipesAsync();
            //return Ok(result);
            int totalCount = await _context.Recipes.CountAsync(); // Получение общего кол-во элементов

            var recipe = _context.Recipes
                .OrderBy(r => r.Id)
                .ThenBy(r => r.CreationDate)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(recipe => new RecipeDTO
                {
                    Image = recipe.Image ?? "/Smart Notepad/img/image-def.png", // дефолтное значение картинки, если она не задана
                    Id = recipe.Id,
                    Title = recipe.Title,
                    Description = recipe.Description,
                    CookingTime = recipe.CookingTime,
                    Servings = recipe.Servings,
                    CreationDate = recipe.CreationDate,
                    UserId = recipe.UserId
                }).ToListAsync();

            return Ok(recipe);
        }

        // Добавление
        // [HttpPost] и [FromBody] - метод обрабатывает POST запросы и что данные для обработки находятся в теле запроса 
        [HttpPost]
        public async Task<IActionResult> AddRecipesAsync([FromBody] RecipeDTO recipe)
        {
            var model = new Recipe();
            model.Image = recipe.Image ?? "/Smart Notepad/img/image-def.png";
            model.Title = recipe.Title;
            model.Description = recipe.Description;
            model.CookingTime = recipe.CookingTime;
            model.Servings = recipe.Servings;
            model.CreationDate = DateTime.Now;
            model.UserId = recipe.UserId;

            await _recipeService.AddRecipesAsync(model);
            return Created();
        }

        // Редактирование
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRecipesAsync(int id, [FromBody] RecipeDTO recipe)
        {
            var recipes = await _recipeService.GetRecipesAsync();
            var existingRecipe = recipes.FirstOrDefault(r => r.Id == id);
            if (existingRecipe == null)
            {
                return NotFound(); // Статус 404, если заметка не найдена
            }

            existingRecipe.Image = recipe.Image ?? "/Smart Notepad/img/image-def.png";
            existingRecipe.Title = recipe.Title;
            existingRecipe.Description = recipe.Description;
            existingRecipe.CookingTime = recipe.CookingTime;
            existingRecipe.Servings = recipe.Servings;
            existingRecipe.CreationDate = DateTime.Now;
            existingRecipe.UserId = recipe.UserId;
            await _recipeService.UpdateRecipesAsync(existingRecipe);
            return NoContent(); // Статус 204, без содержимого
        }

        // Удаление
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecipesAsync(int id)
        {
            var recipes = await _recipeService.GetRecipesAsync();
            var existingRecipe = recipes.FirstOrDefault(r => r.Id == id);
            if (existingRecipe == null)
            {
                return NotFound();
            }

            await _recipeService.DeleteRecipesAsync(id);
            return NoContent();
        }

    }
}
