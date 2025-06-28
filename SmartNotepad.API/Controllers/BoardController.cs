using Microsoft.AspNetCore.Mvc;
using SmartNotepad.Application.DTOs;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SmartNotepad.Application.DTOs;
using SmartNotepad.Domain.Services.Services;
using SmartNotepad.Domain.Models;

namespace SmartNotepad.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BoardController : Controller
    {
        private readonly IBoardService _boardService;

        public BoardController(IBoardService boardService)
        {
            _boardService = boardService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBoardsAsync()
        {
            var result = await _boardService.GetBoardsAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddBoardsAsync([FromBody]BoardDTO board)
        {
            var model = new Board();
            model.Title = board.Title;
            model.Description = board.Description;
            model.Priority = board.Priority;
            model.UserId = board.UserId;

            await _boardService.AddBoardAsync(model);
            return Created();
        }
    }
}
