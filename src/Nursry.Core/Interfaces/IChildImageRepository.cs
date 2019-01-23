using Nursry.Core.Entities.Storage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Nursry.Core.Interfaces
{
    public interface IChildImageRepository : IAsyncStorageRepository<ChildImage>
    {
        Task<ChildImage> GetByIdAsync(Guid id);
        Task DeleteAsync(Guid id);
    }
}
