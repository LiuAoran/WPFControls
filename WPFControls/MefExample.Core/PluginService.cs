using System;
using System.ComponentModel;
using System.ComponentModel.Composition;

namespace MefExample.Core
{
    public class PluginService
    {
        [InheritedExport(typeof(IPluginService))]
        public interface IPluginService
        {
            string InitPlugin();
        }
    }
}
