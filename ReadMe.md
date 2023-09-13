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

实现`SerialPortForward.IPlugin`的属性和方法

| 名称       | 作用                                                                                                     |
| ---------- | -------------------------------------------------------------------------------------------------------- |
| Name       | 插件名称                                                                                                 |
| HasOption  | 是否有设置选项                                                                                           |
| Option()   | 用户点击了设置按钮时调用                                                                                 |
| Checked()  | 当前插件被选中时调用                                                                                     |
| UnCheck()  | 当前插件被取消选中时调用                                                                                 |
| GetBytes() | 收到数据时调用,如果需要改变数据,则修改 `ref byte[] Bytes`的值,需要自动答复,则返回答复数据,否则返回`null` |

## 示例代码

示例代码-记录日志

```csharp
public class Log : IPlugin
{
    public Log()
    {
        if (!System.IO.Directory.Exists($"{AppDomain.CurrentDomain.BaseDirectory}Log"))
        {
            System.IO.Directory.CreateDirectory($"{AppDomain.CurrentDomain.BaseDirectory}Log");
        }
    }
    public string Name => "记录日志";

    public bool HasOption => false;
    public void Checked(PluginCommon plugin)
    {
    }
    public void UnCheck()
    {
    }
    public byte[] GetBytes(bool _, string ComName, ref byte[] Bytes)
    {
        string hex = Bytes.GetString_HEX();
        string str = Bytes.GetString_UTF8();
        string log = $"{ComName} {DateTime.Now.ToString("HH:mm:ss.fff")}\r\nHEX：{hex}\r\nTXT：{str}\r\n\r\n";
        string path = $"{AppDomain.CurrentDomain.BaseDirectory}Log\\{DateTime.Now.ToString("yyyy-MM-dd")}.txt";
        System.IO.File.AppendAllText(path, log);
        return null;
    }

    public void Option()
    {

    }
}
```

示例代码-原文答复

```csharp
public class OriginalRep : IPlugin
{
    public string Name => "原文答复";

    public bool HasOption => false;

    public byte[] GetBytes(bool _, string ComName, ref byte[] Bytes)
    {
        return Bytes;
    }
    public void Checked(PluginCommon plugin)
    {
    }
    public void UnCheck()
    {
    }
    public void Option()
    {

    }
}
```
