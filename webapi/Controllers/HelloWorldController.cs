using Microsoft.AspNetCore.Mvc;
using webapi.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelloWorldController : ControllerBase
    {

        IHelloWorldService _helloWorldService;

        private readonly ILogger<HelloWorldController> _logger;

        public HelloWorldController(IHelloWorldService helloWorldService, ILogger<HelloWorldController> logger)
        {
            _helloWorldService = helloWorldService;
            _logger = logger;
        }


        [HttpGet("Get")]
        //[Route("[action]")]
        public IActionResult Get()
        {
            _logger.LogDebug("Agregando el Logging en API");
            return Ok(_helloWorldService.GetHelloWorld());
        }

        //// GET: api/<HelloWorldController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<HelloWorldController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<HelloWorldController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<HelloWorldController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<HelloWorldController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
