using System;
using Microsoft.Extensions.Primitives;

namespace Platformer.Configuration
{
    internal class ResourceChangeToken : IChangeToken
    {
        private readonly string filter;

        public ResourceChangeToken(string filter) => this.filter = filter;

        public bool HasChanged => false;
        public bool ActiveChangeCallbacks { get; }

        public IDisposable RegisterChangeCallback(Action<object> callback, object state) => throw new NotImplementedException();
    }
}