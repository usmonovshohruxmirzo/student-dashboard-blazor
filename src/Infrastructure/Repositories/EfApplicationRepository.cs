using Microsoft.EntityFrameworkCore;
using StudentManagement.Domain.Interfaces;
using StudentManagement.Infrastructure.Persistence;

namespace StudentManagement.Infrastructure.Repositories;

public class EfRepository<T, TKey> : IRepository<T, TKey>
    where T : class
{
  protected readonly ApplicationDbContext _context;
  protected readonly DbSet<T> _dbSet;

  public EfRepository(ApplicationDbContext context)
  {
    _context = context ?? throw new ArgumentNullException(nameof(context));
    _dbSet = _context.Set<T>();
  }

  public async Task<List<T>> GetAllAsync(CancellationToken ct = default)
  {
    return await _dbSet
        .AsNoTracking()
        .ToListAsync(ct);
  }

  public async Task<T?> GetByIdAsync(TKey id, CancellationToken ct = default)
  {
    return await _dbSet.FindAsync([id], ct);
  }

  public async Task AddAsync(T entity, CancellationToken ct = default)
  {
    ArgumentNullException.ThrowIfNull(entity);

    await _dbSet.AddAsync(entity, ct);
  }

  public void Update(T entity)
  {
    ArgumentNullException.ThrowIfNull(entity);

    _dbSet.Update(entity);
  }

  public void Remove(T entity)
  {
    ArgumentNullException.ThrowIfNull(entity);

    _dbSet.Remove(entity);
  }

  public async Task<bool> DeleteByIdAsync(TKey id, CancellationToken ct = default)
  {
    var entity = await GetByIdAsync(id, ct);

    if (entity is null)
    {
      return false;
    }

    _dbSet.Remove(entity);
    return true;
  }

  public Task<int> SaveChangesAsync(CancellationToken ct = default)
  {
    return _context.SaveChangesAsync(ct);
  }
}
