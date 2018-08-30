using System;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.FileProviders;

namespace Platformer.Configuration
{
    internal class ResourceFileInfo : IFileInfo
    {
        public ResourceFileInfo(string subpath)
        {
            Name = subpath;
        }

        public bool Exists => CreateReadStream() != null;
        public long Length => CreateReadStream().Length;
        public string PhysicalPath { get; }
        public string Name { get; }
        public DateTimeOffset LastModified { get; }
        public bool IsDirectory => false;

        public Stream CreateReadStream()
        {
            var assembly = Assembly.GetExecutingAssembly();
            return assembly.GetManifestResourceStream(Name);
        }
    }
}