using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WAPIMk2.Models;

namespace WAPIMk2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [BindProperties(SupportsGet = true)]
    // BindProperties is an attribute and it is used to map incoming form-data to public properties.
    // BindProperties does not work on HttpGet Request. It is applied on the controller level.
    // Adding SupportsGet will enable it to work with HttpGet Request and binding the data coming from the form-data.
    public class Countries2Controller : ControllerBase
    {
        // BindProperties also works with complex types.
        public CountriesModel Countries { get; set; }
        //public string Name { get; set; }
        //public int Population { get; set; }
        //public string Area { get; set; }

        //[HttpPost]
        [HttpGet]
        public IActionResult Country()
        {
            return Ok($"Name: {this.Countries.Name} " +
                $"Population: {this.Countries.Population} " +
                $"Area: {this.Countries.Area}");
        }
    }
}
