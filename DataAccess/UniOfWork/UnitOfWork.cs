using DataAccess.Interfaces;
using DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Transactions;

namespace DataAccess.UniOfWork
{
    public class UnitOfWork<T> : IDisposable, IUnitOfWork where T : class
    {
        #region Members

        private DbContext _dbContext;

        private DbContext dbContext
        {
            get
            {
                try
                {
                    if (_dbContext == null)
                        _dbContext = (DbContext)Activator.CreateInstance(typeof(T));
                    return _dbContext;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    throw;
                }
            }
            set
            {
                _dbContext = value;
            }
        }

        #endregion

        #region Properties

        public readonly List<string> ErrorList = new();

        #endregion

        #region Constructor

        public UnitOfWork()
        {

        }

        #endregion

        #region Methods

        public IRepository<T> GetRepository<T>() where T : class
        {
            return new Repository<T>(dbContext);
        }

        public int SaveChanges()
        {
            int result = -1;
            try
            {
                using (TransactionScope tScope = new TransactionScope())
                {
                    result = dbContext.SaveChanges();
                    tScope.Complete();
                }
            }
            catch (ValidationException ex)
            {
                ErrorList.Add(ex.Message);
            }
            catch (DbUpdateException ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null)
                {
                    message += " <-> " + ex.InnerException.Message;
                    if (ex.InnerException.InnerException != null)
                        message += " <-> " + ex.InnerException.InnerException.Message;
                }
                ErrorList.Add(message);
            }
            finally
            {
                if (result == -1)
                    ErrorList.ForEach(e => Console.WriteLine(e));
            }
            return result;
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }

        #endregion
    }
}
