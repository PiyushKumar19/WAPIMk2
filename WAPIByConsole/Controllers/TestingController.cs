using Microsoft.AspNetCore.Mvc;

namespace WAPIByConsole.Controllers
{
    [ApiController]
    // Adding the /{action} in Route attribute we have removed the ambiguity error of the controller methods.
    [Route("test/{action}")]
    public class TestingController: ControllerBase
    {
        public string Get()
        {
            return "Hello from an api controller.";
        }

        public string Get1()
        {
            return "Hello from Get1() of an api controller test.";
        }
    }
}
