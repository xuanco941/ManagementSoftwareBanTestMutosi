using ManagementSoftware.DAL;
using ManagementSoftware.Models;
using S7.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSoftware.PLCSetting
{
    public class PLCJigMach
    {
        public static Plc plc { get; set; }
        public static string plcName = "PLC Jig Mạch";
        public static string message { get; set; } = "";

        public static List<JigMachNguon> listJigMachNguon { get; set; } = new List<JigMachNguon>();
        public static List<JigMachTDS> listJigMachTDS { get; set; } = new List<JigMachTDS>();

        public static void Start()
        {
            string ip = "192.168.0.19";
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
            if ((listJigMachNguon != null && listJigMachNguon.Count > 0) && ((listJigMachTDS != null && listJigMachTDS.Count > 0)))
            {
                DALJigMach.Add(listJigMachNguon, listJigMachTDS);
            }
        }
    }
}
