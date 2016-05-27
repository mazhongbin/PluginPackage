using PluginPackage.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace PluginPackage
{
    public abstract class Container : IPluginContainer
    {
        private static List<Type> PluginList { get; set; }

        public virtual List<Type> GetPlugins()
        {
            if (PluginList == null || PluginList.Count==0)
            {
                PluginList = new List<Type>();

                lock (PluginList)
                {
                    //取插件信息
                    var pluginConfigInfos = GetPluginConfigurator().ReadPluginConfigInfo();
                    if (pluginConfigInfos != null && pluginConfigInfos.Any())
                    {
                        foreach (var item in pluginConfigInfos)
                        {
                            try
                            {
                                var filePath = item.PluginPath;
                                var ass = Assembly.LoadFrom(filePath);
                                Type t = ass.GetType($"{item.NameSpaceClassName}");
                                if (t == null) continue;
                                PluginList.Add(t);
                            }
                            catch (Exception ex) { }
                        }
                    }
                }
               
            }

            try
            {
                NLog.LogManager.GetCurrentClassLogger().Info($"读取到的组件信息：{Json2KeyValue.JsonConvert.SerializeObject(PluginList)}");
            }
            catch (Exception){   }
         
            return PluginList;
        }


        public abstract IPluginConfigurator GetPluginConfigurator();

        /// <summary>
        /// 获取指定类型的插件实例
        /// </summary>
        /// <typeparam name="T">类或接口，建议传入接口</typeparam>
        /// <returns>返回T实例</returns>
        public virtual T GetPluginInstance<T>() where T : class
        {
            var pluginList = GetPlugins(); 
            foreach (var item in pluginList)
            {
                var isContainsT = item.GetInterfaces().Contains(typeof(T));
                if (isContainsT)
                {
                    var ibp = Activator.CreateInstance(item) as T;
                    if (ibp != null) return ibp;
                }
            }
            throw new Exception($"无法找到{typeof(T).Name}的程序集信息，请检查配置文件及程序集。检测到的所有程序集:\r\n{Json2KeyValue.JsonConvert.SerializeObject(pluginList)}");
        }

        public T GetPluginInstance<T>(string name) where T : class
        {
            var pluginList = GetPlugins();
            foreach (var item in pluginList)
            {

                if (item.Name == name)
                {
                    var ibp = Activator.CreateInstance(item) as T;
                    if (ibp != null) return ibp;
                }

            }

            throw new Exception($"无法找到{typeof(T).Name}的程序集信息，请检查配置文件及程序集。检测到的所有程序集:\r\n{Json2KeyValue.JsonConvert.SerializeObject(pluginList)}");

        }
    }
}
