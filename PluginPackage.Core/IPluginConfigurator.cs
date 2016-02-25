using System.Collections.Generic;

namespace PluginPackage.Core
{
    /// <summary>
    /// 组件配置
    /// </summary>
    public interface IPluginConfigurator
    {
        PluginConfigInfo ReadPluginConfigInfo(string name);

        List<PluginConfigInfo> ReadPluginConfigInfo();
    }
}
