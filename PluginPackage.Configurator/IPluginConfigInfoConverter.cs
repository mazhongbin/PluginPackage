using PluginPackage.Core;

namespace PluginPackage.Configurator
{
    /// <summary>
    /// 组件配置信息的转换
    /// </summary>
    public interface IPluginConfigInfoConverter
    {
        PluginConfigInfo ConvertToPluginConfigInfo(PluginsPlugin pluginsPlugin);
    }
}
