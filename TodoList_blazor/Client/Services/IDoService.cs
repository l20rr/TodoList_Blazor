using TodoList_blazor.Shared;

namespace TodoList_blazor.Client.Services
{
    public interface IDoService
    {
        Task<IEnumerable<Do>> GetDos();
        Task<Do> GetDoId(int id);
        Task<Do> AddDo(Do dos);
        Task DeleteDo(int id);
    }
}
