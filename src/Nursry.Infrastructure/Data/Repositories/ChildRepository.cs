using Microsoft.EntityFrameworkCore;
using Nursry.Core.Entities;
using Nursry.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Nursry.Infrastructure.Data.Repositories
{
    public class ChildRepository : EfRepository<Child>, IChildRepository
    {
        public ChildRepository(NursryContext dbContext) : base(dbContext)
        {
        }

        public Task<Child> GetByIdWithLogsAsync(Guid id)
        {
            return this.nursryContext.Children
                .Include(c => c.Logs)
                .Include(nameof(Child.Gender))
                .Include($"{nameof(Child.Logs)}.{nameof(FeedingType)}")
                .Include($"{nameof(Child.Logs)}.{nameof(DiaperType)}")
                .Include($"{nameof(Child.Logs)}.{nameof(BottleContent)}")
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
