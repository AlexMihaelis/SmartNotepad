using SmartNotepad.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartNotepad.Data.Repositories.Repositories
{
    public interface IBoardRepository
    {
        // Метод для асинхронного получения список досок
        Task<IEnumerable<Board>> GetBoardsAsync();

        // Метод для асинхронного добавления доски
        Task AddBoardAsync(Board board);

        // Метод для асинхронного удаления доски
        Task DeleteBoardAsync(int id);

        // Метод для асинхроного редактирования доски
        Task UpdateBoardAsync(Board board);
    }
}
