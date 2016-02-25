namespace PluginPackage.Core
{
    /// <summary>
    /// 组件容器
    /// </summary>
    public interface IPluginContainer
    {
        /// <summary>
        /// 获取指定组件的类实例
        /// </summary>
        /// <typeparam name="T">类，类必须实现构造方法</typeparam>
        /// <returns>返回类的实例</returns>
        T GetPluginInstance<T>() where T : class;

        /// <summary>
        /// 获取指定组件的类实例
        /// </summary>
        /// <typeparam name="T">类，类必须实现构造方法</typeparam>
        /// <returns>返回类的实例</returns>
        T GetPluginInstance<T>(string name) where T : class;
    }
}
