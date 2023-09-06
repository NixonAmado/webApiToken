using System.Linq.Expressions;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repositiory;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity 
{
    private readonly TokenApiContext _context;

    public GenericRepository(TokenApiContext tokenApiContext)
    {
        _context = tokenApiContext;
    }

    public Task GetByAsync(int id)
    {
        throw new NotImplementedException();
    }

    public virtual async Task<T> GetByIdAsync(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public virtual IEnumerable<T> Find(Expression <Func<T, bool>> expression)
    {
        return _context.Set<T>().Where(expression);
    }

    public virtual void Add(T entity)
    {
        _context.Set<T>().Add(entity);
    }
    public virtual void AddRange(IEnumerable<T> entities)
    {
        _context.Set<T>().AddRange(entities);
    }
    public virtual void Remove(T entity)
    {
        _context.Set<T>().Remove(entity);
    }

    public virtual void RemoveRange(IEnumerable<T> entities)
    {
        _context.Set<T>().RemoveRange(entities);
    }

    public virtual void Update(T entity)
    {
        _context.Set<T>().Update(entity);
    }


}
