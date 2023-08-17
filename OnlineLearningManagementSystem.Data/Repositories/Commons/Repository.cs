using Microsoft.EntityFrameworkCore;
using OnlineLearningManagementSystem.Data.DbContexts;
using OnlineLearningManagementSystem.Data.IRepositories.Commons;
using OnlineLearningManagementSystem.Domain.Commons;
using System.Linq.Expressions;

namespace OnlineLearningManagementSystem.Data.Repositories.Commons;

public class Repository<T> : IRepository<T> where T : Auditable
{
    private readonly AppDbContext appDbContext;
    private readonly DbSet<T> dbSet;

    public Repository(AppDbContext appDbContext)
    {
        this.appDbContext = appDbContext;
        dbSet = this.appDbContext.Set<T>();
    }

    public async ValueTask CreateAsync(T entity)
    {   
        await dbSet.AddAsync(entity);
    }

    public void Delete(T entity)
    {
        dbSet.Remove(entity);
    }

    public void Update(T entity)
    {
        entity.UpdateAt = DateTime.UtcNow;
        dbSet.Entry(entity).State = EntityState.Modified;
    }

    public async ValueTask<T> GetAsync(Expression<Func<T, bool>> expression, string[] includes = null)
    {
        IQueryable<T> query = expression is null ? dbSet.AsQueryable() : dbSet.Where(expression).AsQueryable();

        if(includes is not null)
            foreach(var include in includes)
                query = query.Include(include);
         
        var result = await query.FirstOrDefaultAsync(expression);

        return result;
    }

    public IQueryable<T> GetAll(Expression<Func<T, bool>> expression = null, bool isNoTracked = true, string[] includes = null)
    {
        IQueryable<T> query = expression is null ? dbSet.AsQueryable() : dbSet.Where(expression).AsQueryable();

        query = isNoTracked ? query.AsNoTracking() : query;

        if (includes is not null)
            foreach (var include in includes)
                query = query.Include(include);

        return query;
    }

    public async ValueTask<int> SaveAsync()
        => await appDbContext.SaveChangesAsync();
}
