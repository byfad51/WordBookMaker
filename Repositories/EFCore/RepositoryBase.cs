using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories;

public class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    protected readonly RepositoryContext _context;

    public RepositoryBase(RepositoryContext context)
    {
        _context = context;
    }


    public IQueryable<T> FindAll(bool trackChanges)
        => !trackChanges ? _context.Set<T>().AsNoTracking() : _context.Set<T>();

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
        => !trackChanges ? _context.Set<T>().AsNoTracking().Where(expression) : _context.Set<T>().Where(expression);

    public void Create(T entity) => _context.Set<T>().Add(entity);

    public void Delete(T entitiy) => _context.Set<T>().Remove(entitiy);

    public void Update(T entity) => _context.Set<T>().Update(entity);
}