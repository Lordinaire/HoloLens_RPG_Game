using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WebServer.Data;
using WebServer.Data.Helpers;

namespace WebServer.Domain.Queries
{
    internal class UpdateMapQuery
    {
        private readonly IDataContext _context;
        private readonly Map _updatedMap;
        private readonly int _mapId;

        public UpdateMapQuery(IDataContext context, Map map, int _mapId)
        {
            this._context = context;
            this._updatedMap = map;
            this._mapId = _mapId;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>A task that represents the asynchronous create operation. The task result contains the object written to the database.</returns>
        public async Task<Map> ExecuteAsync()
        {
            var original = await _context.Maps.FirstOrDefaultAsync(m => m.Id == _mapId);
            if (original == null)
            {
                throw new KeyNotFoundException();
            }

            _context.Entry(original).State = EntityState.Modified;
            _context.Maps.Attach(original);
            
            original.CopyFrom(_updatedMap, excludedProperties:new []{(nameof(Game.Id))});

            _context.SaveChanges();
            
            return original;
        }
    }
}
