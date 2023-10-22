using API.Business.Repository.IRepository;
using API.Database;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace API.Business.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly DataContext _db;

        public RepositoryBase(DataContext db)
        {
            _db = db;
        }

        public void Create(T entity)
        {
            _db.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _db.Set<T>().Remove(entity);
        }

        public IQueryable<T> GetAll(bool trackChanges)
        {
            return !trackChanges ? _db.Set<T>().AsNoTracking()
                : _db.Set<T>();
        }

        public IQueryable<T> GetAllByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
        {
         return   !trackChanges ? _db.Set<T>().Where(expression).AsNoTracking()
                   : _db.Set<T>().Where(expression);
        }

        public void Update(T entity)
        {
            _db.Set<T>().Update(entity);
        }


    }
}
