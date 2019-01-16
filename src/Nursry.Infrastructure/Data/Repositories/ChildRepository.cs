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
            var x = "hi";
        }

        public Task<Child> GetByIdWithLogsAsync(Guid id)
        {
            return this.nursryContext.Children
                .Include(c => c.Logs)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
