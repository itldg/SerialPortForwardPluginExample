using System;

namespace SerialPortForward
{
    public class Base : IPlugin
    {

        public string Name { get; } = "原始数据";
        public bool HasOption { get => false; }
        public void Checked(PluginCommon plugin)
        {
        }
        public void UnCheck()
        {
        }
        public byte[] GetBytes(bool IsCom1, string ComName, ref byte[] Bytes)
        {
            return null;
        }

        public void Option()
        {
        }
    }
}
