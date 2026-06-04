namespace StudentManagement.Domain.Interfaces;

public interface IRepository<T, TKey> where T : class
{
  Task<List<T>> GetAllAsync(CancellationToken ct = default);
  Task<T?> GetByIdAsync(TKey id, CancellationToken ct = default);
  Task AddAsync(T entity, CancellationToken ct = default);
  void Update(T entity);
  void Remove(T entity);
  Task<bool> DeleteByIdAsync(TKey id, CancellationToken ct = default);
  Task<int> SaveChangesAsync(CancellationToken ct = default);
}
