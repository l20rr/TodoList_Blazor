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

        public Task<Do> AddDo(Do dos)
        {
            throw new NotImplementedException();
        }

        public Task DeleteDo(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Do> GetDoId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Do>> GetDos()
        {
            throw new NotImplementedException();
        }
    }
}
