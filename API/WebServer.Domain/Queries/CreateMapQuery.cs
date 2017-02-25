using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebServer.Data;

namespace WebServer.Domain.Queries
{
    internal class CreateMapQuery
    {
        private readonly IDataContext _context;
        private readonly Map _map;

        public CreateMapQuery(IDataContext context, Map map)
        {
            this._context = context;
            this._map = map;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>A task that represents the asynchronous create operation. The task result contains the object written to the database.</returns>
        public Map Execute()
        {
            _context.Maps.Add(this._map);
            _context.SaveChanges();

            return this._map;
        }
    }
}
