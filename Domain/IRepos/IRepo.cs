using RegisterSystem.Domain.AbstractEntities;

namespace RegisterSystem.Domain.IRepos
{
    public interface IRepo<T> : IFuturePastRepo<T> where T : UniqueEntity { }
    public interface IFuturePastRepo<T> : ICrudRepo<T> where T : UniqueEntity 
    {

        //List<T> GetFuture();
        //List<T> GetPast();
    }
    public interface ICrudRepo<T> : IBaseRepo<T> where T : UniqueEntity { }
    public interface IBaseRepo<T> where T : UniqueEntity
    {
        bool Add(T obj);
        List<T> Get();
        List<T> GetAll(Func<T, dynamic>? orderBy = null);
        T Get(string id);
        bool Update(T obj);
        bool Delete(string id);

        Task<bool> AddAsync(T obj);
        Task<List<T>> GetAsync();
        Task<T> GetAsync(string id);
        Task<bool> UpdateAsync(T obj);
        Task<bool> DeleteAsync(string id);
    }
}
