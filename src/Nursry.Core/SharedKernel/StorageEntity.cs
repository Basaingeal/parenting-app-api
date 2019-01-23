using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Nursry.Core.SharedKernel
{
    public abstract class StorageEntity
    {
        public string Path { get; set; }
        public Guid Id { get; set; }
        public string Container { get; set; }
        public Stream Stream { get; set; }
        public string ContentType { get; set; }
    }
}
