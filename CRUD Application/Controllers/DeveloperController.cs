﻿using GamesMarket.DataContext.Entities;
using GamesMarket.DataContext.Interfaces;
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
        public async Task<ActionResult<List<DeveloperEntity>?>> GetAllDevelopers()
        {
            return Ok(await _developerRepository.GetAllDevepers());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<DeveloperEntity>> GetDeveloper(Guid id)
        {
            var developer = await _developerRepository.GetDeveper(id);

            if (developer is null)
                return NotFound("Developer with that ID wasn't found");
            return Ok(developer);
        }

        [HttpPost]
        public async Task<ActionResult<DeveloperEntity>> CreateDeveloper([FromBody] DeveloperEntity developer)
        {
            return Ok(await _developerRepository.CreateDeveper(developer));
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
        public async Task<ActionResult<DeveloperEntity>> UpdateDeveloper(Guid id, [FromBody] DeveloperEntity developer)
        {
            var updatedDeveloper = await _developerRepository.UpdateDeveper(id, developer.Name);

            if (updatedDeveloper is null)
                return BadRequest("Developer wasn't updated");
            return Ok(updatedDeveloper);
        }
    }
}
