using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Primitives;

namespace Platformer.Configuration
{
    class ResourceFileProvider : IFileProvider
    {
        public IDirectoryContents GetDirectoryContents(string subpath) => new ResourceDirectoryContents(subpath);

        public IFileInfo GetFileInfo(string subpath) => new ResourceFileInfo(subpath);

        public IChangeToken Watch(string filter) => new ResourceChangeToken(filter);
    }
}
