using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

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
        var g = await Set.ToListAsync(); 
        return g;
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

