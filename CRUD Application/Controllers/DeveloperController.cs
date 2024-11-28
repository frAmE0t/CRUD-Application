using CRUD_Application.Records;
using GamesMarket.DataContext.Entities;
using GamesMarket.DataContext.Interfaces;
using GamesMarket.DataContext.Repository;
using GamesMarket.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeveloperController : ControllerBase
    {
        private readonly IDeveloperRepository _developerRepository;

        public DeveloperController(IDeveloperRepository developerRepository)
        {
            _developerRepository = developerRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<DeveloperRecord>?>> GetAllDevelopers()
        {
            List<DeveloperEntity> developersList = await _developerRepository.GetAllDevepers();
            List<DeveloperRecord>? recordsList = null;

            if (developersList is not null)
            {
                recordsList = new();

                foreach (DeveloperEntity developer in developersList)
                {
                    DeveloperRecord record = new(developer.Id, developer.Name);
                    recordsList.Add(record);
                }
            }
            return Ok(recordsList);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<DeveloperRecord>> GetDeveloper(Guid id)
        {
            var developer = await _developerRepository.GetDeveper(id);

            if (developer is null)
                return NotFound("Developer with that ID wasn't found");

            DeveloperRecord record = new(developer.Id, developer.Name);
            return Ok(record);
        }

        [HttpPost]
        public async Task<ActionResult<DeveloperRecord>> CreateDeveloper([FromBody] Developer developer)
        {
            var entity = await _developerRepository.CreateDeveper(developer.Id, developer.Name);

            if (entity is null)
                return BadRequest("Developer was not created");

            DeveloperRecord record = new(entity.Id, entity.Name);
            return Ok(record);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteDeveloper(Guid id)
        {
            bool isDeleted = await _developerRepository.DeleteDeveper(id);

            if (!isDeleted)
                return NotFound("Developer with that ID wasn't found");
            return Ok();
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<DeveloperRecord>> UpdateDeveloper(Developer developer)
        {
            var updatedDeveloper = await _developerRepository.UpdateDeveper(developer.Id, developer.Name);

            if (updatedDeveloper is null)
                return BadRequest("Developer wasn't updated");

            DeveloperRecord record = new(updatedDeveloper.Id, updatedDeveloper.Name);
            return Ok(record);
        }
    }
}
