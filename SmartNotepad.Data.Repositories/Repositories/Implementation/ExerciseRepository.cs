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
    public class ExerciseRepository : IExerciseRepository
    {
        private readonly AppDbContext _context;

        public ExerciseRepository(AppDbContext context)
        {
            _context = context;
        }

        // Получение (чтение)
        public async Task<IEnumerable<Exercise>> GetExercisesAsync()
        {
            return await _context.Exercises.Include(e => e.ExerciseTags)
                .Include(e => e.ExerciseCategories)
                .ToListAsync();
        }

        // Добавление
        public async Task AddExerciseAsync(Exercise exercise)
        {
            exercise.CreationDate = DateTime.UtcNow; // Установка даты создания
            if (exercise.CompletionDate != null)
            {
                exercise.CompletionDate = DateTime.Now; // Если дата дедлайна задана, то по умолчанию нынешняя
            }
            _context.Exercises.Add(exercise); // Добавление задачи в контекст
            await _context.SaveChangesAsync(); // Сохранение в бд
        }

        // Удаление
        public async Task DeleteExerciseAsync(int id)
        {
            var exercise = await _context.Exercises.FindAsync(id);
            if (exercise != null)
            {
                _context.Exercises.Remove(exercise);// Удаление задачи из контекста
                await _context.SaveChangesAsync(); // Сохр. изменений в бд
            }
        }

        // Редактирование
        public async Task UpdateExerciseAsync(Exercise exercise)
        {
            _context.Exercises.Update(exercise);// Обновление задачи в контексте
            await _context.SaveChangesAsync(); // Сохр. изменений в бд
        }
    }
}
