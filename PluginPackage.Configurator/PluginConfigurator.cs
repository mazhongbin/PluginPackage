using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
using PluginPackage.Core;

namespace PluginPackage.Configurator
{
    public class PluginConfigurator<TPluginConfigInfoConverter> : IPluginConfigurator
        where TPluginConfigInfoConverter : IPluginConfigInfoConverter, new()
    {

        public string ConfigPath { get; set; }
        private PluginsConfig Plugins { get; set; }
        public PluginConfigurator()
        {
            ConfigPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "PluginConfig.xml");

            if (string.IsNullOrEmpty(ConfigPath))
                throw new Exception("无法找到组件配置信息。");

            if (!ConfigPath.Contains(":"))
                ConfigPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ConfigPath);
        }

        /// <summary>
        /// 读取指定name的配置信息
        /// </summary>
        /// <param name="name">配置名</param>
        /// <returns></returns>
        public PluginConfigInfo ReadPluginConfigInfo(string name)
        {
            if (Plugins == null)
            {
                using (var sr = new FileStream(ConfigPath, FileMode.Open))
                {
                    Plugins = XmlDeserialize<PluginsConfig>(sr) as PluginsConfig;
                }
            }
            var plugin = Plugins.Plugin.FirstOrDefault(m => m.Name.Contains(name));
            if (plugin != null)
            {
                var configInfoConverter = new TPluginConfigInfoConverter();
                var pluginConfigInfo = configInfoConverter.ConvertToPluginConfigInfo(plugin);
                return pluginConfigInfo;
            }
            return null;
        }

        private T XmlDeserialize<T>(Stream xmlStream) where T : class
        {
            var xs = new System.Xml.Serialization.XmlSerializer(typeof(T));
            return xs.Deserialize(xmlStream) as T;
        }


        public List<PluginConfigInfo> ReadPluginConfigInfo()
        {
            if (Plugins == null)
            {
                using (var sr = new FileStream(ConfigPath, FileMode.Open))
                {
                    Plugins = XmlDeserialize<PluginsConfig>(sr) as PluginsConfig;
                }
            }
            var pluginConfigInfoList = new List<PluginConfigInfo>();
            foreach (var item in Plugins.Plugin)
            {
                var configInfoConverter = new TPluginConfigInfoConverter();
                var pluginConfigInfo = configInfoConverter.ConvertToPluginConfigInfo(item);
                if (pluginConfigInfo != null)
                {
                    pluginConfigInfoList.Add(pluginConfigInfo);
                }
            }
            return pluginConfigInfoList;
        }


    }
}
