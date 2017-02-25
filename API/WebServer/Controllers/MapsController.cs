using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebServer.Data;
using WebServer.Domain.Interfaces;

namespace WebServer.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class MapsController : Controller
    {
        private readonly IDataService _service;
        public MapsController(IDataService service)
        {
            this._service = service;
        }

        // GET api/maps
        [HttpGet]
        public IEnumerable<Map> Get()
        {
            var maps = _service.GetAllMaps();

            return maps;
        }

        // GET api/maps/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var map = await _service.GetMapAsync(id);

            if (map == null)
            {
                return NotFound();
            }
            return new ObjectResult(map);
        }

        // POST api/maps
        [HttpPost]
        public IActionResult Post([FromBody]Map map)
        {
            if (map == null)
                return new BadRequestResult();
            if (map.Id != default(int))
                return StatusCode(400, "Id must be empty");
            var createdMap = _service.CreateMap(map);
            return new ObjectResult(createdMap);
        }

        // PUT api/games/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]Map map)
        {
            try
            {
                var updatedMap = await _service.UpdateMapAsync(id, map);
                return new ObjectResult(updatedMap);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // DELETE api/maps/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _service.DeleteMapAsync(id);
                return new NoContentResult();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
