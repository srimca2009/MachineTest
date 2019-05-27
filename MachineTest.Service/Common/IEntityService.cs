using System.Linq;

namespace MachineTest.Service.Common
{
    /// <summary>
    /// IEntityService
    /// </summary>
    /// <typeparam name="T">The type of the entity.</typeparam>
    public interface IEntityService<T> where T : class
    {
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        IQueryable<T> GetAll();

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        T Add(T entity);

        /// <summary>
        /// Edits the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        T Update(T entity);

        /// <summary>
        /// Delete specified entity
        /// </summary>
        /// <param name="entity">The Entity</param>
        /// <returns></returns>
        T Delete(T entity);
    }
}
