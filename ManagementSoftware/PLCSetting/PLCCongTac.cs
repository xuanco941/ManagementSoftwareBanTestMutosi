using ManagementSoftware.DAL;
using ManagementSoftware.GUI;
using ManagementSoftware.Models;
using S7.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSoftware.PLCSetting
{
    public class PLCCongTac
    {
        public static Plc plc { get; set; }

        public static string plcName = "PLC Jig Công Tắc";
        public static string message { get; set; } = "";

        public static List<CongTac2VT> listCT2VT { get; set; } = new List<CongTac2VT>();
        public static List<CongTac3VT> listCT3VT { get; set; } = new List<CongTac3VT>();



        public static void Start()
        {
            string ip = "192.168.0.21";
            CpuType cpu = CpuType.S71200;
            short rack = 0;
            short slot = 1;
            plc = new Plc(cpu, ip, rack, slot);

            try
            {
                if (string.IsNullOrEmpty(plc.IP))
                {
                    message = $"*{plcName} thiếu địa chỉ IP";
                    throw new Exception($"Xin vui lòng nhập địa chỉ IP {plcName}");
                }
                plc.Open();
                if (!plc.IsConnected)
                {
                    message = $"*Không tìm thấy {plcName}!";
                    throw new Exception($"Không tìm thấy {plcName}!");
                }


                // success
                message = "";
            }
            catch
            {
                message = $"Không thể kết nối tới {plcName}";
            }
        }


        public static void Stop()
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

        public static void GetData()
        {

        }

        public static void SaveData()
        {
            if (listCT2VT != null && listCT2VT.Count>0)
            {
                DALCongTac2VT.Add(listCT2VT);
            }
            if (listCT3VT != null && listCT3VT.Count > 0)
            {
                DALCongTac3VT.Add(listCT3VT);
            }
        }
    }
}
