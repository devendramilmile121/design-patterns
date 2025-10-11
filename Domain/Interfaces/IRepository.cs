namespace Domain.Interfaces;
/// <summary>
/// Defines a generic repository for managing entities of type <typeparamref name="T"/>.
/// </summary>
/// <remarks>This interface provides basic functionality for adding entities and retrieving all entities. It is
/// intended to be implemented by classes that provide data access logic for a specific entity type.</remarks>
/// <typeparam name="T">The type of entity managed by the repository.</typeparam>
public interface IRepository<T>
{
    void Add(T entity);
    IEnumerable<T> GetAll();
}
