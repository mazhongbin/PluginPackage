using System;
using Test.ITest;

namespace Test.Demo
{
    public class TestPlugin : ITestPlugin
    {
        public string GetTestResult()
        {
            return "已成功调用PluginPackage";
        }
    }

    public class TestPlugin2 : ITest2Plugin {
        public string GetTestResult2()
        {
            return "已成功调用PluginPackage2";
        }

        
    }
}
