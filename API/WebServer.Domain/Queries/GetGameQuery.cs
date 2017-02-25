using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebServer.Data;

namespace WebServer.Domain.Queries
{
    internal class GetGameQuery
    {
        private readonly IDataContext _context;
        private readonly int _gameId;

        public GetGameQuery(IDataContext context, int gameId)
        {
            this._context = context;
            this._gameId = gameId;
        }

        public async Task<Game> ExecuteAsync()
        {
            return await _context.Games.Include(p => p.Maps).FirstOrDefaultAsync(g => g.Id == this._gameId);
        }
    }
}
