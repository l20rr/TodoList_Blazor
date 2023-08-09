using TodoList_blazor.Shared;

namespace TodoList_blazor.API.Model
{
    public interface IDoModel
    {
        IEnumerable<Do> GetDos();   

        Do GetDo(int id);

        Task<Do> AddDo(Do dos);

        Task DeleteAll();

        void DeleteDo(int id);  

        Do UpdateDo(Do dos);      

    }
}
