namespace Domain.Interfaces;

public interface IRepository<T>
{
    void Add(T entity);
    IEnumerable<T> GetAll();
}
