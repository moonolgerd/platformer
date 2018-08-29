using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.Interfaces
{
    public interface IFileStorage
    {
        Task<string> ReadAsString(string filename);
    }
}
