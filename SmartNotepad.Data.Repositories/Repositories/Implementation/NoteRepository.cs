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
    public class NoteRepository : INoteRepository
    {
        private readonly AppDbContext _context;
        public NoteRepository(AppDbContext context)
        {
            _context = context;
        }

        // Получение = чтение :)
        public async Task<IEnumerable<Note>> GetNotesAsync()
        {
            return await _context.Notes.Include(n => n.User) // Подкл. User'а
                            .Include(n => n.NoteCategories) // Подкл. категорий заметок
                            .Include(n => n.NoteTags) // Подкл. тегов заметок
                            .ToListAsync(); // Получение всех заметок из базы данных
        }

        // Добавление
        public async Task AddNoteAsync(Note note)
        {
            note.CreationDate = DateTime.UtcNow; // Установка даты создания
            note.LastModifDate = DateTime.UtcNow; // Установка даты последнего изменения
            _context.Notes.Add(note); // Добавление заметки в контекст
            await _context.SaveChangesAsync(); // Сохранение в базе данных
        }

        //Удаление
        public async Task DeleteNoteAsync(int id)
        {
            var note = await _context.Notes.FindAsync(id);
            if (note != null)
            {
                _context.Notes.Remove(note); // Удаление заметки из контекста
                await _context.SaveChangesAsync(); // Сохранение изменений в базе данных
            }
        }

        // Редактирование
        public async Task UpdateNoteAsync(Note note)
        {
            note.LastModifDate = DateTime.UtcNow; // Обновление даты последнего изменения
            _context.Notes.Update(note); // Обновление заметки в контексте
            await _context.SaveChangesAsync(); // Сохранение изменений в базе данных
        }
    }
}
