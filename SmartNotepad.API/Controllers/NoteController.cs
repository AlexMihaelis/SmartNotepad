using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SmartNotepad.Application.DTOs;
using SmartNotepad.Domain;
using SmartNotepad.Domain.Models;
using SmartNotepad.Domain.Services.Services;

namespace SmartNotepad.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("MyPolicy")]
    public class NoteController : ControllerBase
    {
        //private readonly ILogger<NotesController> _logger;
        private readonly INoteService _noteService;

        public NoteController(INoteService noteService)
        {
            _noteService = noteService;
        }

        [HttpGet]
        public async Task<IActionResult> GetNotesAsync()
        {
            var result = await _noteService.GetNotesAsync();
            var note = result.Select(note => new NoteDTO
            {
                Id = note.Id,
                Title = note.Title,
                Content = note.Content,
                CreationDate = note.CreationDate,
                LastModifDate = note.LastModifDate,
                UserId = note.UserId
            }).ToList();
            return Ok(note);
        }

        // Добавление
        // [HttpPost] и [FromBody] - метод обрабатывает POST запросы и что данные для обработки находятся в теле запроса 
        [HttpPost]
        public async Task<IActionResult> AddNotesAsync([FromBody] NoteDTO note)
        {
            var model = new Note();
            model.Title = note.Title;
            model.Content = note.Content;
            model.UserId = note.UserId;

            await _noteService.AddNotesAsync(model);
            return Created();
        }

        // Редактирование
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNotesAsync(int id, [FromBody]NoteDTO note)
        {
            var notes = await _noteService.GetNotesAsync();
            var existingNote = notes.FirstOrDefault(n => n.Id == id);
            if (existingNote == null)
            {
                return NotFound(); // Статус 404, если заметка не найдена
            }

            existingNote.Title = note.Title;
            existingNote.Content = note.Content;
            existingNote.LastModifDate = DateTime.UtcNow;
            existingNote.UserId = note.UserId;
            await _noteService.UpdateNotesAsync(existingNote);
            return NoContent(); // Статус 204, без содержимого
        }

        // Удаление
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotesAsync(int id)
        {
            var notes = await _noteService.GetNotesAsync();
            var existingNote = notes.FirstOrDefault(n => n.Id == id);
            if (existingNote == null)
            {
                return NotFound();
            }

            await _noteService.DeleteNotesAsync(id);
            return NoContent();
        }
    }
}
