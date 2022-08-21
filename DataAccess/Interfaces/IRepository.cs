using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();

        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate);

        int Count();

        int Count(Expression<Func<T, bool>> predicate);

        T Get(Expression<Func<T, bool>> predicate);

        IQueryable<dynamic> SelectList(Expression<Func<T, bool>> @where, Expression<Func<T, dynamic>> @select);

        List<T> SendSql(string sqlQuery);

        void Add(T entity);

        void BulkInsert(List<T> entityList);

        void Update(T entity);

        void Update(Expression<Func<T, bool>> predicate, T entity);

        void Delete(T entity, bool forceDelete = false);

        void Delete(Expression<Func<T, bool>> predicate, bool forceDelete = false);

        bool Any(Expression<Func<T, bool>> predicate);

        DbContext GetDbContext();
    }
}
