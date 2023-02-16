using ManagementSoftware.Models.CongTacModel;
using ManagementSoftware.Models.JigMachModel;
using S7.Net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ManagementSoftware.PLCSetting
{
    public class ControlAllPLC
    {

        public const string ipLoiLoc = "192.168.0.11";
        public const string PLCLoiLoc = "PLC Lõi Lọc";

        public const string ipBauNong = "192.168.0.15";
        public const string PLCBauNong = "PLC Bầu nóng";

        public const string ipBepTu = "192.168.0.13";
        public const string PLCBepTu = "PLC Bếp từ";

        public const string ipCongTac = "192.168.0.21";
        public const string PLCCongTac = "PLC Công tắc";

        public const string ipMach = "192.168.0.19";
        public const string PLCMach = "PLC Mạch";

        public const string ipNguon = "192.168.0.17";
        public const string PLCNguon = "PLC Nguồn";



        
    }
}
