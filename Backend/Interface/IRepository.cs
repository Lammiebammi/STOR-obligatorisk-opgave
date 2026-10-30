namespace Backend.Interface
{
    public interface IRepository<T, K>
    {
        public T GetByKey(K key);
        public IEnumerable<T> GetAll();
        public T Delete(K key);
        public T Add(T toAdd);
        public T Edit(K key, T newInfo);
    }
}
