using Microsoft.AspNetCore.Mvc;
using SmartNotepad.Domain.Services.Services;

namespace SmartNotepad.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExerciseController : Controller
    {
        private readonly IExerciseService _exerciseService;

        public ExerciseController(IExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetExercisesAsync()
        {
            var result = await _exerciseService.GetExercisesAsync();
            return Ok(result);
        }
    }
}
