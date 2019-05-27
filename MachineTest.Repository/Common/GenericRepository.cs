using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MachineTest.Repository.Common
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        /// <summary>
        /// The Dbset
        /// </summary>
        protected readonly DbSet<T> _currentDbSet;

        /// <summary>
        /// The DbContext
        /// </summary>
        protected DbContext _currentDbContext;

        /// <summary>
        /// Initializes a new instance of the TEntity class.
        /// </summary>
        /// <param name="context">The context.</param>
        protected GenericRepository(DbContext context)
        {
            _currentDbContext = context;
            try
            {
                _currentDbSet = _currentDbContext.Set<T>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public virtual T Add(T entity)
        {
            var result = default(T);
            try
            {
                var added = _currentDbSet.Add(entity);
                _currentDbContext.Entry(entity).State = EntityState.Added;
                result = added.Entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        /// <summary>
        /// Edits the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public T Update(T entity)
        {
            var result = default(T);
            try
            {
                var update = _currentDbSet.Update(entity);
                _currentDbContext.Entry(entity).State = EntityState.Modified;
                result = update.Entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public virtual IQueryable<T> GetAll()
        {
            var result = default(IQueryable<T>);
            try
            {
                result = _currentDbSet.AsNoTracking().AsParallel().AsQueryable();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        /// <summary>
        /// Finds the by.
        /// </summary>
        /// <param name="where">The predicate.</param>
        /// <returns></returns>
        public virtual IEnumerable<T> FindBy(Expression<Func<T, bool>> @where)
        {
            IEnumerable<T> query = null;
            try
            {
                query = _currentDbSet.Where(where).AsNoTracking().AsParallel().AsEnumerable();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return query;
        }


        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public virtual T Delete(T entity)
        {
            _currentDbContext.Entry(entity).State = EntityState.Deleted;
            var result = _currentDbSet.Remove(entity);
            return result.Entity;
        }
    }
}
