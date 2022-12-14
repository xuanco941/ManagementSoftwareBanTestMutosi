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
    public class PLCBepTu
    {
        public static Plc plc { get; set; }

        public static string plcName = "PLC Jig Bếp Từ";
        public static string message { get; set; } = "";

        public static List<BepTu> listBepTu { get; set; } = new List<BepTu>();


        public static void Start()
        {
            string ip = "192.168.0.13";
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
            if (listBepTu != null && listBepTu.Count > 0)
            {
                DALBepTu.Add(listBepTu);
            }
        }


    }
}
