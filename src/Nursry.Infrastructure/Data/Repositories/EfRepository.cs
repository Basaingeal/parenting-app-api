using Microsoft.EntityFrameworkCore;
using Nursry.Core.Interfaces;
using Nursry.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nursry.Infrastructure.Data.Repositories
{
    public class EfRepository<T> : IAsyncRepository<T> where T : BaseEntity
    {
        protected readonly NursryContext nursryContext;

        public EfRepository(NursryContext nursryContext)
        {
            this.nursryContext = nursryContext;
        }

        public async Task<T> AddAsync(T entity)
        {
            this.nursryContext.Set<T>().Add(entity);
            await this.nursryContext.SaveChangesAsync();

            return entity;
        }

        public Task<int> CountAsync(ISpecification<T> spec)
        {
            return ApplySpecification(spec).CountAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            this.nursryContext.Set<T>().Remove(entity);
            await this.nursryContext.SaveChangesAsync();
        }

        public virtual Task<T> GetByIdAsync(Guid id)
        {
            return nursryContext.Set<T>().FindAsync(id);
        }

        public Task<List<T>> ListAllAsync()
        {
            return this.nursryContext.Set<T>().ToListAsync();
        }

        public Task<List<T>> ListAsync(ISpecification<T> spec)
        {
            return ApplySpecification(spec).ToListAsync();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            this.nursryContext.Entry(entity).State = EntityState.Modified;
            await this.nursryContext.SaveChangesAsync();
            return entity;
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(this.nursryContext.Set<T>().AsQueryable(), spec);
        }
    }
}
