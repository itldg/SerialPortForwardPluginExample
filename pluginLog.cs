using System;

namespace SerialPortForward
{
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
}
