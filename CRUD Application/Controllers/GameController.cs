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
        public async Task<List<GameEntity>?> GetAllGames()
        {
            return await _gameRepository.GetAllGames();
        }

        [HttpGet("{id}")]
        public async Task<GameEntity?> GetGame(Guid id)
        {
            return await _gameRepository.GetGame(id);
        }
    }
}
