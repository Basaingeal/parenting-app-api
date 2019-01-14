using Nursry.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Nursry.Core.Interfaces
{
    public interface ILogRepository : IAsyncRepository<Log>
    {
        Task<List<Log>> GetLogsByChildId(Guid childId);
        Task<List<FeedingLog>> GetFeedingLogsByChildId(Guid childId);
        Task<List<DiaperLog>> GetDiaperLogsByChildId(Guid childId);
    }
}
