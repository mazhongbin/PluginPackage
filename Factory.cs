using PluginPackage.Core;
using System;

namespace PluginPackage
{
    public class Factory
    {
        private static PluginContainer XmlPluginContainer { get; set; }
        internal static IPluginContainer GetPluginContainer()
        {
            if (XmlPluginContainer == null)
                XmlPluginContainer = new PluginContainer();

            return XmlPluginContainer;
        }


        /// <summary>
        /// 获取类的实例
        /// </summary>
        /// <returns>返回实例</returns>
        public static T GetInstance<T>() where T : class
        {
            try
            {
                return GetPluginContainer().GetPluginInstance<T>();
            }
            catch (Exception ex)
            {
                throw new Exception($"未能加载{typeof(T).Name}, 请查看配置信息与命名空间、类名是否一致或查看继承的接口是否一致或是否缺少引用的程序集。详细错误信息：{ex.Message}");
            }


        }
    }


}
