using Projects.LudumDare.Models;

namespace Projects.LudumDare.Services.Interfaces
{
    public interface ILudumDareService
    {
        public Task<UserProfile?> GetUserProfile(string username);

        public Task<GameFeed?> GetGameFeed(UserProfile userProfile);

        public Task<GameData?> GetGameData(GameFeed gameFeed);
    }
}
