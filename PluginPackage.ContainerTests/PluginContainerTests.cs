using Microsoft.VisualStudio.TestTools.UnitTesting;
using PluginPackage;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace PluginPackage.Tests
{
    [TestClass()]
    public class PluginContainerTests
    {
        [TestMethod()]
        public void GetPluginsTest()
        {
            var pluginContainer = new PluginContainer();
            var test = pluginContainer.GetPlugins();
            if (!test.Any()) Assert.Fail();

        }

        [TestMethod()]
        public void GetPluginInstanceTest()
        {
            var pluginContainer = new PluginContainer();
            var test = pluginContainer.GetPluginInstance<Test.ITest.ITestPlugin>();
            var result = test.GetTestResult();
            Console.WriteLine(result);
            if (test == null) Assert.Fail();
        }
    }
}