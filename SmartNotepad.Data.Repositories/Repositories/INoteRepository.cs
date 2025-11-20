using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartNotepad.Domain.Models;

namespace SmartNotepad.Data.Repositories.Repositories
{
    public interface INoteRepository
    {
        // Метод для асинхронного получения списка заметок
        Task<IEnumerable<Note>> GetNotesAsync();

        //IQueryable<Note> GetNotesQueryable();

        // Метод для асинхронного добавление заметки
        Task AddNoteAsync(Note note);

        // Метод для асинхронного удаления заметки
        Task DeleteNoteAsync(int id);

        // Метод для асинхронного редактирования заметки
        Task UpdateNoteAsync(Note note);

    }
}
