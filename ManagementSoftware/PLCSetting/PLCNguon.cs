﻿using ManagementSoftware.Models;
using PROFINET_STEP_7.Profinet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSoftware.PLCSetting
{
    public class PLCNguon
    {
        public PLC plc { get; set; }
        public bool isConnected { get; set; }
        public static ExceptionCode errCode;

        public string plcName = "PLC Nguồn";
        public string message { get; set; } = "";

        public List<Nguon> listNguon { get; set; }
        public PLCNguon()
        {
            string ip = "192.168.0.17";
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
                message = null;
            }
            catch
            {
                message = $"Không thể kết nối tới {plcName}";
            }
        }


        public void Stop()
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

        public void GetData()
        {
            listNguon = new List<Nguon>();
            string db = "DB100.";
            int dienApCSAddr = 0;
            int dongDienCSAddr = 120;
            int congSuatCSAddr = 240;
            int timeAddr = 360;
            int soLanTestAddr = 480;


            for (int i = 0; i <= 29; i++)
            {
                Nguon nguon = new Nguon();
                nguon.DienApDC = Math.Round(PROFINET_STEP_7.Types.Double.FromByteArray((plc.ReadBytes(DataType.DataBlock, 100, dienApCSAddr, 4))), 2, MidpointRounding.AwayFromZero);
                nguon.DongDC = Math.Round(PROFINET_STEP_7.Types.Double.FromByteArray((plc.ReadBytes(DataType.DataBlock, 100, dongDienCSAddr, 4))), 2, MidpointRounding.AwayFromZero);
                nguon.CongSuat = Math.Round(PROFINET_STEP_7.Types.Double.FromByteArray((plc.ReadBytes(DataType.DataBlock, 100, congSuatCSAddr, 4))), 2, MidpointRounding.AwayFromZero);
                nguon.ThoiGianTest = (uint)plc.Read(db + "DBD" + timeAddr);
                nguon.SoLanTest = (ushort)plc.Read(db + "DBW" + soLanTestAddr);
                

                nguon.NguonName = "Nguồn " + (i + 1);
                dienApCSAddr += 4;
                dongDienCSAddr += 4;
                congSuatCSAddr += 4;
                timeAddr += 4;
                soLanTestAddr += 2;

                listNguon.Add(nguon);
            }
        }
    }
}