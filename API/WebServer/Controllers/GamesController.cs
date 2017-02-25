using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebServer.Data;
using WebServer.Domain;
using WebServer.Domain.Interfaces;
using WebServer.Models;

namespace WebServer.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class GamesController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IDataService _service;
        public GamesController(
            IDataService service,
            UserManager<ApplicationUser> userManager)
        {
            _service = service;
            _userManager = userManager;
        }

        // GET api/games
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var user = await GetCurrentUserAsync();
            if (user == null)
            {
                return new ObjectResult("Error");
            }
            return new ObjectResult(_service.GetAllGames());
        }

        // GET api/games/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var game = await _service.GetGameAsync(id);

            if (game == null)
            {
                return NotFound();
            }
            return new ObjectResult(game);
        }

        // POST api/games
        [HttpPost]
        public IActionResult Post([FromBody]Game game)
        {
            if (game == null)
                return new BadRequestResult();
            if (game.Id != default(int))
                return StatusCode(400, "Id must be empty");
            var createdGame = _service.CreateGame(game);
            return new ObjectResult(createdGame);
        }

        // PUT api/games/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]Game game)
        {
            try
            {
                var updatedGame = await _service.UpdateGameAsync(id, game);
                return new ObjectResult(updatedGame);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // DELETE api/games/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _service.DeleteGameAsync(id);
                return new NoContentResult();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // GET api/games/5/maps
        [HttpGet("{id}/maps")]
        public IActionResult GetMaps(int id)
        {
            var maps = _service.GetMapsForGame(id);

            if (maps == null)
            {
                return NotFound();
            }
            return new ObjectResult(maps);
        }

        private Task<ApplicationUser> GetCurrentUserAsync()
        {
            return _userManager.GetUserAsync(HttpContext.User);
        }
    }
}
