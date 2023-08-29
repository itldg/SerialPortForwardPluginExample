using System;

namespace SerialPortForward
{
    public class Base:IPlugin
    {
        public string Name { get; set; } = "原始数据";

        public byte[] GetBytes(bool IsCom1, string ComName, ref byte[] Bytes)
        {
            return null;
        }
    }
}
