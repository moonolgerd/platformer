using System.Collections;
using System.Collections.Generic;
using Microsoft.Extensions.FileProviders;

namespace Platformer.Configuration
{
    internal class ResourceDirectoryContents : IDirectoryContents
    {
        private readonly string subpath;

        public ResourceDirectoryContents(string subpath)
        {
            this.subpath = subpath;
        }

        public bool Exists { get; }

        public IEnumerator<IFileInfo> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new System.NotImplementedException();
        }
    }
}