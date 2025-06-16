using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DAL.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    protected AppDbContext _db;

    public DbSet<T> Set
    {
        get;
        private set;
    }

    public Repository(AppDbContext db)
    {
        _db = db;
        var set = _db.Set<T>();
        set.Load();

        Set = set;
    }

  
    public virtual async Task<IEnumerable<T>> GetAllAsync()
    {
        return await Set.ToListAsync(); 
    }
    public virtual async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = Set;

        foreach (var include in includes)
        {
            query = query.Include(include);
        }

        return await query.ToListAsync();
    }


    public async Task<T?> GetByIdAsync(int id)
    {
        return await Set.FindAsync(id);
    }

    public async Task AddAsync(T entity)
    {
        await Set.AddAsync(entity);
        await _db.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)

    {
        Set.Update(entity);
        await _db.SaveChangesAsync();
    }

    public async Task DeleteAsync(T Item)
    {
        Set.Remove(Item);
        await _db.SaveChangesAsync();
    }

}

