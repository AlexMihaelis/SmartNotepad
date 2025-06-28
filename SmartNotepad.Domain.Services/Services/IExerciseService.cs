using SmartNotepad.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartNotepad.Domain.Services.Services
{
    public interface IExerciseService
    {
        // Метод для асинхронного получения списка задач
        Task<IEnumerable<Exercise>> GetExercisesAsync();

        // Метод для асинхронного добавления задачи
        Task AddExercisesAsync(Exercise exercise);

        // Метод для асинхронного удаления задачи
        Task DeleteExercisesAsync(int id);

        // Метод для асинхронного редактирования задачи
        Task UpdateExercisesAsync(Exercise exercise);
    }
}
