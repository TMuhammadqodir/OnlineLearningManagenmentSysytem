using OnlineLearningManagementSystem.Domain.Commons;
using System.Linq.Expressions;

namespace OnlineLearningManagementSystem.Data.IRepositories.Commons;

public interface IRepository<T> where T : Auditable
{
    ValueTask CreateAsync(T entity);
    void Update(T entity);
    void Delete(T entity);
    ValueTask<T> GetAsync(Expression<Func<T, bool>> expression, string[] includes = null);
    IQueryable<T> GetAll(Expression<Func<T, bool>> expression = null, bool isNoTracked = true, string[] includes = null);
    ValueTask<int> SaveAsync();
}
