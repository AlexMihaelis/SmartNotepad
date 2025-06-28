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
    public class ExerciseService : IExerciseService
    {
        private readonly AppDbContext _context;
        private readonly IExerciseRepository _exerciseRepository;

        public ExerciseService(IExerciseRepository exerciseRepository)
        {
            _exerciseRepository = exerciseRepository;
        }

        // Получение(чтение)
        public async Task<IEnumerable<Exercise>> GetExercisesAsync()
        {
            return await _exerciseRepository.GetExercisesAsync();
        }

        // Добавление
        public async Task AddExercisesAsync(Exercise exercise)
        {
            exercise.CreationDate = DateTime.UtcNow; // Установка даты создания
            if (exercise.CompletionDate != null)
            {
                exercise.CompletionDate = DateTime.Now; // Если дата дедлайна задана, то по умолчанию нынешняя
            }
            await _exerciseRepository.AddExerciseAsync(exercise);
        }

        // Удаление
        public async Task DeleteExercisesAsync(int id)
        {
            var exercise = await _context.Exercises.FindAsync(id);
            if(exercise != null)
            {
                await _exerciseRepository.DeleteExerciseAsync(id);
            }
        }

        // Редактирование
        public async Task UpdateExercisesAsync(Exercise exercise)
        {
            await _exerciseRepository.UpdateExerciseAsync(exercise);
        }
    }
}
