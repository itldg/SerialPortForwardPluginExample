using System;

namespace SerialPortForward
{
    public class OriginalRep : IPlugin
    {
        public string Name { get; set; } = "原文答复";

        public byte[] GetBytes(bool _, string ComName, ref byte[] Bytes)
        {
            return Bytes;
        }
    }
}
