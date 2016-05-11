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
            if (PluginList == null)
            {
                PluginList = new List<Type>();
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
            var pluginList = new List<T>(); 
            foreach (var item in GetPlugins())
            {
                var isContainsT = item.GetInterfaces().Contains(typeof(T));
                if (isContainsT)
                {
                    var ibp = Activator.CreateInstance(item) as T;
                    if (ibp != null) return ibp;
                }
            }
            throw new Exception($"无法找到{typeof(T).Name}的程序集信息，请检查配置文件及程序集。");
        }

        public T GetPluginInstance<T>(string name) where T : class
        {
            var pluginList = new List<T>();
            foreach (var item in GetPlugins())
            {

                if (item.Name == name)
                {
                    var ibp = Activator.CreateInstance(item) as T;
                    if (ibp != null) return ibp;
                }

            }
            throw new Exception($"无法找到{typeof(T).Name}的程序集信息，请检查配置文件及程序集。");
        }
    }
}
