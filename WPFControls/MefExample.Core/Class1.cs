using System;

namespace MefExample.Core
{
    public interface IPlugin
    {
        void Start();
        void Stop();
    }
}
