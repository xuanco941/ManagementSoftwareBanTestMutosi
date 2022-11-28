using ManagementSoftware.DAL;
using ManagementSoftware.Models;
using PROFINET_STEP_7.Profinet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSoftware.PLCSetting
{
    public class PLCJigLoiLoc
    {
        public PLC plc { get; set; }
        public bool isConnected { get; set; }
        public static ExceptionCode errCode;

        public string plcName = "PLC Jig Lõi Lọc";
        public string message { get; set; } = "";


        public LoiLoc loiloc1 = new LoiLoc();
        public LoiLoc loiloc2 = new LoiLoc();
        public LoiLoc loiloc1va2 = new LoiLoc();
        public PLCJigLoiLoc()
        {
            string ip = "192.168.0.11";
            CPU_Type cpu = CPU_Type.S71200;
            short rack = 0;
            short slot = 1;
            plc = new PLC(cpu, ip, rack, slot);
        }

        public void Start()
        {
            try
            {
                if (string.IsNullOrEmpty(plc.IP))
                {
                    message = $"*{plcName} thiếu địa chỉ IP";
                    throw new Exception($"Xin vui lòng nhập địa chỉ IP {plcName}");
                }
                if (!plc.IsAvailable)
                {
                    message = $"*Không tìm thấy {plcName}!";
                    throw new Exception($"Không tìm thấy {plcName}!");
                }
                errCode = plc.Open();
                if (errCode != ExceptionCode.ExceptionNo)
                {
                    message = $"*Lỗi {plcName}: " + plc.lastErrorString.ToString();
                    throw new Exception(plc.lastErrorString);
                }

                // success
                message = "";
            }
            catch
            {
                //message = "Không thể kết nối";
            }
        }


        public void Stop()
        {
            try
            {
                plc.Close();
            }
            catch (Exception ex)
            {
                message = "*Lỗi đóng máy: " + ex.Message;
            }
        }


        public void GetData()
        {
            DataPLC.DongDien = new List<double>();
            DataPLC.DienAp = new List<double>();
            DataPLC.CongSuat = new List<double>();

            //(READ) JigMachNguon DB100.DB

            int firstElementDienAp = 0;
            int firstElementDongDien = 40;
            int firstElementCongSuat = 80;

            for (int i = 0; i < 10; i++)
            {
                int khoangCachVungNhoTiepTheo = i * 4;
                string adrrDienAp = "DB100.DBD" + (firstElementDienAp + khoangCachVungNhoTiepTheo);
                string adrrCongSuat = "DB100.DBD" + (firstElementCongSuat + khoangCachVungNhoTiepTheo);
                string adrrDongDien = "DB100.DBD" + (firstElementDongDien + khoangCachVungNhoTiepTheo);

                DataPLC.DongDien.Add(Math.Round(PROFINET_STEP_7.Types.Double.FromDWord((uint)plc.Read(adrrDongDien)), 2, MidpointRounding.AwayFromZero));
                DataPLC.CongSuat.Add(Math.Round(PROFINET_STEP_7.Types.Double.FromDWord((uint)plc.Read(adrrCongSuat)), 2, MidpointRounding.AwayFromZero));
                DataPLC.DienAp.Add(Math.Round(PROFINET_STEP_7.Types.Double.FromDWord((uint)plc.Read(adrrDienAp)), 2, MidpointRounding.AwayFromZero));

            }


            ////paramete
            //CurrentValuePLC.pH = PROFINET_STEP_7.Types.Double.FromDWord((uint)plc.Read("DB16.DBD0"));

            ////luu luong
            //CurrentValuePLC.luuLuongTong = PROFINET_STEP_7.Types.Double.FromDWord((uint)plc.Read("DB16.DBD16"));




            //////status_position DB17
            //CurrentValuePLC.status_position_DB17_1 = (ushort)plc.Read("DB17.DBW0");

            //////status_position DB18
            //CurrentValuePLC.status_position_DB18_1 = (ushort)plc.Read("DB18.DBW0");

        }
    }
}
