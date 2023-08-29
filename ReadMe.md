# 串口转发插件示例

串口转发软件现已支持插件处理数据,并对数据进行自动答复等

这里提供几个示例插件

## 插件列表

-   原始数据
-   日志记录
-   原文答复

## 开发步骤

新建一个 C#类库项目,引用`SerialPortForward.exe`

新建一个类,继承`SerialPortForward.IPlugin`

实现`SerialPortForward.IPlugin`的`Name`和`GetBytes`

`Name`为插件名称,`GetBytes`为插件处理数据的方法

示例代码-记录日志

```csharp
public class Log:IPlugin
{
    public Log()
    {
        if(!System.IO.Directory.Exists($"{AppDomain.CurrentDomain.BaseDirectory}Log"))
        {
            System.IO.Directory.CreateDirectory($"{AppDomain.CurrentDomain.BaseDirectory}Log");
        }
    }
    public string Name { get; set; } = "记录日志";

    public byte[] GetBytes(bool _, string ComName, ref byte[] Bytes)
    {
        string hex=Bytes.GetString_HEX();
        string str=Bytes.GetString_UTF8();
        string log=$"{ComName} {DateTime.Now.ToString("HH:mm:ss.fff")}\r\nHEX：{hex}\r\nTXT：{str}\r\n\r\n";
        string path=$"{AppDomain.CurrentDomain.BaseDirectory}Log\\{DateTime.Now.ToString("yyyy-MM-dd")}.txt";
        System.IO.File.AppendAllText(path,log);
        return null;
    }
}
```

示例代码-原文答复

```csharp
public class OriginalRep : IPlugin
{
    public string Name { get; set; } = "原文答复";

    public byte[] GetBytes(bool _, string ComName, ref byte[] Bytes)
    {
        return Bytes;
    }
}
```
