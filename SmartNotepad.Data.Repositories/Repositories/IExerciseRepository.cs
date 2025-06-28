using SmartNotepad.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartNotepad.Data.Repositories.Repositories
{
    public interface IExerciseRepository
    {
        // Метод для асинхронного получения списка задач
        Task<IEnumerable<Exercise>> GetExercisesAsync();

        // Метод для асинхронного добавление задачи
        Task AddExerciseAsync(Exercise exercise);

        // Метод для асинхронного удаления задачи
        Task DeleteExerciseAsync(int id);

        // Метод для асинхронного редактирования задачи
        Task UpdateExerciseAsync(Exercise exercise);
    }
}
