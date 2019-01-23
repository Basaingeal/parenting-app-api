using Microsoft.WindowsAzure.Storage.Blob;
using Nursry.Core.Entities.Storage;
using Nursry.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Nursry.Infrastructure.Data.Repositories
{
    public class ChildImageRepository : AzRepository<ChildImage>, IChildImageRepository
    {
        public ChildImageRepository(CloudBlobClient client) : base(client)
        {
        }

        public Task<ChildImage> GetByIdAsync(Guid id)
        {
            var childImage = new ChildImage(id, null);
            return GetByIdAsync(childImage);
        }

        public Task DeleteAsync(Guid id)
        {
            var childImage = new ChildImage(id, null);
            return DeleteAsync(childImage);
        }
    }
}
