using SmartNotepad.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartNotepad.Domain.Services.Services
{
    public interface IBoardService
    {
        // Метод для асинхронного получения списка досок
        Task<IEnumerable<Board>> GetBoardsAsync();

        // Метод для асинхронного добавления доски
        Task AddBoardAsync(Board board);

        // Метод для асинхронного удаления доски
        Task DeleteBoardAsync(int id);

        // Метод для асинхронного редактирования доски
        Task UpdateBoardAsync(Board board);
    }
}
