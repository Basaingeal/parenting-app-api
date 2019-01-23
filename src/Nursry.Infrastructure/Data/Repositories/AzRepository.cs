using Microsoft.WindowsAzure.Storage.Blob;
using Nursry.Core.Interfaces;
using Nursry.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Nursry.Infrastructure.Data.Repositories
{
    public class AzRepository<T> : IAsyncStorageRepository<T> where T : StorageEntity
    {
        private readonly CloudBlobClient client;
        public AzRepository(CloudBlobClient client)
        {
            this.client = client;
        }

        public async Task<T> AddOrUpdateAsync(T entity)
        {
            var container = client.GetContainerReference(entity.Container);
            await container.CreateIfNotExistsAsync();
            string key = entity.Path + entity.Id.ToString();
            CloudBlockBlob blob = container.GetBlockBlobReference(key);
            blob.Properties.ContentType = entity.ContentType;
            if(await blob.ExistsAsync())
            {
                await blob.SetPropertiesAsync();
            }
            await blob.UploadFromStreamAsync(entity.Stream);
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            var container = client.GetContainerReference(entity.Container);
            await container.CreateIfNotExistsAsync();
            string key = entity.Path + entity.Id.ToString();
            CloudBlockBlob blob = container.GetBlockBlobReference(key);
            await blob.DeleteIfExistsAsync();
        }

        public async Task<T> GetByIdAsync(T entity)
        {
            var container = client.GetContainerReference(entity.Container);
            await container.CreateIfNotExistsAsync();
            string key = entity.Path + entity.Id.ToString();
            CloudBlockBlob blob = container.GetBlockBlobReference(key);
            entity.Stream = entity.Stream ?? new MemoryStream();
            await blob.DownloadToStreamAsync(entity.Stream);
            entity.ContentType = blob.Properties.ContentType;
            entity.Stream.Position = 0;
            return entity;
        }
    }
}
