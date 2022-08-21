using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        #region Members

        private readonly DbContext dbContext;
        private readonly DbSet<T> dbSet;

        #endregion

        #region Constructor

        public Repository(DbContext dbContext)
        {
            this.dbContext = dbContext;
            dbSet = dbContext.Set<T>();
        }

        #endregion

        #region Methods

        public T Get(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = dbSet.Where(predicate);
            return query.ToList().FirstOrDefault();
        }

        public IQueryable<T> GetAll()
        {
            IQueryable<T> query = dbSet.Where(e => e != null);
            return query;
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = dbSet.Where(predicate);
            return query;
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public void BulkInsert(List<T> entityList)
        {
            foreach (var t in entityList)
            {
                dbSet.Add(t);
            }
        }

        public void Update(T entity)
        {
            dbSet.Attach(entity);
            dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity, bool forceDelete = false)
        {
            EntityEntry<T> dbEntityEntry = dbContext.Entry(entity);

            if (dbEntityEntry.State != EntityState.Deleted || forceDelete)
                dbEntityEntry.State = EntityState.Deleted;
            else
            {
                dbSet.Attach(entity);
                dbSet.Remove(entity);
            }
        }

        public void Delete(Expression<Func<T, bool>> predicate, bool forceDelete = false)
        {
            Delete(dbSet.First(predicate), forceDelete);
        }

        public bool Any(Expression<Func<T, bool>> predicate)
        {
            return dbSet.Any(predicate);
        }

        public int Count()
        {
            return Count(arg => true);
        }

        public int Count(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = dbSet.Where(predicate);
            return query.Count();
        }

        public DbContext GetDbContext()
        {
            return dbContext;
        }

        public IQueryable<dynamic> SelectList(Expression<Func<T, bool>> where, Expression<Func<T, dynamic>> select)
        {
            throw new NotImplementedException();
        }

        public List<T> SendSql(string sqlQuery)
        {
            throw new NotImplementedException();
        }

        public void Update(Expression<Func<T, bool>> predicate, T entity)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
