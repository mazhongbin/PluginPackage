using Microsoft.VisualStudio.TestTools.UnitTesting;
using PluginPackage.Configurator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PluginPackage.Configurator.Tests
{
    [TestClass()]
    public class PluginConfiguratorTests
    {
        [TestMethod()]
        public void ReadPluginConfigInfoTest()
        {
            var pluginConfigurator = new PluginConfigurator<PluginConfigInfoConverter>();
            var pluginConfigInfo = pluginConfigurator.ReadPluginConfigInfo("Test.Demo.TestPlugin");
            if (pluginConfigInfo == null) Assert.Fail();
        }
        [TestMethod()]
        public void ReadPluginConfigInfoTest1()
        {
            var pluginConfigurator = new PluginConfigurator<PluginConfigInfoConverter>();
            var pluginConfigInfo = pluginConfigurator.ReadPluginConfigInfo();
            if (pluginConfigInfo == null) Assert.Fail();
        }
    }


}