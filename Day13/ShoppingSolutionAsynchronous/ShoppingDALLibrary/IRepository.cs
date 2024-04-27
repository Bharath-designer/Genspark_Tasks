
namespace ShoppingDALLibrary
{
    public interface IRepository<K, T>
    {
        Task<T> GetById(K id);
        Task<List<T>> GetAll();
        void Add(K id, T entity);
        void Update(K id, T entity);
        void Delete(K id);
        int GetLatestId();
    }
}
