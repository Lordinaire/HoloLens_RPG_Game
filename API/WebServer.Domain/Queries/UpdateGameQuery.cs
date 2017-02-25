using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using WebServer.Data;
using WebServer.Data.Helpers;

namespace WebServer.Domain.Queries
{
    internal class UpdateGameQuery
    {
        private readonly IDataContext _context;
        private readonly Game _updatedGame;
        private readonly int _gameId;

        public UpdateGameQuery(IDataContext context, Game game, int gameId)
        {
            this._context = context;
            this._updatedGame = game;
            this._gameId = gameId;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>A task that represents the asynchronous create operation. The task result contains the object written to the database.</returns>
        public async Task<Game> ExecuteAsync()
        {
            var original = await _context.Games.FirstOrDefaultAsync(g => g.Id == _gameId);
            if (original == null)
            {
                throw new KeyNotFoundException();
            }

            _context.Entry(original).State = EntityState.Modified;
            _context.Games.Attach(original);

            original.CopyFrom(this._updatedGame, excludedProperties: new[] { (nameof(Game.Id)) });

            _context.SaveChanges();
            
            return original;
        }
    }
}
