using TodoList_blazor.Shared;

namespace TodoList_blazor.API.Model
{
    public class DoModel : IDoModel
    {
        private readonly AppDbContext _appDbContext;

        public DoModel(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<Do> AddDo(Do dos)
        {
           var result = await _appDbContext.Dos.AddAsync(dos);  
            await _appDbContext.SaveChangesAsync();

            return result.Entity;
        }

        public void DeleteDo(int id)
        {
           var foundDo = _appDbContext.Dos.FirstOrDefault(d => d.DoId == id);   
            if (foundDo != null)
            {
                _appDbContext.Dos.Remove(foundDo);
                _appDbContext.SaveChanges();
            }
        }

        public Do GetDo(int id)
        {
            return _appDbContext.Dos.FirstOrDefault(x => x.DoId == id);
        }

        public IEnumerable<Do> GetDos()
        {
            return _appDbContext.Dos;
        }
    }
}
