using System.Data;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using IndividueelProject.WebApi.Models;
using IndividueelProject.WebApi.Dtos;
using IndividueelProject.WebApi.Repositories;
using BCrypt.Net;

namespace IndividueelProject.WebApi.Controllers
{

    [Route("api/world")]
    [ApiController]
    public class WorldController : ControllerBase
    {
        private readonly WorldRepository worldRepo;
        public WorldController(WorldRepository _worldRepo)
        {
            worldRepo = _worldRepo;
        }

        // GET api/world
        [HttpGet]
        public ActionResult GetAllWorlds()
        {
            var worlds = worldRepo.GetAllWorlds();
            return Ok(worlds);
        }

        // GET api/world/5 (example of id 5)
        [HttpGet("{id}")]
        public ActionResult GetWorldById(int id)
        {
            var world = worldRepo.GetByWorldId(id);
            if (world == null)
                return NotFound();

            return Ok(world);
        }

        // POST api/world
        [HttpPost]
        public ActionResult Create([FromBody] CreateUpdateWorldDto worldDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {


                var world = new WorldModel
                {
                    Name = worldDto.Name
                };

                worldRepo.CreateWorld(world);
                return Ok(new { message = "World created" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occured while creating the world. you donut" + ex);
            }
        }

        // PUT api/world/5 (id)
        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] CreateUpdateWorldDto worldDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            var existingWorld = worldRepo.GetByWorldId(id);
            if (existingWorld == null)
                return NotFound();

            existingWorld.Name = worldDto.Name;

            worldRepo.UpdateWorld(existingWorld);
            return Ok(new { message = "World updated" });

        }

        // DELETE api/world/5 (id)
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var existingWorld = worldRepo.GetByWorldId(id);
            if (existingWorld == null)
                return NotFound();

            worldRepo.DeleteWorld(existingWorld);
            return Ok(new { message = "World deleted" });
        }

    }
}
