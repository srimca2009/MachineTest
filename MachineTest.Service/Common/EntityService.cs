using MachineTest.Repository.Common;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MachineTest.Service.Common
{
    public abstract class EntityService<T> : IEntityService<T> where T : class
    {
        /// <summary>
        /// The _unit of work
        /// </summary>
        private IUnitOfWork _unitOfWork;

        /// <summary>
        /// The _repository
        /// </summary>
        private readonly IGenericRepository<T> _repository;

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="repository">The repository.</param>
        protected EntityService(IUnitOfWork unitOfWork, IGenericRepository<T> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public virtual IQueryable<T> GetAll()
        {
            return _repository.GetAll();
        }

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public virtual T Add(T entity)
        {
            var result = _repository.Add(entity);
            _unitOfWork.Commit();
            return result;
        }

        /// <summary>
        /// Edits the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public virtual T Update(T entity)
        {
            var result = _repository.Update(entity);
            _unitOfWork.Commit();
            return result;
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public virtual T Delete(T entity)
        {
            try
            {
                var result = _repository.Delete(entity);
                _unitOfWork.Commit();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
