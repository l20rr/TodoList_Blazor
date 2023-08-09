using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using TodoList_blazor.Shared;

namespace TodoList_blazor.Client.Services
{
    public class DoService : IDoService
    {
        private readonly HttpClient _httpClient;

        public DoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Do> AddDo(Do dos)
        {
            var result = await _httpClient.PostAsJsonAsync("api/dos", dos);
            if (result.IsSuccessStatusCode)
            {
                return await result.Content.ReadFromJsonAsync<Do>();
            }
            return null;
        }

        public async Task DeleteDo(int id)
        {
            await _httpClient.DeleteAsync($"api/dos/{id}");
        }

        public async Task<Do> GetDoId(int id)
        {
            return await JsonSerializer.DeserializeAsync<Do>
              (await _httpClient.GetStreamAsync($"api/users/{id}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });


        }

        public async Task<IEnumerable<Do>> GetDos()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<Do>>
                 (await _httpClient.GetStreamAsync($"api/dos"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task UpdateDo(Do dos, int id)
        {
            var doJson =
                  new StringContent(JsonSerializer.Serialize(dos), Encoding.UTF8, "application/json");
            await _httpClient.PutAsync($"api/dos/{id}", doJson);
        }
    }
}
