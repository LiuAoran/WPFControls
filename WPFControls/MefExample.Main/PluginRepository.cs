using MefExample.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MefExample.Main
{
    class PluginRepository
    {
        [ImportMany("IPluginService")]
        private IEnumerable<PluginService.IPluginService> PluginServices { get; set; }
        // For more convenience we will copy the available plugins in a List<>
        public List<PluginService.IPluginService> PluginServiceList { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pluginServices"></param>
        public PluginRepository(IEnumerable<PluginService.IPluginService> pluginServices)
        {
            PluginServiceList = new List<PluginService.IPluginService>();
            foreach (var service in pluginServices)
                PluginServiceList.Add(service);
        }
    }
}
