using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace Platformer.Configuration
{
    class ResourceFileProvider : IFileProvider
    {
        public IDirectoryContents GetDirectoryContents(string subpath)
        {
            return new ResourceDirectoryContents(subpath);
        }

        public IFileInfo GetFileInfo(string subpath)
        {
            return new ResourceFileInfo(subpath);
        }

        public IChangeToken Watch(string filter)
        {
            return new ResourceChangeToken(filter);
        }
    }
}
