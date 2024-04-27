

namespace ShoppingDALLibrary
{
    public class Repository<K, T> : IRepository<K, T> where T : class
    {
        Dictionary<K, T> _items = new Dictionary<K, T>();
        private int LatestId = 0;
        public async Task<List<T>> GetAll()
        {
            return _items.Values.ToList();
        }

        public int GetLatestId()
        {
            return LatestId;
        }

        public async Task<T> GetById(K id)
        {
            if (_items.TryGetValue(id, out T item))
            {
                return item;
            }
            return null;
        }
        public void Add(K id, T entity)
        {
            LatestId +=1;
            if (_items.ContainsKey(id))
            {
                throw new IdAlreadyFoundException($"An item with ID {id} already exists.");
            }
            _items.Add(id, entity);
        }

        public void Update(K id, T entity)
        {
            if (_items.ContainsKey(id))
            {
                _items[id] = entity;
            }
            else
            {
                throw new IdNotFoundException($"Item with ID {id} not found.");
            }
        }
        public void Delete(K id)
        {
            if (_items.ContainsKey(id))
            {
                _items.Remove(id);
            }
            else
            {
                throw new IdNotFoundException($"Item with ID {id} not found.");
            }
        }
    }
}
