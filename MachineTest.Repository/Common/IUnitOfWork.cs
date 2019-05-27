using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MachineTest.Repository.Common
{
    public interface IUnitOfWork
    {
        /// <summary>
        /// Saves all pending changes
        /// </summary>
        /// <returns>The number of objects in an Added, Modified, or Deleted state</returns>
        int Commit();

        /// <summary>
        /// Saves all pending changes with asyc
        /// </summary>
        /// <returns>The number of objects in an Added, Modified, or Deleted state</returns>
        Task<int> CommitAsync();
    }
}
