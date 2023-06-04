using gamelibraryAPI.Data;
using gamelibraryAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace gamelibraryAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GamesController : Controller
    {
        private readonly gamesdbcontext _gamesdbcontext;

        public GamesController(gamesdbcontext gamesdbcontext)
        {
            _gamesdbcontext = gamesdbcontext;
        }
        [HttpGet]

        public async Task<IActionResult> GetAllGames()
        {
            var games = await _gamesdbcontext.Games.ToListAsync();

            return Ok(games);
        }

        [HttpPost]
        public async Task<IActionResult> AddGame([FromBody] game gameRequest)
        {
            gameRequest.Id = Guid.NewGuid();

            await _gamesdbcontext.Games.AddAsync(gameRequest);
            await _gamesdbcontext.SaveChangesAsync();

            return Ok(gameRequest);
        }
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetGame([FromRoute] Guid id)
        {
            var game = await _gamesdbcontext.Games.FirstOrDefaultAsync(x => x.Id == id);

            if(game == null)
            {
                return NotFound();
            }

            return Ok(game);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateGame([FromRoute] Guid id, game updateGameRequest)
        {
            var game = await _gamesdbcontext.Games.FindAsync(id);

            if(game == null)
            {
                return NotFound();
            }

            game.Title = updateGameRequest.Title;
            game.Description = updateGameRequest.Description;
            game.Genres = updateGameRequest.Genres;
            game.Platforms = updateGameRequest.Platforms;
            game.Developers = updateGameRequest.Developers;
            game.Publisher = updateGameRequest.Publisher;
            game.Cost = updateGameRequest.Cost;

            await _gamesdbcontext.SaveChangesAsync();
            return Ok(game);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteGame([FromRoute] Guid id)
        {
            var game = await _gamesdbcontext.Games.FindAsync(id);

            if(game == null)
            {
                return NotFound();
            }

            _gamesdbcontext.Games.Remove(game);
            await _gamesdbcontext.SaveChangesAsync();
            return Ok(game);
        }

    }
}
