using Nursry.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Nursry.Core.Entities.Storage
{
    public class ChildImage : StorageEntity
    {
        public ChildImage(Guid id, Stream stream)
        {
            Container = "images";
            Path = "childImages/";
            Id = id;
            Stream = stream;
            ContentType = "image/webp";
        }
    }
}
