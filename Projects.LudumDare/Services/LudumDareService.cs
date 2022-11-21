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

        public async Task<UserProfileResponse?> GetUserProfile(string username)
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, $"https://api.ldjam.com/vx/node2/walk/1/users/{username}");

            var httpClient = _httpClientFactory.CreateClient();
            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

            UserProfileResponse? userProfileResponse = null;

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();
                userProfileResponse = await JsonSerializer.DeserializeAsync<UserProfileResponse>(contentStream);
            }

            return userProfileResponse;
        }
    }
}
