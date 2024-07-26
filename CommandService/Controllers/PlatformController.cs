using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CommandService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformController : ControllerBase
    {

        // POST api/<PlatformController>
        [HttpPost]
        public ActionResult TestInBoundConnection()
        {
            Console.WriteLine("************* Inbound post from platform service");
            return Ok("platform controller receieved command successfully");
        }
    }
}
