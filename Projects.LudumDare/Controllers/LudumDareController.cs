using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using Projects.LudumDare.Models;
using Projects.LudumDare.Services.Interfaces;
using Projects.LudumDare.ViewModels;
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
        [Route("GameData/{username}")]
        public async Task<IActionResult> GetGameDataByUsername(string username)
        {
            var userProfile = await _ludumDareService.GetUserProfile(username);

            if (userProfile?.NodeId != null && userProfile.NodeId == 2)
                return NotFound($"User {username} not found");

            var gameFeed = await _ludumDareService.GetGameFeed(userProfile);
            var gameData = await _ludumDareService.GetGameData(gameFeed);

            var gameDataViewModel = new LudumDareGameData
            {
                Games = new List<Game>()
            };

            foreach (var node in gameData.Node)
            {
                var categoryCompetitors = node.EventStats.Stats.GetCompetitors(node.Subsubtype);
                gameDataViewModel.Games.Add(new Game
                {
                    Cover = node.Meta.Cover,
                    Path = node.Path,
                    Name = node.Name,
                    Format = node.Subsubtype,
                    SubmittedDate = node.NodeTimestamp,
                    Overall = new Category
                    {
                        TotalScore = node.Grade.Grade01,
                        Result = node.Magic.Grade01Result,
                        AverageScore = node.Magic.Grade01Average,
                        Percentile = Category.CalculatePercentile(categoryCompetitors, node.Magic.Grade01Result)
                    },
                    Fun = new Category
                    {
                        TotalScore = node.Grade.Grade02,
                        Result = node.Magic.Grade02Result,
                        AverageScore = node.Magic.Grade02Average,
                        Percentile = Category.CalculatePercentile(categoryCompetitors, node.Magic.Grade02Result)
                    },
                    Innovation = new Category
                    {
                        TotalScore = node.Grade.Grade03,
                        Result = node.Magic.Grade03Result,
                        AverageScore = node.Magic.Grade03Average,
                        Percentile = Category.CalculatePercentile(categoryCompetitors, node.Magic.Grade03Result)
                    },
                    Theme = new Category
                    {
                        TotalScore = node.Grade.Grade04,
                        Result = node.Magic.Grade04Result,
                        AverageScore = node.Magic.Grade04Average,
                        Percentile = Category.CalculatePercentile(categoryCompetitors, node.Magic.Grade04Result)
                    },
                    Graphics = new Category
                    {
                        TotalScore = node.Grade.Grade05,
                        Result = node.Magic.Grade05Result,
                        AverageScore = node.Magic.Grade05Average,
                        Percentile = Category.CalculatePercentile(categoryCompetitors, node.Magic.Grade05Result)
                    },
                    Audio = new Category
                    {
                        TotalScore = node.Grade.Grade06,
                        Result = node.Magic.Grade06Result,
                        AverageScore = node.Magic.Grade06Average,
                        Percentile = Category.CalculatePercentile(categoryCompetitors, node.Magic.Grade06Result)
                    },
                    Humor = new Category
                    {
                        TotalScore = node.Grade.Grade07,
                        Result = node.Magic.Grade07Result,
                        AverageScore = node.Magic.Grade07Average,
                        Percentile = Category.CalculatePercentile(categoryCompetitors, node.Magic.Grade07Result)
                    },
                    Mood = new Category
                    {
                        TotalScore = node.Grade.Grade08,
                        Result = node.Magic.Grade08Result,
                        AverageScore = node.Magic.Grade08Average,
                        Percentile = Category.CalculatePercentile(categoryCompetitors, node.Magic.Grade08Result)
                    },
                    Edition = node.Edition,
                    CategoryCompetitors = categoryCompetitors
                });
            }

            return Ok(gameDataViewModel);
        }

        [HttpGet]
        [Route("Stats/Overall")]
        public async Task<IActionResult> GetOverallLudumDareStats([FromQuery] List<int> ludumDareEdition)
        {
            var stats = new Dictionary<int, EventStats>();
            foreach(int id in ludumDareEdition)
            {
                var eventData = await _ludumDareService.GetEventData(id);
                var eventStats = await _ludumDareService.GetEventStats(eventData.NodeId);
                stats[id] = eventStats;
            }

            return Ok(stats);
        }
    }
}