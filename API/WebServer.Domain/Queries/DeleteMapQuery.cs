using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebServer.Data;

namespace WebServer.Domain.Queries
{
    internal class DeleteMapQuery
    {
        private readonly IDataContext _context;
        private readonly int _mapId;

        public DeleteMapQuery(IDataContext context, int id)
        {
            this._context = context;
            this._mapId = id;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>A task that represents the asynchronous create operation.</returns>
        public async Task ExecuteAsync()
        {
            var mapToDelete = await _context.Maps.FirstOrDefaultAsync(m => m.Id == _mapId);
            if (mapToDelete == null)
            {
                throw new KeyNotFoundException();
            }
            _context.Maps.Remove(mapToDelete);
            _context.SaveChanges();
        }
    }
}
