namespace MyLibrary.Data.Repositories;

public abstract class RepositoryBase<T>
{
    protected List<T> _dataStore = new List<T>();
    public virtual IEnumerable<T> GetAll() => _dataStore;
    public virtual void Add(T item) => _dataStore.Add(item);
    public virtual void Update(T item) { }
    public virtual void Delete(T item) => _dataStore.Remove(item);
}