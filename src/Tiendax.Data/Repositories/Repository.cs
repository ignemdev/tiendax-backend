using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tiendax.Core.Repositories;

namespace Tiendax.Data.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    private readonly TiendaxContext _db;
    private DbSet<TEntity> dbSet;
    public Repository(TiendaxContext db)
    {
        _db = db;
        dbSet = _db.Set<TEntity>();
    }
    public async Task AddAsync(TEntity entity)
    {
        await dbSet.AddAsync(entity);
    }

    public async Task AddRangeAsync(IEnumerable<TEntity> entities)
    {
        await dbSet.AddRangeAsync(entities);
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null!, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null!, string includeProperties = null!)
    {
        IQueryable<TEntity> query = dbSet;

        if (predicate is not null)
            query = query.Where(predicate);

        if (includeProperties is not null)
        {
            foreach (var property in includeProperties.Split(',', StringSplitOptions.RemoveEmptyEntries))
                query = query.Include(property);
        }

        if (orderBy is not null)
            return await orderBy(query).ToListAsync();

        return await query.ToListAsync();
    }

    public async Task<TEntity> GetByIdAsync(int id)
    {
        return await dbSet.FindAsync(id);
    }

    public async Task<TEntity> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate = null!, string includeProperties = null!)
    {
        IQueryable<TEntity> query = dbSet;

        if (predicate is not null)
            query = query.Where(predicate);

        if (includeProperties is not null)
        {
            foreach (var property in includeProperties.Split(',', StringSplitOptions.RemoveEmptyEntries))
                query = query.Include(property);
        }

        return await query.FirstOrDefaultAsync();
    }

    public void Remove(TEntity entity)
    {
        dbSet.Remove(entity);
    }

    public void RemoveById(int id)
    {
        var dbEntity = dbSet.Find(id);
        Remove(dbEntity);
    }

    public void RemoveRange(IEnumerable<TEntity> entities)
    {
        dbSet.RemoveRange(entities);
    }
}
