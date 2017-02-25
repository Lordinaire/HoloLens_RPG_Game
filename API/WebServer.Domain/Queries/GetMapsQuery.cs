using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebServer.Data;

namespace WebServer.Domain.Queries
{
    internal class GetMapsQuery
    {
        private readonly IDataContext _context;
        private int? _gameId;

        public GetMapsQuery(IDataContext context)
        {
            this._context = context;
        }

        public GetMapsQuery ForGame(int gameId)
        {
            this._gameId = gameId;
            return this;
        }

        public IQueryable<Map> Build()
        {
            IQueryable<Map> query = _context.Maps.Include(p => p.Game);
            if (_gameId != null)
            {
                query = query.Where(m => m.GameId == _gameId.Value);
            }

            return query;
        }
    }
}
