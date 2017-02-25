using System.Collections.Generic;
using System.Threading.Tasks;
using WebServer.Data;

namespace WebServer.Domain.Interfaces
{
    public interface IDataService
    {
        List<Game> GetAllGames();

        Task<List<Game>> GetAllGamesAsync();

        Task<Game> GetGameAsync(int id);

        Game CreateGame(Game game);

        Task<Game> UpdateGameAsync(int id, Game game);

        Task DeleteGameAsync(int id);
        
        Map AddMap(Map map);

        List<Map> GetAllMaps();

        Task<List<Map>> GetAllMapsAsync();

        Task<Map> GetMapAsync(int id);

        Map CreateMap(Map map);

        Task<Map> UpdateMapAsync(int id, Map map);

        Task DeleteMapAsync(int id);

        List<Map> GetMapsForGame(int id);
    }
}