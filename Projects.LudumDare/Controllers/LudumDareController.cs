using Microsoft.AspNetCore.Mvc;

namespace Projects.LudumDare.Controllers
{
    [ApiController]
    [Route("Projects/[controller]")]
    public class LudumDareController : ControllerBase
    {

        private readonly ILogger<LudumDareController> _logger;

        public LudumDareController(ILogger<LudumDareController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("User/{username}")]
        public IActionResult Get(string username)
        {
            return Ok(username);
        }
    }
}