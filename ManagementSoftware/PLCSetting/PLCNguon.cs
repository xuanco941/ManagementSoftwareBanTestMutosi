using ManagementSoftware.DAL;
using ManagementSoftware.Models;
using S7.Net;


namespace ManagementSoftware.PLCSetting
{
    public class PLCNguon
    {
        public static Plc plc { get; set; }

        public static string plcName = "PLC Nguồn";
        public static string message { get; set; } = "";
        public static List<Models.Nguon> listNguonTu1Den15 { get; set; } = new List<Models.Nguon>(new Nguon[15]);
        public static List<Models.Nguon> listNguonTu16Den30 { get; set; } = new List<Models.Nguon>(new Nguon[15]);

        public static List<Models.Nguon> listNguonSave { get; set; } = new List<Models.Nguon>(new Nguon[30]);

        public static void Start()
        {
            string ip = "192.168.0.17";
            S7.Net.CpuType cpu = CpuType.S71200;
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
                message = "";
            }
            catch (Exception ex)
            {
                message = "*Lỗi đóng máy: " + ex.Message;
            }
        }


        public static int count = 0;

        public static void SaveData()
        {
            count++;

            listNguonSave = new List<Models.Nguon>(new Nguon[30]);
            string db = "DB100.";
            int dienApCSAddr = 0;
            int dongDienCSAddr = 120;
            int congSuatCSAddr = 240;
            int timeAddr = 360;
            int soLanTestAddr = 480;


            for (int i = 0; i <= 29; i++)
            {
                Models.Nguon nguon = new Models.Nguon();

                try
                {
                    object? dienApDCVar = plc.Read(db + "DBD" + dienApCSAddr);
                    object? DongDCVar = plc.Read(db + "DBD" + dongDienCSAddr);
                    object? congSuatVar = plc.Read(db + "DBD" + congSuatCSAddr);
                    object? thoiGianTestVar = plc.Read(db + "DBD" + timeAddr);
                    object? soLanTestVar = plc.Read(db + "DBW" + soLanTestAddr);

                    nguon.DienApDC = dienApDCVar != null ? Math.Round(Conversion.ConvertToFloat((uint)dienApDCVar), 3, MidpointRounding.AwayFromZero).ToString() : "N/A";
                    nguon.DongDC = DongDCVar != null ? Math.Round(Conversion.ConvertToFloat((uint)DongDCVar), 3, MidpointRounding.AwayFromZero).ToString() : "N/A";
                    nguon.CongSuat = congSuatVar != null ? Math.Round(Conversion.ConvertToFloat((uint)congSuatVar), 3, MidpointRounding.AwayFromZero).ToString() : "N/A";
                    nguon.ThoiGianTest = thoiGianTestVar != null ? ((uint)thoiGianTestVar).ToString() : "N/A";
                    nguon.SoLanTest = soLanTestVar != null ? ((ushort)soLanTestVar).ToString() : "N/A";
                    //bool c = (bool)plc.Read("DB100.DBX544.1");
                }
                catch
                {
                    ControlAllPLC.StopNguon();
                    Stop();
                    break;
                }


                nguon.NguonName = "Nguồn " + (i + 1);
                dienApCSAddr += 4;
                dongDienCSAddr += 4;
                congSuatCSAddr += 4;
                timeAddr += 4;
                soLanTestAddr += 2;

                if (i < 15)
                {
                    listNguonTu1Den15[i] = nguon;
                }
                else
                {
                    listNguonTu16Den30[i-15] = nguon;
                }
                listNguonSave[i] = (nguon);
            }
            if(count  >= 10)
            {
                DALNguon.Add(listNguonSave);
                count = 0;
            }
        }
    }
}