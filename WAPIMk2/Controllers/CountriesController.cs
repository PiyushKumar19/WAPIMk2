using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WAPIMk2.Models;

namespace WAPIMk2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        // Bind property is an attribute property that takes the input from the from and bind it to the property that can be accessed by methods.
        // [BindProperty]
        // public string Name { get; set; }
        // [BindProperty]
        // public int Population { get; set; }
        // [BindProperty]
        // public string Area { get; set; }

        // Property binding can be done like above or we can simply bind the properties of a model class.\
        //[BindProperty]
        // SupportsGet is used to make use the BindProperty at Get Method.
        [BindProperty(SupportsGet = true)]
        public CountriesModel Countries { get; set; }

        //[HttpPost]
        [HttpGet]
        public IActionResult Country()
        {
            return Ok($"Name: {this.Countries.Name} "+
                $"Population: {this.Countries.Area} "+
                $"Area: {this.Countries.Area}");
        }
    }
}
