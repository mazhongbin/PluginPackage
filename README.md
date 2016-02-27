# PluginPackage
该工具可以使你的应用程序实现插件式的项目,只需更改PluginConfig.xml配置文件即可切换组件。
```
```

1. 设计接口
创建一个类库项目Test.ITest，在这个项目里，设计两个接口
```
namespace Demo.ITest
{
    public interface ITest2Plugin
    {
        string GetTestResult2();
    }
}


namespace Demo.ITest
{
    public interface ITestPlugin
    {
        string GetTestResult();
    }
}
```

1. 创建类库项目Test.Demo并引用刚刚创建的接口DLL
实现刚刚创建的接口
 ```
using System;
using Test.ITest;
namespace Demo
{
    public class TestPlugin : ITestPlugin
    {
        public string GetTestResult()
        {
            return "已成功调用PluginPackage";
        }
    }

    public class TestPlugin2 : ITest2Plugin 
    {
        public string GetTestResult2()
        {
            return "已成功调用PluginPackage2";
        }     
    }
}
 ```

1. 在程序项目引用接口DLL与PluginPackage包
  使用以下代码调用

  ```
var test = PluginPackage.Factory.GetInstance<Demo.ITest.ITestPlugin>();
var result = test.GetTestResult();
  ```

1. 更改配置文件，使实现的类依赖注入到接口
 更改配置文件PluginConfig.xml
```
<?xml version="1.0" encoding="utf-8" ?>
<PluginsConfig>
  <Plugin Name="Demo.TestPlugin" Path="Plugin\Test.Demo.dll" />
  <Plugin Name="Demo.TestPlugin2" Path="Plugin\Test.Demo.dll" />
</PluginsConfig>
```


 

  
