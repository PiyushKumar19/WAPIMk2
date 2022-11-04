using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WAPIMk2.Models;

namespace WAPIMk2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        [Route("")]
        public IActionResult GetAnimals()
        {
            var animals = new List<AnimalModel>()
            {
                new AnimalModel() {Id = 1, Name = "Lion"},
                new AnimalModel() {Id = 2, Name = "Tiger"},
            };
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
            return Accepted(animals);
        }
    }
}
