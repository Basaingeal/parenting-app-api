using Nursry.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Nursry.Core.Interfaces
{
    public interface IChildRepository : IAsyncRepository<Child>
    {
        Task<Child> GetByIdWithLogsAsync(Guid id);
    }
}
