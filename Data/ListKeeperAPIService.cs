using ListKeeperAPI.Models;
using System.Text.Json;

namespace ListKeeperUI.Data
{
    public class ListKeeperAPIService
    {
        
        private readonly HttpClient _client;

        public ListKeeperAPIService(HttpClient httpClient)
    {
        _client = httpClient;
    }

        public async Task<List<LKParentList>?> GetParentLists()
        {
            List<LKParentList>? parentLists = null;

            var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:7194/api/LKParentLists");
            var response = await _client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                if (content != null)
                {
                    parentLists = JsonSerializer.Deserialize<List<LKParentList>>(content);
                }
            }

            return parentLists;
        }
    }
}
