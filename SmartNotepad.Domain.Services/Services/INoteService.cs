using SmartNotepad.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartNotepad.Domain.Services.Services
{
    public interface INoteService
    {
        // Метод для асинхронного получения списка заметок
        Task<IEnumerable<Note>> GetNotesAsync();

        // Метод для асинхронного добавление заметки
        Task AddNotesAsync(Note note);

        // Метод для асинхронного удаления заметки
        Task DeleteNotesAsync(int id);

        // Метод для асинхронного редактирования заметки
        Task UpdateNotesAsync(Note note);
    }
}
