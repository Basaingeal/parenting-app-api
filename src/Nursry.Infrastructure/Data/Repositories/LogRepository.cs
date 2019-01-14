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
    class LogRepository : EfRepository<Log>, ILogRepository
    {
        public LogRepository(NursryContext dbContext) : base(dbContext)
        {
        }

        public Task<List<DiaperLog>> GetDiaperLogsByChildId(Guid childId)
        {
            return this.nursryContext.DiaperLogs
                .Include($"{nameof(Child.Logs)}.{nameof(DiaperType)}")
                .Where(l => l.Child.Id == childId)
                .ToListAsync();
        }

        public Task<List<FeedingLog>> GetFeedingLogsByChildId(Guid childId)
        {
            return this.nursryContext.FeedingLogs
                .Include($"{nameof(Child.Logs)}.{nameof(FeedingType)}")
                .Include($"{nameof(Child.Logs)}.{nameof(BottleContent)}")
                .Where(l => l.Child.Id == childId)
                .ToListAsync();
        }

        public Task<List<Log>> GetLogsByChildId(Guid childId)
        {
            return this.nursryContext.Set<Log>()
                .Include($"{nameof(Child.Logs)}.{nameof(FeedingType)}")
                .Include($"{nameof(Child.Logs)}.{nameof(BottleContent)}")
                .Include($"{nameof(Child.Logs)}.{nameof(DiaperType)}")
                .Where(l => l.Child.Id == childId)
                .ToListAsync();
        }
    }
}
