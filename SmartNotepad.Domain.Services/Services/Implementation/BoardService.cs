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
    public class BoardService : IBoardService
    {
        private readonly AppDbContext _context;
        private readonly IBoardRepository _boardRepository;

        public BoardService(IBoardRepository boardRepository)
        {
            _boardRepository = boardRepository;
        }

        // Получение(чтение)
        public async Task<IEnumerable<Board>> GetBoardsAsync()
        {
            return await _boardRepository.GetBoardsAsync();
        }

        // Добавление
        public async Task AddBoardAsync (Board board)
        {
            board.CreationDate = DateTime.UtcNow; // Установка даты создания
            await _boardRepository.AddBoardAsync(board);
        }

        // Удаление
        public async Task DeleteBoardAsync(int id)
        {
            // Ищем доску в бд по ее id
            var board = await _context.Boards.FindAsync(id);
            if (board != null)
            {
                await _boardRepository.DeleteBoardAsync(id);
            }
        }

        // Редактирование
        public async Task UpdateBoardAsync(Board board)
        {
            await _boardRepository.UpdateBoardAsync(board);
        }
    }
}
