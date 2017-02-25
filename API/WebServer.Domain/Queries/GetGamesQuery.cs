using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebServer.Data;

namespace WebServer.Domain.Queries
{
    internal class GetGamesQuery
    {
        private readonly IDataContext _context;

        public GetGamesQuery(IDataContext context)
        {
            this._context = context;
        }

        public IQueryable<Game> Build()
        {
            var query = _context.Games.Include(p => p.Maps);
            return query;
        }
    }
}
