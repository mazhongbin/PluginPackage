
using PluginPackage.Core;
using System;

namespace PluginPackage.Configurator
{
    /// <summary>
    /// 组件配置信息的转换
    /// </summary>
    public class PluginConfigInfoConverter : IPluginConfigInfoConverter
    {
        public virtual PluginConfigInfo ConvertToPluginConfigInfo(PluginsPlugin pluginsPlugin) => new PluginConfigInfo { PluginIndex = pluginsPlugin.Index, NameSpaceClassName = pluginsPlugin.Name, Tag = pluginsPlugin.Tag, PluginPath = pluginsPlugin.Path.Contains(":") ? pluginsPlugin.Path : System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, pluginsPlugin.Path) };
    }
}
