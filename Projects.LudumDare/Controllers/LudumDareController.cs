using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        public async Task<IActionResult> GetUserProfileId(string username)
        {
            var userProfile = await _ludumDareService.GetUserProfile(username);

            if(userProfile?.NodeId != null && userProfile.NodeId == 2)
                return NotFound($"User {username} not found");

            return Ok(userProfile);
        }

        [HttpPost]
        [Route("Games/Feed")]
        [Authorize]
        public async Task<IActionResult> GetGamesByUserId([FromBody] UserProfile userProfile)
        {
            var gameFeed = await _ludumDareService.GetGameFeed(userProfile);

            return Ok(gameFeed);
        }

        [HttpPost]
        [Route("Games/Data")]
        [Authorize]
        public async Task<IActionResult> GetGameDataByIds([FromBody] GameFeed gameFeed)
        {
            var gameData = await _ludumDareService.GetGameData(gameFeed);

            return Ok(gameData);
        }

        [HttpGet]
        [Route("Games/{username}")]
        public async Task<IActionResult> GetGamesByUsername(string username)
        {
            var userProfile = await _ludumDareService.GetUserProfile(username);

            if (userProfile?.NodeId != null && userProfile.NodeId == 2)
                return NotFound($"User {username} not found");

            var gameFeed = await _ludumDareService.GetGameFeed(userProfile);
            var gameData = await _ludumDareService.GetGameData(gameFeed); 

            return Ok(gameData);
        }

        [HttpGet]
        [Route("Stats/Overall/{ludumDareEdition}")]
        public async Task<IActionResult> GetOverallLudumDareStats(int ludumDareEdition)
        {
            var eventData = await _ludumDareService.GetEventData(ludumDareEdition);
            var eventStats = await _ludumDareService.GetEventStats(eventData.NodeId);

            return Ok(eventStats.Stats);
        }
    }
}