using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MachineTest.Repository.Common
{
    public interface IGenericRepository<T> where T : class
    {
        /// <summary>
        /// Get All Records
        /// </summary>
        /// <returns></returns>
        IQueryable<T> GetAll();

        /// <summary>
        /// Find by Entities
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        IEnumerable<T> FindBy(Expression<Func<T, bool>> @where);

        /// <summary>
        /// Add Specified Entity
        /// </summary>
        /// <param name="entity">Specified Entity</param>
        /// <returns>The Entity</returns>
        T Add(T entity);

        /// <summary>
        /// Edits the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        T Update(T entity);

        /// <summary>
        /// Delete Specified Entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        T Delete(T entity);
    }
}
