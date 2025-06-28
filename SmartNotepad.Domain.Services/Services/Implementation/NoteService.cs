using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
    public class NoteService : INoteService
    {
        private readonly AppDbContext _context;
        private readonly INoteRepository _noteRepository;

        //private readonly ILogger<NoteService> _logger;
        //ILogger<NoteService> logger, 
        public NoteService(INoteRepository noteRepository)
        {
            //_logger = logger;
            _noteRepository = noteRepository;
        }

        // Получение = чтение :)
        public async Task<IEnumerable<Note>> GetNotesAsync()
        {
            return await _noteRepository.GetNotesAsync();
        }

        // Добавление
        public async Task AddNotesAsync(Note note)
        {
            note.CreationDate = DateTime.UtcNow; // Установка даты создания
            note.LastModifDate = DateTime.UtcNow; // Установка даты последнего изменения
            await _noteRepository.AddNoteAsync(note);
        }

        // Удаление
        public async Task DeleteNotesAsync(int id)
        {
            await _noteRepository.DeleteNoteAsync(id);
        }

        // Редактирование
        public async Task UpdateNotesAsync(Note note)
        {
            note.LastModifDate = DateTime.UtcNow; // Обновление даты последнего изменения
            await _noteRepository.UpdateNoteAsync(note);
        }
    }
}
