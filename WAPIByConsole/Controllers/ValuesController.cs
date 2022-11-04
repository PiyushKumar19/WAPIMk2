using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WAPIByConsole.Controllers
{
    [Route("api/[controller]")]
    //[Route("{controller}/{action}")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // This is an example of token replacement. Routing this way makes the url configured according to controller and action.
        //[Route("{controller}/{action}")]
        public string Get1()
        {
            return "Hello from Get1 from Values Controller.";
        }

        // Routing with dynamic property.
        // In this method the route has id parameter with {} which takes the dynamic parameters.
        [Route("Get/{id}")]
        public string Get2(int id)
        {
            return "Hello from Get2 id={id}";
        }

        // This method for testing QueryString, that is used for running the url with only passing some arguements of the multiple parameters. It can be done by add ?before passing the arguements in the url.
        [Route("Greet")]
        public string Get3(int id, string? name, string? city)
        {
            return "Hello {name} from {city}.";
        }

    }
}
