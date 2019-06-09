using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLMPClient
{
    class SLMPFrame
    {
        public static readonly ushort FrameSize = 21;



        public struct SLMPDeviceRead_Request
        {
            public ushort Subheader;
            public byte NetNo;
            public byte ReqDestStationNo;
            public byte ReqDestMultiStationNo;
            public ushort RequestDataLenght;
            public ushort Reserved;
            public ushort Command;
            public ushort Subcommand;
            public ushort HeadDeviceNo;
            public byte DeviceCode;
            public ushort NoDevices;
        };
    }
}
