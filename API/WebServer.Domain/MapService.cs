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
        public Map AddMap(Map map)
        {
            return new CreateMapQuery(this._context, map).Execute();
        }

        public List<Map> GetAllMaps()
        {
            return new GetMapsQuery(this._context).Build().ToList();
        }

        public async Task<List<Map>> GetAllMapsAsync()
        {
            return await new GetMapsQuery(this._context).Build().ToListAsync();
        }

        public List<Map> GetMapsForGame(int id)
        {
            return new GetMapsQuery(this._context).ForGame(id).Build().ToList();
        }

        public async Task<List<Map>> GetMapsForGameAsync(int id)
        {
            return await new GetMapsQuery(this._context).ForGame(id).Build().ToListAsync();
        }

        public async Task<Map> GetMapAsync(int id)
        {
            return await new GetMapQuery(this._context, id).ExecuteAsync();
        }

        public Map CreateMap(Map map)
        {
            return new CreateMapQuery(this._context, map).Execute();
        }

        public async Task<Map> UpdateMapAsync(int id, Map map)
        {
            return await new UpdateMapQuery(this._context, map, id).ExecuteAsync();
        }

        public async Task DeleteMapAsync(int id)
        {
            await new DeleteMapQuery(this._context, id).ExecuteAsync();
        }
    }
}
