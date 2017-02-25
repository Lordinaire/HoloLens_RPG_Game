using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebServer.Data;
using WebServer.Domain.Interfaces;
using WebServer.Domain.Queries;

namespace WebServer.Domain
{
    public partial class DataService : IDataService
    {
        public Game AddGame(Game game)
        {
            return new CreateGameQuery(this._context, game).Execute();
        }

        public List<Game> GetAllGames()
        {
            return new GetGamesQuery(this._context).Build().ToList();
        }

        public async Task<List<Game>> GetAllGamesAsync()
        {
            return await new GetGamesQuery(this._context).Build().ToListAsync();
        }

        public async Task<Game> GetGameAsync(int id)
        {
            return await new GetGameQuery(this._context, id).ExecuteAsync();
        }

        public Game CreateGame(Game game)
        {
            return new CreateGameQuery(this._context, game).Execute();
        }

        public async Task<Game> UpdateGameAsync(int id, Game game)
        {
            return await new UpdateGameQuery(this._context, game, id).ExecuteAsync();
        }

        public async Task DeleteGameAsync(int id)
        {
            await new DeleteGameQuery(this._context, id).ExecuteAsync();
        }
    }
}
