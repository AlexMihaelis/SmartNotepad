using Microsoft.AspNetCore.Mvc;
using SmartNotepad.Data.Repositories.Repositories;
using SmartNotepad.Domain.Services.Services;

namespace SmartNotepad.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecipeController : Controller
    {
        private readonly IRecipeService _recipeService;

        public RecipeController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetRecipesAsync()
        {
            var result = await _recipeService.GetRecipesAsync();
            return Ok(result);
        }

        //[HttpPost]
        
    }
}
