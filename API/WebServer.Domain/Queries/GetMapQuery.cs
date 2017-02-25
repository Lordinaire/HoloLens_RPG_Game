using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebServer.Data;

namespace WebServer.Domain.Queries
{
    internal class GetMapQuery
    {
        private readonly IDataContext _context;
        private readonly int _mapId;

        public GetMapQuery(IDataContext context, int mapId)
        {
            this._context = context;
            this._mapId = mapId;
        }

        public async Task<Map> ExecuteAsync()
        {
            return await _context.Maps.Include(p => p.Game).FirstOrDefaultAsync(m => m.Id == this._mapId);
        }
    }
}
