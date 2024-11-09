using System.Linq.Expressions;
using BdHelper.DbContext;
using Microsoft.EntityFrameworkCore;

namespace BdHelper;

public class Controller(AssistantContext assistantContext)
{
    private AssistantContext _assistantContext = assistantContext;

    public async Task<IEnumerable<T>> LoadAsync<T>() where T : class
    {
        return await _assistantContext.Set<T>().ToListAsync();
    }
    
    public async Task<T> AddAsync<T>(T entity) where T : class
    {
        await _assistantContext.Set<T>().AddAsync(entity);
        await _assistantContext.SaveChangesAsync();
        return entity;
    }
    public async Task<T> UpdateAsync<T>(T entity) where T : class
    {
        _assistantContext.Set<T>().Update(entity);
        await _assistantContext.SaveChangesAsync();
        return entity;
    }
    public async Task<bool> DeleteAsync<T>(object id) where T : class
    {
        var entity = await _assistantContext.Set<T>().FindAsync(id);
        if (entity == null)
        {
            return false;
        }
    
        _assistantContext.Set<T>().Remove(entity);
        await _assistantContext.SaveChangesAsync();
    
        return true;
    }
    public async Task<T> GetByIdAsync<T>(object id) where T : class
    {
        return await _assistantContext.Set<T>().FindAsync(id);
    }
    public async Task<IEnumerable<T>> FindAsync<T>(Func<T, bool> predicate) where T : class
    {
        return await Task.Run(() => _assistantContext.Set<T>().Where(predicate).ToList());
    }
    public async Task<IEnumerable<T>> FindAsync<T>(Expression<Func<T, bool>> predicate) where T : class
    {
        return await _assistantContext.Set<T>().Where(predicate).ToListAsync();
    }
    public async Task<IEnumerable<T>> GetPagedAsync<T>(int pageNumber, int pageSize) where T : class
    {
        return await _assistantContext.Set<T>()
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }
    public async Task<bool> ExistsAsync<T>(Expression<Func<T, bool>> predicate) where T : class
    {
        return await _assistantContext.Set<T>().AnyAsync(predicate);
    }
    public async Task<T> FirstOrDefaultAsync<T>(Expression<Func<T, bool>> predicate) where T : class
    {
        return await _assistantContext.Set<T>().FirstOrDefaultAsync(predicate);
    }
    public async Task<int> CountAsync<T>(Expression<Func<T, bool>> predicate = null) where T : class
    {
        if (predicate == null)
        {
            return await _assistantContext.Set<T>().CountAsync();
        }
        else
        {
            return await _assistantContext.Set<T>().CountAsync(predicate);
        }
    }
    public async Task SaveChangesAsync()
    {
        await _assistantContext.SaveChangesAsync();
    }
    public async Task AddRangeAsync<T>(IEnumerable<T> entities) where T : class
    {
        await _assistantContext.Set<T>().AddRangeAsync(entities);
        await _assistantContext.SaveChangesAsync();
    }
    public async Task DeleteRangeAsync<T>(IEnumerable<T> entities) where T : class
    {
        _assistantContext.Set<T>().RemoveRange(entities);
        await _assistantContext.SaveChangesAsync();
    }
    public async Task<IEnumerable<T>> GetAllSortedAsync<T, TKey>(Expression<Func<T, TKey>> keySelector, bool ascending = true) where T : class
    {
        if (ascending)
        {
            return await _assistantContext.Set<T>().OrderBy(keySelector).ToListAsync();
        }
        else
        {
            return await _assistantContext.Set<T>().OrderByDescending(keySelector).ToListAsync();
        }
    }
    public async Task<IEnumerable<T>> GetWithIncludesAsync<T>(params Expression<Func<T, object>>[] includes) where T : class
    {
        IQueryable<T> query = _assistantContext.Set<T>();

        foreach (var include in includes)
        {
            query = query.Include(include);
        }

        return await query.ToListAsync();
    }
    public async Task<IEnumerable<T>> GetWithMultipleIncludesAsync<T>(
        Func<IQueryable<T>, IQueryable<T>> includes) where T : class
    {
        IQueryable<T> query = _assistantContext.Set<T>();

        query = includes(query);

        return await query.ToListAsync();
    }
}