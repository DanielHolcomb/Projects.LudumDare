using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using Projects.LudumDare.Models;
using Projects.LudumDare.Services.Interfaces;
using System.Text.Json;

namespace Projects.LudumDare.Controllers
{
    [ApiController]
    [Route("Projects/[controller]")]
    public class LudumDareController : ControllerBase
    {
        private readonly ILudumDareService _ludumDareService;
        private readonly ILogger<LudumDareController> _logger;

        public LudumDareController(ILogger<LudumDareController> logger, ILudumDareService ludumDareService)
        {
            _logger = logger;
            _ludumDareService = ludumDareService;
        }

        [HttpGet]
        [Route("User/{username}")]
        public async Task<IActionResult> GetUserProfileId(string username)
        {
            var userProfileResponse = await _ludumDareService.GetUserProfile(username);

            if(userProfileResponse?.NodeId != null && userProfileResponse.NodeId == 2)
                return NotFound($"User {username} not found");

            return Ok(userProfileResponse);
        }
    }
}