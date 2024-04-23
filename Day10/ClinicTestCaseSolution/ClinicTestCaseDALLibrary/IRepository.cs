namespace ClinicTestCaseDALLibrary
{
    public interface IRepository<K, T>
    {
        List<T> GetAll();
        T GetById(K id);
        T Add(T entity);
        T Update(T entity);
        T Delete(K entity);
    }
}
