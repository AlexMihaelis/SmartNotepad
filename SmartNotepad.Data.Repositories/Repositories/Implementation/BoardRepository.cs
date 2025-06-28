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
    public class BoardRepository : IBoardRepository
    {
        private readonly AppDbContext _context;

        public BoardRepository(AppDbContext context)
        {
            _context = context;
        }

        // Получение(чтение)
        public async Task<IEnumerable<Board>> GetBoardsAsync()
        {
            return await _context.Boards.Include(b => b.User).ToListAsync(); //Подключение User'a и Получение всех досок из бд
        }

        // Добавление
        public async Task AddBoardAsync(Board board)
        {
            board.CreationDate = DateTime.UtcNow; // Установка даты создания
            _context.Boards.Add(board); // Добавление доски в контекст
            await _context.SaveChangesAsync(); // Сохранение в базе данных
        }

        // Удаление
        public async Task DeleteBoardAsync(int id)
        {
            // Ищем доску в бд по ее id
            var board = await _context.Boards.FindAsync(id);
            if (board != null)
            {
                _context.Boards.Remove(board); // Удаление доски из контекста
                await _context.SaveChangesAsync(); // Сохранение изменений в бд
            }
        }

        // Редактирование
        public async Task UpdateBoardAsync(Board board)
        {
            _context.Boards.Update(board); // Обновление доски в контексте
            await _context.SaveChangesAsync(); // Сохранение изменений в бд
        }
    }
}
