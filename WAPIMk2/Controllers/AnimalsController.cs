using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WAPIMk2.Models;

namespace WAPIMk2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private readonly List<AnimalModel> animals = null;
        public AnimalController()
        {
            animals = new List<AnimalModel>()
            {
                new AnimalModel() {Id = 1, Name = "Lion"},
                new AnimalModel() {Id = 2, Name = "Tiger"},
            };
        }
        [Route("")]
        public IActionResult GetAnimals()
        {
            // Ok is for returning 200 success code.
            return Ok(animals);
        }
        [Route("test")]
        public IActionResult GetAnimalsTest()
        {
            var animals = new List<AnimalModel>()
            {
                new AnimalModel() {Id = 1, Name = "Lion"},
                new AnimalModel() {Id = 2, Name = "Tiger"},
            };
            // Accepted method is used to return 202 success code.
            return Accepted("~api/animal");
        }

        [HttpGet("{id}")]
        public IActionResult GetAnimalById(int id)
        {
            if(id == 0)
            {
                return BadRequest();
            }
            return Ok(animals.FirstOrDefault(x => x.Id == id));
        }
        [HttpPost("")]
        public IActionResult CreateAnimal(AnimalModel model)
        {
            animals.Add(model);
            return Created("~api/animals/"+model.Id, animals);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var model = animals.Find(x => x.Id == id);
            if (model == null)
            {
                return BadRequest();
            }
            animals.Remove(model);
            return Ok();
        }
    }
}
