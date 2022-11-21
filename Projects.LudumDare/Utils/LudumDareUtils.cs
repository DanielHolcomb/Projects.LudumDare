using System.Text.Json;

namespace Projects.LudumDare.Utils
{
    public class LudumDareUtils
    {
        public async static Task<T?> SendLudumDareRequestAsync<T>(IHttpClientFactory _httpClientFactory, string url)
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, url);

            var httpClient = _httpClientFactory.CreateClient();
            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

             var result = default(T);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();
                result = await JsonSerializer.DeserializeAsync<T>(contentStream);
            }

            return result;
        }
    }
}
