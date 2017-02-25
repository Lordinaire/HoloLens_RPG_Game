using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebServer.Data;

namespace WebServer.Domain.Queries
{
    internal class CreateGameQuery
    {
        private readonly IDataContext _context;
        private readonly Game _game;

        public CreateGameQuery(IDataContext context, Game game)
        {
            this._context = context;
            this._game = game;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>A task that represents the asynchronous create operation. The task result contains the object written to the database.</returns>
        public Game Execute()
        {
            _context.Games.Add(this._game);
            _context.SaveChanges();

            return this._game;
        }
    }
}
