using System;

namespace SerialPortForward
{
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
}
