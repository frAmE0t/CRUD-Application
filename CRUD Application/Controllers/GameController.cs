using CRUD_Application.Records;
using GamesMarket.DataContext.Entities;
using GamesMarket.DataContext.Interfaces;
using GamesMarket.Models;
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
        public async Task<ActionResult<List<GameRecord>?>> GetAllGames()
        {
            List<GameEntity> gamesList = await _gameRepository.GetAllGames();
            List<GameRecord>? recordsList = null;
            
            if (gamesList is not null)
            {
                recordsList = new();

                foreach (GameEntity game in gamesList)
                {
                    GameRecord record = new(game.Id, game.Name, game.Description, game.Price, game.DeveloperId);
                    recordsList.Add(record);
                }
            }
            return Ok(recordsList);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<GameRecord>> GetGame(Guid id)
        {
            var game = await _gameRepository.GetGame(id);

            if (game is null)
                return NotFound();
            
            GameRecord record = new(game.Id, game.Name, game.Description, game.Price, game.DeveloperId);
            return Ok(record);
        }

        [HttpPost]
        public async Task<ActionResult<GameRecord>> CreateGame([FromBody] Game game)
        {
            GameEntity createdGame = await _gameRepository.CreateGame(game.Id, game.Name, game.Description, game.Price, game.DeveloperId);
            GameRecord record = new(createdGame.Id, createdGame.Name, createdGame.Description, createdGame.Price, createdGame.DeveloperId);
            
            return Ok(record);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<GameRecord>> UpdateGame([FromBody] Game game)
        {
            var updatedGame = await _gameRepository.UpdateGame(game.Id, game.Name, game.Description, game.Price, game.DeveloperId);

            if (updatedGame is null)
                return BadRequest("Game with that ID wasn't found.");

            GameRecord record = new(updatedGame.Id, updatedGame.Name, updatedGame.Description, updatedGame.Price, updatedGame.DeveloperId);
            
            return Ok(record);
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
