﻿using ManagementSoftware.DAL;
using ManagementSoftware.Models;
using S7.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSoftware.PLCSetting
{
    public class PLCBauNong
    {
        public static Plc plc { get; set; }

        public static string plcName = "PLC Jig Bầu Nóng";
        public static string message { get; set; } = "";

        public static List<BauNong> listBauNong = new List<BauNong>();

        public static void Start()
        {
            string ip = "192.168.0.15";
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
                message = null;
            }
            catch (Exception ex)
            {
                message = "*Lỗi đóng máy: " + ex.Message;
            }
        }

        public static void GetData()
        {
            listBauNong = new List<BauNong>();
            string db = "DB100.";
            int dongDienAC = 0;
            int nhietDoPC = 40;
            int SoLanTest_ST_PC = 60;
            int SoLanTest_SP_PC = 80;
            int nhietDoNgatCBNhiet = 100;

            int cbNhiet = 120;


            for (int i = 0; i <= 9; i++)
            {
                BauNong obj = new BauNong();
                obj.DongDienAC = Math.Round(Conversion.ConvertToFloat((uint)plc.Read(db + "DBD" + dongDienAC)), 3, MidpointRounding.AwayFromZero);
                obj.NhietDo = Math.Round( Convert.ToDouble( ((ushort)plc.Read(db + "DBW" + nhietDoPC)))/10,2,MidpointRounding.AwayFromZero);
                obj.SoLanTest = (ushort)plc.Read(db + "DBW" + SoLanTest_ST_PC);
                obj.NhietDoNgatCBNhiet = (ushort)plc.Read(db + "DBW" + nhietDoNgatCBNhiet);
                obj.CBNhietThanBauNong = (ushort)plc.Read(db + "DBW" + cbNhiet) == 0 ? false : true;


                //ushort SoLanTest_SP_PC_Data = (ushort)plc.Read(db + "DBW" + SoLanTest_SP_PC);

                obj.BauNongName = "Jig " + (i + 1);
                dongDienAC += 4;
                nhietDoPC += 2;
                SoLanTest_ST_PC += 2;
                SoLanTest_SP_PC += 2;
                nhietDoNgatCBNhiet += 2;
                cbNhiet += 2;

                listBauNong.Add(obj);
            }

        }

        public static void SaveData()
        {
            if (listBauNong != null && listBauNong.Count > 0)
            {
                DALBauNong.Add(listBauNong);
            }
        }
    }
}
