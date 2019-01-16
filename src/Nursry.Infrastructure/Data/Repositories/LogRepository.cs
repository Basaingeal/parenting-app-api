using Microsoft.EntityFrameworkCore;
using Nursry.Core.Entities;
using Nursry.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nursry.Infrastructure.Data.Repositories
{
    public class LogRepository : EfRepository<Log>, ILogRepository
    {
        public LogRepository(NursryContext dbContext) : base(dbContext)
        {
        }

        public Task<Log> GetByIdWithChildAsync(Guid logId)
        {
            return nursryContext.Set<Log>()
                .Include(l => l.Child)
                .FirstOrDefaultAsync(l => l.Id == logId);
        }

        public Task<List<DiaperLog>> GetDiaperLogsByChildId(Guid childId)
        {
            return this.nursryContext.DiaperLogs
                .Include(l => l.Child)
                .Where(l => l.ChildId == childId)
                .ToListAsync();
        }

        public Task<List<FeedingLog>> GetFeedingLogsByChildId(Guid childId)
        {
             return this.nursryContext.Set<FeedingLog>()
                .Include(l => l.Child)
                .Where(l => l.ChildId == childId)
                .ToListAsync();
        }

        public Task<List<Log>> GetLogsByChildId(Guid childId)
        {
            return this.nursryContext.Set<Log>()
                .Include(l => l.Child)
                .Where(l => l.ChildId == childId)
                .ToListAsync();
        }
    }
}
