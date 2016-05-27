using System;
using System.Collections.Generic;
using PluginPackage.Configurator;
using PluginPackage.Core;

namespace PluginPackage
{
    public class PluginContainer : Container
    {
        public override IPluginConfigurator GetPluginConfigurator() => new PluginConfigurator<PluginConfigInfoConverter>();

        public override List<Type> GetPlugins()
        {
            return base.GetPlugins();
        }

        public override T GetPluginInstance<T>()
        {
            return base.GetPluginInstance<T>();
        }
    }
}
