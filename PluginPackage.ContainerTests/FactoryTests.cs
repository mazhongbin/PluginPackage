using Microsoft.VisualStudio.TestTools.UnitTesting;
using PluginPackage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PluginPackage.Tests
{
    [TestClass()]
    public class FactoryTests
    {
        [TestMethod()]
        public void GetInstanceTest()
        {
            var test = Factory.GetInstance<Test.ITest.ITestPlugin>();
            var result = test.GetTestResult();
            var test2 = Factory.GetInstance<Test.ITest.ITest2Plugin>();
            var result2 = test2.GetTestResult2();
            Console.WriteLine(result);
            if (string.IsNullOrEmpty(result)) Assert.Fail();
        }
    }
}