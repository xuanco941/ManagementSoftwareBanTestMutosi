using ManagementSoftware.Models;
using PROFINET_STEP_7.Profinet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSoftware.PLCSetting
{
    public class PLCBauNong
    {
        public PLC plc { get; set; }
        public bool isConnected { get; set; }
        public static ExceptionCode errCode;

        public string plcName = "PLC Jig Bầu Nóng";
        public string message { get; set; } = "";

        public List<BauNong> listBauNong = new List<BauNong>();

        public PLCBauNong()
        {
            string ip = "192.168.0.15";
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
                obj.DongDienAC = PROFINET_STEP_7.Types.Double.FromByteArray((plc.ReadBytes(DataType.DataBlock, 100, dongDienAC, 4)));
                obj.NhietDo = (ushort)plc.Read(db + "DBW" + nhietDoPC);
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
    }
}
