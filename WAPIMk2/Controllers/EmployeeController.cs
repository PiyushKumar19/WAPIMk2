using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WAPIMk2.Models;

namespace WAPIMk2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        // IActionResult is able to return multiple types of responses. Such as NotFound, Redirect or a View.
        [Route("{id}")]
        public IActionResult GetEmployee(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            return Ok(new EmployeeModel() { Id = 1, Name = "Piyush", City = "Delhi"});;
        }

        public IEnumerable<EmployeeModel> AllEmployees()
        {
            return new List<EmployeeModel>()
            {
                new EmployeeModel() { Id = 1, Name = "Piyush", City = "Delhi" },
                new EmployeeModel() {Id = 2, Name = "Gaurav", City = "Noida"}
            };
        }

        // ActionResult is used to return any paricular type of response or values.
        [Route("{id}/basic")]
        public ActionResult<EmployeeModel> GetEmployeeBasics(int id)
        {
            return new EmployeeModel() { Id = 1, Name = "Piyush"};
        }
    }
}
