using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebServer.Data;

namespace WebServer.Domain.Queries
{
    internal class DeleteGameQuery
    {
        private readonly IDataContext _context;
        private readonly int _gameId;

        public DeleteGameQuery(IDataContext context, int id)
        {
            this._context = context;
            this._gameId = id;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>A task that represents the asynchronous create operation.</returns>
        public async Task ExecuteAsync()
        {
            var gameToDelete = await _context.Games.Include(g => g.Maps).FirstOrDefaultAsync(g => g.Id == _gameId);
            if (gameToDelete == null)
            {
                throw new KeyNotFoundException();
            }
            _context.Games.Remove(gameToDelete);
            _context.SaveChanges();
        }
    }
}
