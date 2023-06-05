using Core.HttpDynamo;
using Projects.LudumDare.Models;
using Projects.LudumDare.Services.Interfaces;
using System.Text.Json;

namespace Projects.LudumDare.Services
{
    public class LudumDareService : ILudumDareService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public LudumDareService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<GameData?> GetGameData(GameFeed gameFeed)
        {
            if (gameFeed?.Feed == null)
                return null;

            var gameIds = gameFeed.Feed.Select(x => x.Id).ToArray();
            var gameIdsString = string.Join("+", gameIds);
            var gameData = await HttpDynamo.GetRequestAsync<GameData>(_httpClientFactory, $"https://api.ldjam.com/vx/node2/get/{gameIdsString}");

            foreach(Node node in gameData.Node)
            {
                node.Meta.Cover = ConvertToStaticImageUrl(node.Meta.Cover, 480, 384);
                var edition = int.Parse(node.Path.Split('/')[3]);
                var eventData = await GetEventData(edition);
                node.EventStats = await GetEventStats(eventData.NodeId);
                node.Edition = edition;
            }

            return gameData;
        }

        public async Task<GameFeed?> GetGameFeed(UserProfile userProfile)
        {
            var gameFeed = await HttpDynamo.GetRequestAsync<GameFeed>(_httpClientFactory, $"https://api.ldjam.com/vx/node/feed/{userProfile.NodeId}/authors/item/game");

            return gameFeed;
        }

        public async Task<UserProfile?> GetUserProfile(string username)
        {
            var userProfile = await HttpDynamo.GetRequestAsync<UserProfile>(_httpClientFactory, $"https://api.ldjam.com/vx/node2/walk/1/users/{username}");

            return userProfile;
        }

        public async Task<EventData> GetEventData(int edition)
        {
            var eventData = await HttpDynamo.GetRequestAsync<EventData>(_httpClientFactory, $"https://api.ldjam.com/vx/node2/walk/1/events/ludum-dare/{edition}/stats?node=&parent=&_superparent=&author=");

            return eventData;
        }

        public async Task<EventStats> GetEventStats(int editionId)
        {
            var eventStats = await HttpDynamo.GetRequestAsync<EventStats>(_httpClientFactory, $"https://api.ldjam.com/vx/stats/{editionId}");

            return eventStats;
        }

        private string ConvertToStaticImageUrl(string imageUrl, int width, int height)
        {
            var baseUrl = "https://static.jam.host/";
            imageUrl = imageUrl?.Substring(3, imageUrl.Length - 3);
            var size = $"{width.ToString()}x{height.ToString()}";
            var endUrl = $".{size}.fit.jpg";

            return baseUrl + imageUrl + endUrl;
        }
    }
}
