using System.Collections;

namespace DoctorClinicApp.Repositories
{
    public interface IRepository<T, K> where T : class
    {
        public Task<T> GetById(K id);
        public Task<List<T>> GetAll();
        public Task Add(T entity);
        public Task Update(T entity);
        public Task Delete(K id);

    }
}
