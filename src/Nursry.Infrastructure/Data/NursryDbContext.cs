using Microsoft.EntityFrameworkCore;
using Nursry.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nursry.Infrastructure.Data
{
    class NursryDbContext : DbContext
    {
        public DbSet<Activity> Activities { get; set; }
    }
}
