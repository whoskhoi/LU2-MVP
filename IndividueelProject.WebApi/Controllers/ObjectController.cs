using System.Data;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using IndividueelProject.WebApi.Models;
using IndividueelProject.WebApi.Dtos;
using IndividueelProject.WebApi.Repositories;
using BCrypt.Net;

namespace IndividueelProject.WebApi.Controllers
{
    [Route("api/object")]
    [ApiController]
    public class ObjectController : ControllerBase
    {
        private readonly WorldRepository worldRepo;
        private readonly ObjectRepository objectRepo;

        public ObjectController(WorldRepository _worldRepo, ObjectRepository _objectRepo)
        {
            worldRepo = _worldRepo;
            objectRepo = _objectRepo;
        }

        // GET api/object/world/5 (id)
        [HttpGet("world/{worldId}")]
        public ActionResult GetAllObjects(int worldId)
        {
            var existingWorld = worldRepo.GetByWorldId(worldId);
            if (existingWorld == null)
                return NotFound("World not found");

            var objects = objectRepo.GetAllObjects(worldId);
            return Ok(objects);

        }

        // GET api/object/5 
        // obj = object
        [HttpGet("{id}")]
        public ActionResult GetByObject(int id)
        {
            var obj = objectRepo.GetByObject(id);
            if (obj == null)
                return NotFound("Object not found");

            return Ok(obj);

        }

        // POST api/object
        [HttpPost]
        public ActionResult CreateObject([FromBody] CreateUpdateObjectDto objectDto)
        {
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);

            var existingWorld = worldRepo.GetByWorldId(objectDto.WorldId);
            if (existingWorld == null)
                return NotFound("World not found");

            var obj = new ObjectModel
            {
                Type = objectDto.Type,
                PositionX = objectDto.PositionX,
                PositionY = objectDto.PositionY
            };

            objectRepo.CreateObject(obj);
                return Ok(new { message = "Object created"});
        }

        //  PUT api/object/5
        [HttpPut("{id}")]
        public ActionResult UpdateObject(int id, [FromBody] CreateUpdateObjectDto objectDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingObject = objectRepo.GetByObject(id);
            if (existingObject == null)
                return NotFound();

            var existingWorld = worldRepo.GetByWorldId(objectDto.WorldId);
            if (existingWorld == null)
                return NotFound(new { message = "World not found"});

            existingObject.Type = objectDto.Type;
            existingObject.PositionX = objectDto.PositionX;
            existingObject.PositionY = objectDto.PositionY;

            objectRepo.UpdateObject(existingObject);
            return Ok(new { message = "Object updated" });

        }

        // DELETE api/object/5
        [HttpDelete("{id}")]
        public ActionResult DeleteObject(int id)
        {
            var existingObject = objectRepo.GetByObject(id);
            if (existingObject == null)
                return NotFound();

            objectRepo.DeleteObject(existingObject);
            return Ok(new { message = "Object deleted" });

        }

        
        
        

    }
}
