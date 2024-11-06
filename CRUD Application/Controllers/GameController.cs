using GamesMarket.DataContext.Entities;
using GamesMarket.DataContext.Interfaces;
using GamesMarket.DataContext.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {
        private readonly IGameRepository _gameRepository;

        public GameController(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<GameEntity>?>> GetAllGames()
        {
            return Ok(await _gameRepository.GetAllGames());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<GameEntity>> GetGame(Guid id)
        {
            var game = await _gameRepository.GetGame(id);

            if (game is null)
                return NotFound();
            return Ok(game);
        }

        [HttpPost]
        public async Task<ActionResult<GameEntity>> CreateGame(Guid id, string name, string description, decimal price)
        {
            GameEntity game = await _gameRepository.CreateGame(id, name, description, price);

            if (game is null)
                return BadRequest("Game wasn't created.");

            return Ok(game);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<GameEntity>> UpdateGame(Guid id, [FromBody] GameEntity requestGame)
        {
            var game = await _gameRepository.UpdateGame(id, requestGame.Name, requestGame.Description, requestGame.Price);

            if (game is null)
                return BadRequest("Game with that ID wasn't found.");

            return Ok(game);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteGame(Guid id)
        {
            bool isDeleted = await _gameRepository.DeleteGame(id);

            if (!isDeleted)
                return BadRequest("Game with that ID wasn't found.");

            return Ok();
        }
    }
}
