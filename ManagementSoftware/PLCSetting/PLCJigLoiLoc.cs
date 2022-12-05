﻿using ManagementSoftware.DAL;
using ManagementSoftware.GUI;
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
        public static PLC plc { get; set; }
        public static ExceptionCode errCode;
        public static string plcName = "PLC Jig Lõi Lọc";
        public static string message { get; set; } = "";
        public static Models.LoiLoc loiloc = new Models.LoiLoc();

        public static void Start()
        {
            string ip = "192.168.0.11";
            CPU_Type cpu = CPU_Type.S71200;
            short rack = 0;
            short slot = 1;
            plc = new PLC(cpu, ip, rack, slot);

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
                message = $"Không thể kết nối tới {plcName}";
            }
        }


        public static void Stop()
        {
            try
            {
                plc.Close();
                message = "";
            }
            catch (Exception ex)
            {
                message = "*Lỗi đóng máy: " + ex.Message;
            }
        }

        public static void GetData()
        {
            loiloc = new Models.LoiLoc();
            //time ms
            UInt32 ST_Time_Cap = (UInt32)plc.Read("DB100.DBD22");
            uint ST_Time_Giu = (uint)plc.Read("DB100.DBD26");
            uint ST_Time_Xa = (uint)plc.Read("DB100.DBD30");

            double ST_Ap_Suat = Math.Round(PROFINET_STEP_7.Types.Double.FromByteArray((plc.ReadBytes(DataType.DataBlock, 100, 36, 4))), 2, MidpointRounding.AwayFromZero);

            ushort ST_SL_Test = (ushort)plc.Read("DB100.DBW34");
            ushort loaiLoiLocTest = (ushort)plc.Read("DB100.DBW64");

            if (loaiLoiLocTest == 1)
            {
                loiloc.LoiLocName = TenThietBi.LoiLoc1;
            }
            else if (loaiLoiLocTest == 2)
            {
                loiloc.LoiLocName = TenThietBi.LoiLoc2;
            }
            else if (loaiLoiLocTest == 3)
            {
                loiloc.LoiLocName = TenThietBi.LoiLoc1va2;
            }

            loiloc.ThoiGianGiu = ST_Time_Giu;
            loiloc.ThoiGianXa = ST_Time_Xa;
            loiloc.ThoiGianNen = ST_Time_Cap;
            loiloc.SoLanTest = ST_SL_Test;
            loiloc.ApSuatTest = ST_Ap_Suat;

        }
    }
}
