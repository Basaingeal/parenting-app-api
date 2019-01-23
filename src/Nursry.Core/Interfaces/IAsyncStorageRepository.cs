using Nursry.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Nursry.Core.Interfaces
{
    public interface IAsyncStorageRepository<T> where T : StorageEntity
    {
        Task<T> GetByIdAsync(T entity);
        Task<T> AddOrUpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
